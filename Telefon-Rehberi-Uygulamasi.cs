using System;
using System.Data.SqlClient;

namespace TelefonRehberim
{
    class Program
    {

       
        static void Main(string[] args)
        {
            RehberUygulamaları rehber = new RehberUygulamaları();

            int islem = 0;

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :))");
            Console.WriteLine("*******************");
            Console.WriteLine("(1) Yeni numara kaydetmek");
            Console.WriteLine("(2) Varolan numarayı silmek");
            Console.WriteLine("(3) Varolan numarayı güncellemek");
            Console.WriteLine("(4) Rehberi listelemek");
            Console.WriteLine("(5) Rehberde arama yapmak");

            if (int.TryParse(Console.ReadLine(), out islem))
            {
                switch (islem)
                {
                    case 1:
                        rehber.Kaydet();
                        break;
                    case 2:
                        rehber.Sil();
                        break;
                    case 3:
                        rehber.Guncelle();
                        break;
                    case 4:
                        rehber.Listele();
                        break;
                    case 5:
                        rehber.Arama();
                        break;
                    default:
                        Console.WriteLine("Hatalı bir tuşlama yaptınız lütfen 1-5 arası bir sayı giriniz.");
                        break;
                }
            }
            else Console.WriteLine("Hatalı bir tuşlama yaptınız.");

            Console.ReadKey();
        }
    }

    class RehberUygulamaları
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=TelefonUygulamasi;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public void Kaydet()
        {
            Console.WriteLine("*Lütfen isim giriniz            : ");
            string ad = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz          : ");
            string soyad = Console.ReadLine();
            Console.WriteLine("*Lütfen telefon numarası giriniz: ");
            string telefon = Console.ReadLine();
            

            con.Open();
            cmd = new SqlCommand("Insert into Rehber(isim,soyisim,telefonNo) values('" + ad + "','" + soyad + "'," + telefon + ")",con);
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("İşleminiz gerçekleşti!!");
        }

        public void Sil()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını veya soyadını giriniz: ");
            string silinecek = Console.ReadLine();

            int sayi = 0;
            
            con.Open(); //aradığımız string veriye göre kaç kişi olduğunu öğrenmek için kullandığım bölüm
            cmd = new SqlCommand("select count(*) from rehber where isim = '" + silinecek + "' or soyisim= '" + silinecek + "';", con);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read()) sayi =int.Parse(read[0].ToString());
            con.Close();

            string ad = "";//aradığımız veri'de bir ad veya soyad var mı kontrol etmemiz için kullandığım bölüm.
            if(sayi >=1)
            {
            con.Open();
            cmd = new SqlCommand("select isim from rehber where isim='" + silinecek + "' or soyisim='" + silinecek+"' order by id",con);
            SqlDataReader read2 = cmd.ExecuteReader();
            if (read2.Read()) ad = read2[0].ToString();
            con.Close();
            }
            if(ad !="")
                Console.WriteLine(ad + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kişi rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için    : (random)");
                Console.WriteLine("* Yeniden denemek için              : (2)");
                if (int.TryParse(Console.ReadLine(), out int sonuc) )
                    if (sonuc == 2) Sil();
                else Environment.Exit(0);

            }
                
            if (Console.ReadLine().ToLower() == "y")
            {
                if (sayi == 1)
                {
                    con.Open();
                    cmd = new SqlCommand("delete from rehber where isim='" + silinecek + "' or soyisim='" + silinecek + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("İşleminiz başarıyla gerçekleşti!!");
                }
                else
                {
                    string telefon = "";

                    con.Open();
                    cmd = new SqlCommand("select top 1 telefonNo from Rehber where isim ='" + silinecek + "' or soyisim='" + silinecek + "' order by id;", con);
                    SqlDataReader oku = cmd.ExecuteReader();

                    if (oku.Read()) telefon = oku[0].ToString();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("delete from rehber where telefonNo =" + telefon, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("İşleminiz başarıyla gerçekleşti!!");
                }
            }
            else Environment.Exit(0);
        }

        public void Guncelle()
        {
            Console.WriteLine("Lütfen numarasını değiştirmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string kim = Console.ReadLine(); 
            string telefon = "";

            con.Open();
            cmd = new SqlCommand("select top 1 telefonNo from rehber where isim='" + kim + "' or soyisim='" + kim + "' order by id;", con);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read()) telefon = read[0].ToString();
            con.Close();

            if(telefon == "")
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için    : (random)");
                Console.WriteLine("* Yeniden denemek için              : (2)");
                if (int.TryParse(Console.ReadLine(), out int sonuc) && sonuc < 3 && sonuc > 0)
                    if (sonuc == 2) Guncelle();

                else Environment.Exit(0);

            }
            else
            {
                Console.WriteLine("Değiştirilecek numarayı yazınız: ");
                string guncellenecek = Console.ReadLine();

                con.Open();
                cmd = new SqlCommand("update rehber set telefonNo='" + guncellenecek + "' where telefonNo='" + telefon+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("İşleminiz başarıyla gerçekleşti!!");
            }
        }

        public void Listele()
        {
            Console.Clear();    
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("***************************");

            con.Open();
            cmd = new SqlCommand("select isim,soyisim,telefonNo from rehber",con);
            SqlDataReader okula = cmd.ExecuteReader();
            while (okula.Read())
            {
                Console.WriteLine("isim             : " + okula[0].ToString());
                Console.WriteLine("Soyisim          : " + okula[1].ToString());
                Console.WriteLine("Telefon numarası : " + okula[2].ToString());
                Console.WriteLine("-");
            }
            con.Close();
        }

        public void Arama()
        {
            string kim = "";
            Console.Clear();
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**********************************************");
            Console.WriteLine("");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            if (int.TryParse(Console.ReadLine(), out int deger))
            {
                Console.WriteLine("Aramanızı yazınız: ");
                kim = Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Hatalı bir kodlama yaptınız.");
                Arama();
            }
            
            if(deger==1)
            {
            con.Open();
            cmd = new SqlCommand("select isim,soyisim,telefonNo from rehber where isim like '" + kim + "%' or soyisim like '" + kim + "%' order by id" ,con);
            SqlDataReader oku = cmd.ExecuteReader();
            while(oku.Read())
            {
                Console.WriteLine("isim             : " + oku[0].ToString());
                Console.WriteLine("Soyisim          : " + oku[1].ToString());
                Console.WriteLine("Telefon numarası : " + oku[2].ToString());
                Console.WriteLine("-");
            }
                con.Close();
            }

            else if(deger==2)
            {
                con.Open();
                cmd = new SqlCommand("select isim,soyisim,telefonNo from rehber where telefonNo like '" + kim + "%' order by id", con);
                SqlDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    Console.WriteLine("isim             : " + oku[0].ToString());
                    Console.WriteLine("Soyisim          : " + oku[1].ToString());
                    Console.WriteLine("Telefon numarası : " + oku[2].ToString());
                    Console.WriteLine("-");
                }
                con.Close();
            }

        }
    }
}

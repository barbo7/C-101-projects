using System;

using System.Data.SqlClient;

namespace ConsoleApp55
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
            else
                Console.WriteLine("Hatalı bir tuşlama yaptınız.");

            Console.ReadKey();
        }
    }
    class RehberUygulamaları
    {
        SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=TelefonUygulamasi;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public void Kaydet()
        {
            Console.WriteLine("*Lütfen isim giriniz: ");
            string ad = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz: ");
            string soyad = Console.ReadLine();
            Console.WriteLine("*Lütfen telefon numarası giriniz: ");
            string telefon = Console.ReadLine();
            

            con.Open();
            cmd = new SqlCommand("Insert into Rehber(isim,soyisim,telefonNo) values('" + ad + "','" + soyad + "'," + telefon + ")",con);
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("İşleminiz gerçekleşti");
        }

        public void Sil()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını veya soyadını giriniz: ");
            string silinecek = Console.ReadLine();
            int sayi = 0;
            //aradığımız string veriye göre kaç kişi olduğunu öğrenmek için kullandığım bölüm

            con.Open();
            cmd = new SqlCommand("select count(*) from rehber where isim = '" + silinecek + "' or soyisim= '" + silinecek + "';", con);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read()) sayi =int.Parse(read[0].ToString());
            con.Close();

            string ad = "";
            if(sayi >=1)
            {
            con.Open();
            cmd = new SqlCommand("select isim from rehber where isim='" + silinecek + "' or soyisim='" + silinecek+"'",con);
            SqlDataReader read2 = cmd.ExecuteReader();
            if (read2.Read()) ad = read2[0].ToString();
            con.Close();
            }

            Console.WriteLine(ad + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                if (sayi == 0)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine("* Yeniden denemek için              : (2)");
                    int sonuc = int.Parse(Console.ReadLine());
                    if (sonuc == 2) Sil();
                    else Console.WriteLine("Çıkış işleminiz yapılıyor..");

                }
                else if (sayi == 1)
                {
                    con.Open();
                    cmd = new SqlCommand("delete from rehber where isim='" + silinecek + "' or soyisim='" + silinecek + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("İşleminiz başarıyla gerçekleşti");
                }
                else
                {
                    string telefon = "";

                    con.Open();
                    cmd = new SqlCommand("select top 1 telefonNo from Rehber where isim ='" + silinecek + "' or soyisim='"+silinecek+"';", con);
                    SqlDataReader oku = cmd.ExecuteReader();

                    if (oku.Read()) telefon = oku[0].ToString();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("delete from rehber where telefonNo =" + telefon, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("İşleminiz başarıyla gerçekleşti");
                }
            }
        }

        public void Guncelle()
        {
            Console.WriteLine("Lütfen numarasını değiştirmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string kim = Console.ReadLine(); ;
            Console.WriteLine("Değiştireceğiniz numarayı yazınız: ");
            string guncellenecek = Console.ReadLine();
            string telefon = "";


            con.Open();
            cmd = new SqlCommand("select top 1 telefonNo from rehber where isim='" + kim + "' or soyisim='" + kim + "';", con);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read()) telefon = read[0].ToString();
            con.Close();
            if(telefon == "")
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                Console.WriteLine("* Yeniden denemek için              : (2)");
                if (int.TryParse(Console.ReadLine(), out int sonuc))
                    if (sonuc == 2) Guncelle();
                    else Console.WriteLine("Çıkış işleminiz yapılıyor..");
            }
            else
            {

                con.Open();
                cmd = new SqlCommand("update rehber set telefonNo='" + guncellenecek + "' where telefonNo='" + telefon+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("İşleminiz başarıyla gerçekleşti");
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

        }
    }
}

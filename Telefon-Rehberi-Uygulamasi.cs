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
            int admisoyadmi = 0;
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını veya soyadını giriniz: ");
            Console.WriteLine("Ad Girmek için    :(1)");
            Console.WriteLine("Soyad Girmek için :(2)");
            if (int.TryParse(Console.ReadLine(),out admisoyadmi));
            Console.WriteLine("Kimi silmek istediğinizi yazınızora: ");
            string silinecek = Console.ReadLine();
            int sayi=0;
            string sorgu1 = "select count(*) from rehber where isim = '" + silinecek + "' or soyisim= '" + silinecek + "';";

            //Bu ad veya soyadda kaç kişi var bulmak için yazdığım aptalca beni yoran kod
            con.Open();
            cmd = new SqlCommand(sorgu1, con);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read()) sayi =int.Parse(read[0].ToString());
            con.Close();

            if (sayi == 0)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                Console.WriteLine("* Yeniden denemek için              : (2)");
                int sonuc = int.Parse(Console.ReadLine());
                if (sonuc == 2) Sil();
                
            }
            else if(sayi == 1)
            {


                con.Open();
                cmd = new SqlCommand("delete from rehber where isim='" + silinecek + "' or soyisim='" + silinecek + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("İşleminiz başarıyla gerçekleşti");
            }
            else
            {
                if(admisoyadmi==1)
                {
                    string telefon = "";

                    con.Open();
                    cmd = new SqlCommand("select top 1 telefonNo from Rehber where isim ='" + silinecek + "';",con);
                    SqlDataReader oku = cmd.ExecuteReader();

                    if (oku.Read()) telefon = oku[0].ToString();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("delete from rehber where telefonNo =" + telefon, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Console.WriteLine("İşleminiz başarıyla gerçekleşti");
                }

                else if(admisoyadmi==2)
                {
                    string telefon = "";

                    con.Open();
                    cmd = new SqlCommand("select top 1 telefonNo from Rehber where soyisim ='" + silinecek + "';",con);
                    SqlDataReader oku = cmd.ExecuteReader();
                    if (oku.Read()) telefon = oku[0].ToString();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("delete from rehber where telefonNo=" + telefon, con);
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


            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update rehber set telefonNo=" + guncellenecek + " where isim ='" + kim + "' or soyisim = '"+kim + "'"; ;
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("İşleminiz başarıyla gerçekleşti");

        }

        public void Listele()
        {

        }

        public void Arama()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Board tahta = new Board();
            start:
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*****************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek ");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            if (int.TryParse(Console.ReadLine(), out int islem))
                switch (islem)
                {
                    case 1:
                        tahta.Listele();
                        break;
                    case 2:
                        tahta.Ekle();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Hatalı bir giriş yaptınız.");
                        Console.WriteLine("");
                        goto start;
                }

            Console.ReadKey();
        }

    }
    class Board
    {
        public Dictionary<string,string> Kart = new Dictionary<string,string>();

        public void Listele()
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine(" Line");
            Console.WriteLine("__________________________");
            Console.WriteLine("Başlık      : "  );
            Console.WriteLine("İçerik      : ");
            Console.WriteLine("Atanan Kişi : ");
            Console.WriteLine("Büyüklük    : ");

            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("__________________________");
            Console.WriteLine("");

            Console.WriteLine("Done");
            Console.WriteLine("__________________________");
            Console.WriteLine("");
        }

        public void Ekle()
        {
            string baslik, icerik, buyuk,editor;

            Dictionary<int, string> kisiler = new Dictionary<int, string>();
            kisiler.Add(0, "Admin");
            kisiler.Add(1, "Bora");
            kisiler.Add(2, "Halil");
            kisiler.Add(3, "Aytaç");

            Console.WriteLine("Başlık Giriniz                                 :");
            baslik = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz                                 :");
            icerik = Console.ReadLine();
            Console.WriteLine("Kişi Seçiniz (0=Admin,1=Bora,2=Halil,3=Aytaç)  :");
            if (int.TryParse(Console.ReadLine(), out int kisi)) editor = ((Editors)kisi).ToString();
            else { Console.WriteLine("Lütfen olan kişilerden seçim yapınız: "); editor = ((Editors)5).ToString(); }

                Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) :");
            int buyukluk = int.Parse(Console.ReadLine());

            if (buyukluk != null && buyukluk < 6 && buyukluk > 0) buyuk = ((Boyutlar)buyukluk).ToString();
            else buyuk = ((Boyutlar)1).ToString();
            

            Console.ReadKey();
            List<string> listem = new List<string>();
            listem.Add(baslik);
            listem.Add(icerik);
            listem.Add(editor);
            listem.Add(buyuk);
        }
    }
}


enum Editors
{
    Admin =0,
    Bora,
    Umut,
    Aytac,
    Halil,
    Belirsiz
}
enum Boyutlar
    {
        XS=1,
        S,
        M,
        L,
        XL
    }


using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    public class Program:Islemler
    {
        static void Main(string[] args)
        {
            Islemler tahta = new Islemler();
            tahta.Gorevler();

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
                        tahta.Sil();
                        break;
                    case 4:
                        tahta.Tasima();
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
    
    public class Islemler
    {
        List<List<string>> myList = new List<List<string>>();
        public void Gorevler()
        {
            List<string> gorev2 = new List<string>() { "Fizik hesabı", "C# programlama dilinde atışlar ve çarpışma hesabı yapacak program yapılacak.", "Bora", "XL", "TODO" };
            List<string> gorev3 = new List<string>() { "Ram alınacak", "Android studyonun rahat çalışması için ram alınacak", "Bora", "S", "InProgress" };
            List<string> gorev4 = new List<string>() { "Harita uygulaması", "Php üzerinden harita üzerinden işlemler yapılacak uygulama yapılacak", "Halil", "L", "TODO" };
            List<string> gorev5 = new List<string>() { "Delphi", "Delphi sınavı gelmeden önce çalışmalar yapılacak", "Umut", "S", "InProgress" };
            List<string> gorev6 = new List<string>() { "TODO UYGULAMASI", "Patika sitesinin istediği TODO projesi", "Bora", "M", "Done" };

            myList.Add(gorev2);
            myList.Add(gorev3);
            myList.Add(gorev4);
            myList.Add(gorev5);
            myList.Add(gorev6);
        }

        public void Listele()
        {
            Console.Clear();
            Console.WriteLine("");
            for (int i = 0; i < myList.Count(); i++)
            {
                for (int a = 1; a <= 3; a++)
                {
                    if (myList[i][4] == ((Lines)a).ToString())
                        Console.WriteLine(myList[i][4] + " Lines");
                }
                Console.WriteLine("__________________________");
                Console.WriteLine("Başlık      : " + myList[i][0]);
                Console.WriteLine("İçerik      : " + myList[i][1]);
                for (int b = 1; b <= 6; b++)
                {
                    if ((myList[i][2] == ((Editors)b).ToString()))
                        Console.WriteLine("Atanan Kişi : " + myList[i][2]);
                }
                for (int c = 1; c < 5; c++)
                {
                    if ((myList[i][3] == ((Boyutlar)c).ToString()))
                        Console.WriteLine("Büyüklük    : " + (myList[i][3]));
                }
                Console.WriteLine("");
            }
        }

        public void Ekle()
        {
            string baslik, icerik, buyuk, editor;

            Console.WriteLine("Başlık Giriniz                                 :"); baslik = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz                                 :"); icerik = Console.ReadLine();
            Console.WriteLine("Kişi Seçiniz (1=Admin,2=Bora,3=Halil...)       :");
            if (int.TryParse(Console.ReadLine(), out int kisi)) editor = ((Editors)kisi).ToString();
            else { Console.WriteLine("Lütfen olan kişilerden seçim yapınız: "); editor = ((Editors)6).ToString(); }

            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) :"); int buyukluk = int.Parse(Console.ReadLine());
            if (buyukluk != null && buyukluk < 6 && buyukluk > 0) buyuk = ((Boyutlar)buyukluk).ToString();
            else buyuk = ((Boyutlar)1).ToString();

            List<string> gorev1 = new List<string>() { baslik, icerik, editor, buyuk, ((Lines)1).ToString() };
            myList.Add(gorev1);

            Console.WriteLine("Ekleme işlemi başarıyla gerçekleşti!!");
            Console.WriteLine("");
            Console.WriteLine("Menüye dönmek için (1), Görevleri listelemek için (2) tuşlayınız");
            if (int.TryParse(Console.ReadLine(), out int son))
                if (son == 2) Listele();
                else if (son == 1) ;

            Console.ReadKey();

        }
        public void Tasima()
        {
            Console.WriteLine(" Öncelikle değiştirmek istediğiniz kartı seçmeniz gerekiyor. ");
            Console.WriteLine("Lütfen kart başlığını yazınız: ");
            string title = Console.ReadLine();
            int sayac = myList.Count();

            for (int i = 0; i < myList.Count(); i++)
                if (myList[i][0] == title)
                {
                    Console.WriteLine("Bulunan Kart Bilgileri:");
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Başlık      :" + title);
                    Console.WriteLine("İçerik      :" + myList[i][1]);
                    Console.WriteLine("Atanan Kişi :" + myList[i][2]);
                    Console.WriteLine("Büyüklük    :" + myList[i][3]);
                    Console.WriteLine("Line        :" + myList[i][4]);
                    Console.WriteLine("");
                    Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: ");
                    Console.WriteLine("(1) TODO");
                    Console.WriteLine("(2) IN PROGRESS");
                    Console.WriteLine("(3) DONE");

                    if (int.TryParse(Console.ReadLine(), out int islem))
                        myList[i][4] = ((Lines)islem).ToString();
                    Console.WriteLine("İşleminiz başarıyla gerçekleşti.");
                    Console.WriteLine("");
                }
                else sayac--;

              if(sayac==0)
                {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                if (int.TryParse(Console.ReadLine(), out int islem2))
                    if (islem2 == 2) { Console.Clear(); Tasima(); }
                }

            Console.WriteLine("Board'ı listelemek için (1), menüye dönmek için (2) tuşlayınız.");
            if(int.TryParse(Console.ReadLine(),out int islem3))
                if(islem3==1) { Console.Clear(); Listele(); }
        }

        public void Sil()
        {
            Console.WriteLine(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor. ");
            Console.WriteLine("Lütfen kart başlığını yazınız: ");
            string title = Console.ReadLine();
            int sayac = myList.Count();

            for (int i = 0; i < myList.Count(); i++)
                if (myList[i][0] == title)
                {
                    Console.WriteLine("'"+title+"' başlıklı kartı silmek istediğinize emin misiniz?");
                    Console.WriteLine("Silme işlemine devam etmek için (1), iptal etmek için (2) tuşlayınız.");
                    if (int.TryParse(Console.ReadLine(), out int islem))
                        if (islem == 1) myList.RemoveAt(i);
                    Console.WriteLine("İşleminiz başarıyla gerçekleşti!!");
                    Console.WriteLine("");
                }
                else sayac--;

            if (sayac==0)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                if (int.TryParse(Console.ReadLine(), out int islem2))
                    if (islem2 == 2) { Console.Clear(); Sil(); }
            }

            Console.WriteLine("Board'ı listelemek için (1), menüye dönmek için (2) tuşlayınız.");
            if (int.TryParse(Console.ReadLine(), out int islem3))
                if (islem3 == 1) { Console.Clear(); Listele(); }
        }
    }
}
    enum Editors { Admin = 1, Bora, Halil , Aytac, Umut, Belirsiz }
    enum Boyutlar { XS = 1, S, M, L, XL }
    enum Lines { TODO =1, InProgress, Done }



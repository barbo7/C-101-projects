using System;
using System.Collections.Generic;

namespace AlgoritmaSoruları
{
    class Program
    {
        static void Main(string[] args)
        {
            /*              ////////// Uygulama1 \\\\\\\\\\
                         
           Bir konsol uygulamasında kullanıcıdan pozitif bir sayı girmesini isteyin(n).
           Sonrasında kullanıcıdan n adet pozitif sayı girmesini isteyin.
           Kullanıcının girmiş olduğu sayılardan çift olanlar console'a yazdırın.
           */
            Uygulama1();
            /*              ////////// Uygulama2 \\\\\\\\\\
                           
           Bir konsol uygulamasında kullanıcıdan pozitif iki sayı girmesini isteyin (n, m). 
           Sonrasında kullanıcıdan n adet pozitif sayı girmesini isteyin. 
           Kullanıcının girmiş olduğu sayılardan m'e eşit yada tam bölünenleri console'a yazdırın.
           */
           Uygulama2();

            /*              ////////// Uygulama3 \\\\\\\\\\
                           
          Bir konsol uygulamasında kullanıcıdan pozitif bir sayı girmesini isteyin (n). 
          Sonrasında kullanıcıdan n adet kelime girmesi isteyin. 
          Kullanıcının girişini yaptığı kelimeleri sondan başa doğru console'a yazdırın.
          */
          Uygulama3();

            /*              ////////// Uygulama4 \\\\\\\\\\
                           
          Bir konsol uygulamasında kullanıcıdan bir cümle yazması isteyin. 
          Cümledeki toplam kelime ve harf sayısını console'a yazdırın.
            */
            Uygulama4();

        }
        static bool DogruMu(string sayi)
        {
            bool sonuc = int.TryParse(sayi, out int outsayi);
                if(sonuc)
                {
                if (outsayi > 0)
                    return true;
                else
                 {
                    Console.WriteLine("Lütfen pozitif bir sayı giriniz.");
                    return false;
                 }
                }
                else
                {
                Console.WriteLine("Lütfen sadecce pozitif bir sayı giriniz.");
                return false;
                }
        }
        static void Uygulama1()
        {
            List<int> CiftSayilar = new List<int>();
            Console.WriteLine("Kaç adet sayı girmek istiyorsunuz: ");
            string defa = Console.ReadLine();
            int n = int.Parse(defa);

            if (DogruMu(defa))
            { 
            for (int i = n; i > 0; i--)
            {
                Console.WriteLine("Lütfen {0} tane sayı daha giriniz", i);
                int a = int.Parse(Console.ReadLine());
                if (a % 2 == 0) CiftSayilar.Add(a);
            }
            Console.WriteLine("****");
            foreach (int i in CiftSayilar)
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
        static void Uygulama2()
        {
            Console.WriteLine("Bize 2 tane pozitif sayı giriniz: ");
            string md = Console.ReadLine(), nd = Console.ReadLine();
            int n = int.Parse(md), m = int.Parse(nd);
            List<int> sayilar = new List<int>();
            if (DogruMu(md) && DogruMu(nd))
            {
                for (int i = n; i > 0; i--)
                {
                    Console.WriteLine("Lütfen {0} tane sayı daha giriniz", i);
                    int sayi = int.Parse(Console.ReadLine());
                    if (sayi == m ||m %sayi ==0) sayilar.Add(sayi);
                }
                Console.WriteLine("****");
                foreach (int i in sayilar)
                    Console.WriteLine(i);
                Console.ReadKey();
            }
        }
        static void Uygulama3()
        {
            Console.WriteLine("Pozitif bir sayı giriniz: ");
            string nd = Console.ReadLine();
            int n = int.Parse(nd);

            if (DogruMu(nd))
            {
                string[] kelimeler = new string[n];
                for (int a = 0; a < n; a++)
                {
                    Console.WriteLine("{0} Kelime daha yazınız", n - a);
                    kelimeler[a] = Console.ReadLine();
                }
                Array.Reverse(kelimeler);
                Console.WriteLine("****");
                foreach (var a in kelimeler)
                Console.WriteLine(a);
                Console.ReadKey();
            }
        }
        static void Uygulama4()
        {
            Console.WriteLine("Bir cümle yazınız: ");
            string cümle = Console.ReadLine();
            int kelime = 0, harf = 0;
            kelime = cümle.Split(' ').Length;
            char[] harff = cümle.ToCharArray();
            harf = harff.Length - kelime+1;
            Console.WriteLine("****");
            Console.WriteLine("Cümledeki kelime sayısı = {0} ve harf sayısı = {1}", kelime, harf);
            Console.ReadKey();
        }
    }
}

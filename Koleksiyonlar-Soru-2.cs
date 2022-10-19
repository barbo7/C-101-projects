using System;

namespace Koleksiyonlar_soru_2
{
    class Program
    {
        static void Main(string[] args)
        {   ////                    Koleksiyonlar-Soru-2
            //Klavyeden girilen 20 adet sayının en büyük 3 tanesi ve en küçük 3 tanesi bulan,
            //her iki grubun kendi içerisinde ortalamalarını alan ve bu ortalamaları
            //ve ortalama toplamlarını console'a yazdıran programı yazınız. (Array sınıfını kullanarak yazınız.)
    
                    int[] sayilar = new int[20];
            int buyuk = 0, kucuk = 0;
            for (int i = 0; i < sayilar.Length; i++)
            {
                int a = 0;
                Console.WriteLine(sayilar.Length - i + " Adet Sayı giriniz: ");
                if (int.TryParse(Console.ReadLine(), out a))
                    sayilar[i] = a;

                else
                {
                    i--;
                    Console.WriteLine("Negatif veya numeric olmayan bir giriş yaptınız.");
                }
            }

            Array.Sort(sayilar);
            for (int i = 0; i < 3; i++)
                kucuk += sayilar[i];
            for (int i = sayilar.Length - 1; i > sayilar.Length - 4; i--)
                buyuk += sayilar[i];
            Console.WriteLine("En küçük 3 sayının ortalaması= " + (kucuk / 3) + " *** En büyük 3 sayının ortalaması= "+ (buyuk/3));
            Console.WriteLine("Ve ortalamaların ortalaması = " + ((kucuk / 3) + (buyuk / 3)) / 2);
            Console.ReadKey();
        }
    }
}

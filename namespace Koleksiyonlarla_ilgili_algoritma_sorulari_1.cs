using System;
using System.Collections;

namespace Koleksiyonlarla_ilgili_algoritma_sorulari_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Koleksiyonlar-Soru-1
            //Klavyeden girilen 20 adet pozitif sayının asal ve asal olmayan olarak 2 ayrı listeye atın. 
            //(ArrayList sınıfını kullanara yazınız.)

            ArrayList asal = new ArrayList();
            ArrayList asalsiz = new ArrayList();
            int[] sayilar = new int[20];
            //sayı alma bölümü
            for (int i = 0; i < sayilar.Length; i++)
            {
                int a = 0;
                Console.WriteLine(sayilar.Length-i + " Adet Sayı giriniz: ");
                if ((int.TryParse(Console.ReadLine(), out a)) && a > 0)
                    sayilar[i]=a;

                else
                {
                    i--;
                    Console.WriteLine("Negatif veya numeric olmayan bir giriş yaptınız.");
                }
                //asal kontrol bölümü
                for(int k=0;k<sayilar.Length;k++)
                {
                    int sayac = 0;
                    for (int b = 2; b < sayilar[k]; b++)
                        if (sayilar[k] % b == 0)
                            sayac++;

                    if (sayac == 0 && (asal.Contains(sayilar[k]))==false)
                        asal.Add(sayilar[k]);
                    else if(sayac>0 && (asalsiz.Contains(sayilar[k]))==false)
                        asalsiz.Add(sayilar[k]);
                }

            }
            //sıralama ve yazdırma bölümü
            asal.Sort();
            asalsiz.Sort();
            int asals = 0,asalsizs = 0;
            int asaltoplam = 0, asalsiztoplam = 0;

            asal.RemoveAt(0);
            Console.WriteLine("****Asal sayılar****");
            foreach (int i in asal)
            { Console.WriteLine(i);
                asals++;
                asaltoplam += i;
            }
            Console.WriteLine("Asal sayı adeti= " + asals + ", Ortlaması= " + (asaltoplam / asals));
            Console.WriteLine("****Asal olmayan sayılar****");
            foreach(int i in asalsiz)
            {
                Console.WriteLine(i);
                asalsizs++;
                asalsiztoplam += i;
            }
            Console.WriteLine("Asal olmayan sayı adeti= " + asalsizs + ", Ortlaması= " + (asalsiztoplam / asalsizs));
            Console.ReadKey();
        }
    }
}

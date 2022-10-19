using System;
using System.Linq;

namespace Koleksiyonlar-3
{
    class Program
    {
        static void Main(string[] args)
        {
            //              Koleksiyonlar-Soru-3
            //Klavyeden girilen cümle içerisindeki sesli harfleri bir dizi içerisinde saklayan ve 
            //dizinin elemanlarını sıralayan programı yazınız.
            string cumle = Console.ReadLine();
            char[] harf = cumle.ToCharArray();
            string cumledekiSesli = "";
            string[] sesliH = {"a","e","i","ı","o","ö","u","ü","A","E","İ","I","O","Ö","U","Ü"};
            for(int i=0;i<harf.Count();i++)
            {
                for(int a=0;a<sesliH.Length;a++)
                {
                    if (harf[i].ToString() == sesliH[a]) cumledekiSesli += sesliH[a] + " ";
                }
            }
            Console.WriteLine("*****");
            string[] sesliler = cumledekiSesli.Split(' ');
            foreach (var i in sesliler)
                Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}

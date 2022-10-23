using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
            Console.WriteLine("*****************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek ");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            if (int.TryParse(Console.ReadLine(), out int islem) && islem < 5 && islem > 0)
            {
                switch(islem)
                {
                    case 1:
                        break;
                }
            }
                
            else Console.WriteLine("Hatalı bir giriş yaptınız.");

        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine( " Marka    : " + item.BrandName);
                Console.WriteLine(" Modeli   : " + item.ModelYear);
                Console.WriteLine( " Fiyatı   : " + item.DailyPrice);
                Console.WriteLine( " Açıklama : " + item.Description);
                Console.WriteLine( " RenkCode : " + item.ColorId);
                Console.WriteLine("--------------------------------------**SMTcoder**");
                
            }

            Console.WriteLine(" Nazlı ile Yeni Projemiz");
            Console.WriteLine(" ---- TEBRİKLER --------");
        }
    }
}

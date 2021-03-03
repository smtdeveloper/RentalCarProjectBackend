using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            

            foreach (var item in carManager.GetAllByColorId(2))
            {
                //Console.WriteLine(item.ColorId);
                //Console.WriteLine(item.ColorName);

                Console.WriteLine("ID         : " + item.Id);
                Console.WriteLine(" Marka    : " + item.BrandId);
                Console.WriteLine(" RenkCode : " + item.ColorId);
                Console.WriteLine(" isim     : " + item.Name);
                Console.WriteLine(" Modeli   : " + item.ModelYear);
                Console.WriteLine(" Fiyatı   : " + item.DailyPrice);
                Console.WriteLine(" Açıklama : " + item.Description);

                Console.WriteLine("--------------------------------------**SMTcoder**");
                
            }

           
        }
    }
}

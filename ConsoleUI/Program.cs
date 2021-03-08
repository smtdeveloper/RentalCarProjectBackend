using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetailDtos();
            if (result.Success == true)
            {

                foreach (var item in result.Data )
                {

                    Console.WriteLine("-------------------------------"); 
                    Console.WriteLine(" Araba ismi : " + item.Name);
                    Console.WriteLine(" Renk       : " + item.ColorName);
                    Console.WriteLine(" Marka      : " + item.BrandName);
                    Console.WriteLine(" Fiyat      : " + item.DailyPrice);
                    Console.WriteLine(" Modeli     : " + item.ModelYear);
                    Console.WriteLine(" Açıklama   : " + item.Description);
                    Console.WriteLine("");
                    Console.WriteLine("Samet Akca");


                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }




        }
    }
}

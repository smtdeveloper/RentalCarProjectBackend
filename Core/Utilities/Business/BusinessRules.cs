using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)  // Params istediğin kadar IResult verebilirsin. //Logis = iş kuralları
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; // Hata döndürüyor :)
                }
            }
            return null;
        }
    }
}

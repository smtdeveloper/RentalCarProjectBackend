using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator : AbstractValidator<Car>  // FluentValidation'dan ekliyoruz bu classı.
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelName).NotEmpty();
            
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThan(50).When(c => c.BrandId == 1); // BrandId'si 1 olanlar en az günlük fiyatı  50 olmalı.


        }

    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
           
            RuleFor(c => c.CustomerName).NotEmpty();
            RuleFor(c => c.CustomerName).MinimumLength(2);
            
        }
    }
}

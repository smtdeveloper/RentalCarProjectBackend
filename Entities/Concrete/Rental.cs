﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Rental :IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }       // BradName
        public int CustomerId{ get; set; }  // isim ve soyisim
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}

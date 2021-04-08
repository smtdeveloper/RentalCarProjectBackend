﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? CardId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Total { get; set; }
    }
}

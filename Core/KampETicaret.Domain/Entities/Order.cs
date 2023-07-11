﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KampETicaret.Domain.Entities.Common;

namespace KampETicaret.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

       public ICollection<Product>? Products { get; set; }
        public Customer? Customer { get; set; }  
    }
}

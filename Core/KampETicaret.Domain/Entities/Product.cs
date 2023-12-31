﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KampETicaret.Domain.Entities.Common;

namespace KampETicaret.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }

        public IEnumerable<Order>? Orders { get; set; }
    }
}

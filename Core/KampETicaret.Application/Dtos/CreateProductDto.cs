using KampETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Dtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public int stock { get; set; }
        public long Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}

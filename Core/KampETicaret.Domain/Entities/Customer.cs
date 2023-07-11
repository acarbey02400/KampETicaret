using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KampETicaret.Domain.Entities.Common;

namespace KampETicaret.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}

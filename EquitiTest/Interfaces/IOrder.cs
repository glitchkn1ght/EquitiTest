using EquitiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquitiTest.Interfaces
{
    public interface IOrder
    {
        public IList<OrderItem>? OrderItems { get; set; }

        public Customer? Customer { get; set; }

        public DateTime? OrderDateTime { get; set; }
    }

}

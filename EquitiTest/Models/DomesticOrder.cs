using EquitiTest.Interfaces;
using EquitiTest.Models;

namespace EquitiTestUnitTests.Models
{
    public class DomesticOrder : IOrder
    {
        public IList<OrderItem> OrderItems { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderDateTime { get; set; }
    }
}

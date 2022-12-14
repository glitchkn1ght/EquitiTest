using EquitiTest.Interfaces;

namespace EquitiTest.Models
{
    public class OverSeaOrder : IOrder
    {
        public IList<OrderItem> OrderItems { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderDateTime { get; set; }
    }
}

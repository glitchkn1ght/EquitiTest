using EquitiTest.Models;

namespace EquitiTest.Interfaces
{
    public interface IOrder
    {
        public IList<OrderItem>OrderItems { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderDateTime { get; set; }
    }
}

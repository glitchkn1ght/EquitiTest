using EquitiTest.Interfaces;
using EquitiTest.Models;

namespace EquitiTest.Application
{
    public class CustomerRetrieval
    {
        public IEnumerable<Customer> GetCustomersWithOrders(IEnumerable<IOrder> orders)
        {
            IEnumerable<Customer> matchingCustomers = new List<Customer>();

            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly oneYearAgoToday = todaysDate.AddYears(-1);

            return (from 
                        order in orders
                    where 
                        DateOnly.FromDateTime(order.OrderDateTime) >= oneYearAgoToday
                        && order.Customer != null
                    select 
                        order.Customer).DistinctBy(x => x.CustomerId);
        }
    }
}

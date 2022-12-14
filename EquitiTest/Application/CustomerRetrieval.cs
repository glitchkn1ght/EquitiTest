using EquitiTest.Interfaces;
using EquitiTest.Models;

namespace EquitiTest.Application
{
    public class CustomerRetrieval
    {
        public IEnumerable<Customer> GetCustomersWithOrders(IEnumerable<IOrder> Orders)
        {
            List<Customer> matchingCustomers = new List<Customer>();

            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly oneYearAgoToday = todaysDate.AddYears(-1);

            foreach (IOrder order in Orders)
            {
                if (DateOnly.FromDateTime(order.OrderDateTime) >= oneYearAgoToday)
                {
                    if (!(order.Customer==null) && !matchingCustomers.Any(x => x.CustomerId == order.Customer.CustomerId))
                    {
                        matchingCustomers.Add(order.Customer);
                    }
                }
            }

            return matchingCustomers;
        }
    }
}

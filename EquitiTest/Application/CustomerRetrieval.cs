using EquitiTest.Interfaces;
using EquitiTest.Models;
using System.Security.Cryptography.X509Certificates;

namespace EquitiTest.Application
{
    public class CustomerRetrieval
    {
        public IEnumerable<Customer> GetCustomersWithOrders(IEnumerable<IOrder> Orders)
        {
            IEnumerable<Customer> matchingCustomers = new List<Customer>();

            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly oneYearAgoToday = todaysDate.AddYears(-1);

            return (from 
                        order in Orders
                    where 
                        DateOnly.FromDateTime(order.OrderDateTime) >= oneYearAgoToday
                        && order.Customer != null
                    select 
                        order.Customer).DistinctBy(x => x.CustomerId);
        }
    }
}

using EquitiTest.Interfaces;
using EquitiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquitiTest.Application
{
    public class CustomerRetrieval
    {
        public IUtility Utility;

        public CustomerRetrieval(IUtility utility)
        {
            this.Utility = utility ?? throw new ArgumentNullException(nameof(utility));
        }

        public List<Customer> GetCustomersWithOrders(IEnumerable<IOrder> Orders)
        {
            List<Customer> matchingCustomers = new List<Customer>();

            try
            {
                DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
                DateOnly oneYearAgoToday = this.Utility.GetOneYearAgoToday(todaysDate);

                foreach (IOrder order in Orders)
                {
                    if (order.OrderDateTime != null && DateOnly.FromDateTime((DateTime)order.OrderDateTime) >= oneYearAgoToday)
                    {
                        if (order.Customer != null && !matchingCustomers.Any(x => x.CustomerId == order.Customer?.CustomerId))
                        {
                            matchingCustomers.Add(order.Customer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //In reality would be a log. 
                Console.WriteLine(ex.Message.ToString());
            }

            return matchingCustomers;
        }
    }
}

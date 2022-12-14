using System.Linq;
using System.Runtime.CompilerServices;

namespace EquitiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<IOrder> orders = new List<IOrder>();

            orders.Add(new OverSeaOrder { })
        }

        public static List<Customer> GetCustomersWithOrders(IEnumerable<IOrder> Orders)
        {
            List<Customer> matchingCustomers = new List<Customer>();

            try
            {
                DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
                DateOnly oneYearAgoToday = GetOneYearAgoToday(todaysDate);

                foreach (IOrder order in Orders)
                {
                    if (DateOnly.FromDateTime(order.OrderDateTime) >= oneYearAgoToday && !matchingCustomers.Any(x => x.CustomerId == order.Customer.CustomerId))
                    {
                        matchingCustomers.Add(order.Customer);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return matchingCustomers;
        }
           


            


        public static DateOnly GetOneYearAgoToday(DateOnly dateOnly)
        {
            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly oneYearAgoToday;
            
            if (todaysDate.Day == 29 && todaysDate.Month == 2)
            {
                oneYearAgoToday = todaysDate.AddYears(-1).AddDays(-1);
            }

            else
            {
                oneYearAgoToday = todaysDate.AddYears(-1);
            }

            return oneYearAgoToday;
        }
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
    }

    public interface IOrder
    {
        public IList<OrderItem> OrderItems { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderDateTime { get; set; }
    }

    public class OverSeaOrder: IOrder
    {
        public IList<OrderItem>? OrderItems { get; set; }

        public Customer? Customer { get; set; }

        public DateTime OrderDateTime { get; set; }
    }

    public class DomesticOrder : IOrder
    {
        public IList<OrderItem>? OrderItems { get; set; }

        public Customer? Customer { get; set; }

        public DateTime OrderDateTime { get; set; }
    }
}
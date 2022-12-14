using EquitiTest.Application;
using EquitiTest.Interfaces;
using EquitiTest.Models;
using EquitiTestUnitTests.Models;

namespace EquitiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<IOrder> orders = new List<IOrder>();

                CustomerRetrieval customerRetrieval = new CustomerRetrieval();

                orders.Add(new DomesticOrder { OrderItems = new List<OrderItem> { new OrderItem { ItemId = 1, Quantity = 1 } }, Customer = new Customer { CustomerId = 1 }, OrderDateTime = DateTime.Parse("14/12/2021") });
                orders.Add(new OverSeaOrder { OrderItems = new List<OrderItem> { new OrderItem { ItemId = 2, Quantity = 2 } }, Customer = new Customer { CustomerId = 1 }, OrderDateTime = DateTime.Parse("15/12/2021") });
                orders.Add(new OverSeaOrder { OrderItems = new List<OrderItem> { new OrderItem { ItemId = 3, Quantity = 3 } }, Customer = new Customer { CustomerId = 2 }, OrderDateTime = DateTime.Parse("16/12/2021") });
                orders.Add(new DomesticOrder { OrderItems = new List<OrderItem> { new OrderItem { ItemId = 4, Quantity = 4 } }, Customer = new Customer { CustomerId = 3 }, OrderDateTime = DateTime.Parse("13/12/2021") });

                List<Customer> customers = customerRetrieval.GetCustomersWithOrders(orders).ToList();

                Console.WriteLine($"There are {customers.Count} distinct customers with orders in the past year");
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                //In reality would be a log. 
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
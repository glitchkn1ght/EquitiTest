using EquitiTest.Models;

namespace EquitiTestUnitTests.TestData
{
    public static class TestingData
    {
        public static List<OrderItem> GetOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem{ ItemId = 1, Quantity = 1},
                new OrderItem{ ItemId = 2, Quantity = 2},
                new OrderItem{ ItemId = 3, Quantity = 3},
            };
        }

        public static List<Customer> AllCustomers()
        {
            return new List<Customer>
            {
                new Customer{ CustomerId = 1},
                new Customer{ CustomerId = 2},
                new Customer{ CustomerId = 3}
            };
        }

    }
}

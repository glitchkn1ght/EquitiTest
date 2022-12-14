using EquitiTest.Application;
using EquitiTest.Interfaces;
using EquitiTest.Models;
using EquitiTestUnitTests.Models;
using EquitiTestUnitTests.TestData;

namespace EquitiTestUnitTests
{
    public class Tests
    {
        private List<IOrder> Orders = new List<IOrder>();
        private CustomerRetrieval CustomerRetrieval;

        [SetUp]
        public void Setup()
        {
            this.Orders = new List<IOrder>();
            this.CustomerRetrieval = new CustomerRetrieval();
        }

        [Test]
        public void WhenOrderWithinLastYear_ThenCustomerAddedToList()
        {
            OverSeaOrder overSeaOrder = new OverSeaOrder { Customer= TestingData.AllCustomers()[0], OrderItems = TestingData.GetOrderItems(), OrderDateTime = DateTime.Parse("14/12/2021") };

            this.Orders.Add(overSeaOrder);

            List<Customer> matchingCustomers = this.CustomerRetrieval.GetCustomersWithOrders(this.Orders).ToList();

            Assert.AreEqual(1, matchingCustomers.Count);
        }

        [Test]
        public void WhenOrderNotWithinLastYear_ThenCustomerNotAddedToList()
        {
            OverSeaOrder overSeaOrder = new OverSeaOrder { Customer = TestingData.AllCustomers()[0], OrderItems = TestingData.GetOrderItems(), OrderDateTime = DateTime.Parse("13/12/2021") };

            this.Orders.Add(overSeaOrder);

            List<Customer> matchingCustomers = this.CustomerRetrieval.GetCustomersWithOrders(this.Orders).ToList();

            Assert.AreEqual(0, matchingCustomers.Count);
        }

        [Test]
        public void WhenCustomerInSeveralOrders_ThenNoDuplicateCustomersInReturnedList()
        {
            OverSeaOrder overSeaOrder = new OverSeaOrder { Customer = TestingData.AllCustomers()[0], OrderItems = TestingData.GetOrderItems(), OrderDateTime = DateTime.Parse("15/12/2021") };
            DomesticOrder domesticOrder = new DomesticOrder { Customer = TestingData.AllCustomers()[0], OrderItems = TestingData.GetOrderItems(), OrderDateTime = DateTime.Parse("16/12/2021") };

            this.Orders.Add(overSeaOrder);
            this.Orders.Add(domesticOrder);

            List<Customer> matchingCustomers = this.CustomerRetrieval.GetCustomersWithOrders(this.Orders).ToList();

            Assert.AreEqual(1, matchingCustomers.Count);
        }

        [Test]
        public void WhenOrdersEmpty_ThenReturnEmptyList()
        {
            List<Customer> matchingCustomers = this.CustomerRetrieval.GetCustomersWithOrders(this.Orders).ToList();

            Assert.AreEqual(0, matchingCustomers.Count);
        }

        [Test]
        public void WhenOrderdateNull_ThenNoErrorThrown()
        {
            OverSeaOrder overSeaOrder = new OverSeaOrder { Customer = TestingData.AllCustomers()[0], OrderItems = TestingData.GetOrderItems()};
            this.Orders.Add(overSeaOrder);

            List<Customer> matchingCustomers = this.CustomerRetrieval.GetCustomersWithOrders(this.Orders).ToList();

            Assert.AreEqual(0, matchingCustomers.Count);
        }

        [Test]
        public void WhenOrderCustomerNull_ThenNoErrorThrown()
        {
            OverSeaOrder overSeaOrder = new OverSeaOrder {OrderItems = TestingData.GetOrderItems(), OrderDateTime = DateTime.Parse("15/12/2021") };
            this.Orders.Add(overSeaOrder);

            List<Customer> matchingCustomers = this.CustomerRetrieval.GetCustomersWithOrders(this.Orders).ToList();

            Assert.AreEqual(0, matchingCustomers.Count);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork6;
using System.Collections.Generic;

namespace HomeWork6Test
{
    [TestClass]
    public class OrderTest
    {
        OrderService testservice = new OrderService();
        OrderItem Good1 = new OrderItem(1, "Good1", 20, 30);
        OrderItem Good2 = new OrderItem(2, "Good2", 30, 40);
        OrderItem Good3 = new OrderItem(3, "Good3", 40, 50);

        [TestInitialize()]
        public void init()
        {
            Order order1 = new Order(1, "NewCustomer1", new List<OrderItem> { Good1, Good2, Good3 });
            Order order2 = new Order(2, "NewCustomer2", new List<OrderItem> { Good2, Good3 });
            Order order3 = new Order(3, "NewCustomer3", new List<OrderItem> { Good1, Good3 });
            testservice = new OrderService();
            testservice.AddOrder(order1);
            testservice.AddOrder(order2);
            testservice.AddOrder(order3);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            Order order4 = new Order(4, "NewCustomer4", new List<OrderItem> { Good1, Good2 });
            testservice.AddOrder(order4);
            Assert.AreEqual(4, testservice.orders.Count);
            CollectionAssert.Contains(testservice.orders, order4);
        }
        [TestMethod]
        public void ReMoveOrderTest()
        {
            testservice.ReMove(3);
            Assert.AreEqual(2, testservice.orders.Count);
        }
        [TestMethod()]
        public void QueryOrderByIdTest()
        {
            Order order2 = new Order(2, "NewCustomer2", new List<OrderItem> { Good2, Good3 });
            Order x = testservice.GetOrder(2);
            Assert.IsNotNull(x);
            Assert.AreEqual(order2, x);
            x = testservice.GetOrder(4);
            Assert.IsNull(x);
        }
        [TestMethod()]
        public void UpdateOrderTest()
        {
            Order order1 = new Order(1, "NewCustomer5", new List<OrderItem> { Good3 });
            testservice.UpdateOrder(order1);
            Assert.AreEqual(3, testservice.orders.Count);
            Order x = testservice.GetOrder(1);
            Assert.AreEqual("NewCustomer5", x.CustomerName);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OrderManager.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {


        [TestMethod()]
        [TestInitialize]
        public void AddOrderTest()
        {
            OrderService.AddOrder(new Order(0, "软件工程概论", 1, "法外狂徒张三", 114));
            OrderService.AddOrder(new Order(1, "数据库系统", 2, "匿名群友", 514));
            OrderService.AddOrder(new Order(2, "罗翔说刑法", 1, "罗翔", 43));
            OrderService.AddOrder(new Order(3, "计算机网络", 1, "法外狂徒张三", 233));
            OrderService.AddOrder(new Order(4, "热爱学习的贵龙", 10,
                new OrderDetails("软件工程概论", 1),
                new OrderDetails("Unity开发教程", 1),
                new OrderDetails("教你画像素画", 1)
            ));
        }


        [TestMethod()]
        public void QueryByIdTest()
        {
            var o = OrderService.QueryById(3);
            Assert.IsNotNull(o);
            Assert.AreEqual(new Order(3, "计算机网络", 1, "法外狂徒张三", 233), o);
        }

        [TestMethod()]
        public void QueryByNameTest()
        {
            string name = "软件工程概论";
            var result = OrderService.QueryByName(name);

            Assert.IsNotNull(result);
            foreach (var item in result)
            {
                Assert.IsTrue(item.Details.Any(o => o.ProductName == name));
            }

        }

        [TestMethod()]
        public void QueryByCustomerTest()
        {
            string name = "法外狂徒张三";
            var result = OrderService.QueryByCustomer(name);

            Assert.IsNotNull(result);
            foreach (var item in result)
            {
                Assert.AreEqual(item.CustomerName, name);
            }
        }

        [TestMethod()]
        public void QueryByAmountTest()
        {
            var result = OrderService.QueryByAmount(100, 500);

            Assert.IsNotNull(result);
            foreach (var item in result)
            {
                Assert.IsTrue(item.OrderAmount >= 100 && item.OrderAmount <= 500);
            }
        }



        [TestMethod()]
        public void EditOrderTest()
        {
            OrderService.EditOrder(new Order(3, "计算机网络", 2, null, 466));
            Assert.AreEqual(
                   new Order(3, "计算机网络", 2, "法外狂徒张三", 466),
                   OrderService.QueryById(3)
                   );
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService.DeleteOrder(3);
            OrderService.DeleteOrder(100);
            Assert.IsNull(OrderService.QueryById(3));
        }

        [TestMethod()]
        [TestCleanup]
        public void RemoveAllTest()
        {
            OrderService.RemoveAll();
        }

        [TestMethod()]
        public void ExportAndImportTest()
        {
            OrderService.Export("test.xml");
            Assert.IsTrue(File.Exists("test.xml"));
            OrderService.RemoveAll();
            OrderService.Import("test.xml");
        }
    }
}
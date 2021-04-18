using System;
using System.Collections.Generic;

namespace OrderManager
{
    class Program
    {
        static void Main(string[] args)
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

            OrderService.Export("a.xml");
            OrderService.RemoveAll();
            OrderService.Import("a.xml");

            Console.WriteLine("-------按价格查询， 按订单号排序-------");
            OrderService.QueryByAmount(100, decimal.MaxValue, (a, b) => a.OrderId - b.OrderId).Print();




        }
    }

    public static class OrderExtensions
    {
        public static void Print(this IEnumerable<Order> orders)
        {
            foreach (var item in orders)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

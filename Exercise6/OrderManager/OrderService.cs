using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderManager
{

    public static class OrderService
    {
        #region 上次作业写的代码

        private static List<Order> _orders = new List<Order>();
        #region 查询（默认排序）
        public static Order QueryById(int orderId)
            => QueryBy(o => o.OrderId == orderId).FirstOrDefault();
        public static IEnumerable<Order> QueryByName(string productName)
            => QueryBy(o =>
               o.Details.Where(d => d.ProductName == productName).Any()
            );
        public static IEnumerable<Order> QueryByCustomer(string customerName)
            => QueryBy(o => o.CustomerName == customerName);
        public static IEnumerable<Order> QueryByAmount(decimal minAmount, decimal maxAmount)
        {
            if (maxAmount < minAmount)
                throw new ArgumentException("最大值应该比最小值要大！");
            return QueryBy(o => o.OrderAmount >= minAmount && o.OrderAmount <= maxAmount);
        }
        private static IEnumerable<Order> QueryAll()
        {
            return from o in _orders
                   orderby o.OrderAmount
                   select o;
        }
        private static IEnumerable<Order> QueryBy(Predicate<Order> predicate)
        {

            if (predicate == null)
                throw new ArgumentException("参数不能为null");
            return from o in _orders
                   where predicate(o)
                   orderby o.OrderAmount
                   select o;
        }
        #endregion

        #region 查询（自定义排序）
        public static IEnumerable<Order> QueryByName(string productName, Comparison<Order> orderbyCompare)
            => QueryBy(o =>
                    o.Details.Where(d => d.ProductName == productName).Any()
                , orderbyCompare);
        public static IEnumerable<Order> QueryByCustomer(string customerName, Comparison<Order> orderbyCompare)
            => QueryBy(o => o.CustomerName == customerName, orderbyCompare);
        public static IEnumerable<Order> QueryByAmount(decimal minAmount, decimal maxAmount, Comparison<Order> orderbyCompare)
        {
            if (maxAmount < minAmount)
                throw new ArgumentException("最大值应该比最小值要大！");
            return QueryBy(o => o.OrderAmount >= minAmount && o.OrderAmount <= maxAmount, orderbyCompare);
        }

        private static IEnumerable<Order> QueryBy(Predicate<Order> predicate, Comparison<Order> orderbyCompare)
        {

            if (orderbyCompare == null || predicate == null)
                throw new ArgumentException("参数不能为null");
            return from o in _orders
                   where predicate(o)
                   orderby orderbyCompare
                   select o;
        }

        private static IEnumerable<Order> QueryAll(Comparison<Order> orderbyCompare)
        {
            return from o in _orders
                   orderby orderbyCompare
                   select o;
        }
        #endregion

        public static bool AddOrder(Order order)
        {
            if (order == null || order.Details == null)
                throw new ArgumentException("参数不能为null");
            //检查是否已经存在
            if (_orders.Where(o => o.OrderId == order.OrderId).Any())
            {
                return false;
            }

            _orders.Add(order);
            return true;
        }

        public static void EditOrder(Order order)
        {
            if (order == null)
                throw new ArgumentException("参数不能为null");

            var currentOrder = _orders.Where(o => o.OrderId == order.OrderId).FirstOrDefault();
            if (currentOrder == null)
                throw new InvalidOperationException("要编辑的订单不存在！");


            if (!string.IsNullOrEmpty(order.CustomerName))
                currentOrder.CustomerName = order.CustomerName;
            if (order.Details != null && order.Details.Length > 0)
                currentOrder.Details = order.Details;
            if (order.OrderAmount > 0)
                currentOrder.OrderAmount = order.OrderAmount;

        }

        public static void DeleteOrder(int orderId)
        {
            var currentOrder = _orders.Where(o => o.OrderId == orderId).FirstOrDefault();
            if (currentOrder == null)
                throw new InvalidOperationException("要删除的订单不存在！");

            _orders.Remove(currentOrder);

        }

        #endregion

        /// <summary>
        /// 全删了
        /// </summary>
        public static void RemoveAll()
        {
            _orders.Clear();
        }

        private static XmlSerializer _serializer = new XmlSerializer(typeof(Order[]), new[] { typeof(Order), typeof(OrderDetails) });

        public static void Export(string fileName)
        {
            using var output = File.OpenWrite(fileName);
            _serializer.Serialize(output, _orders.ToArray());

        }


        public static void Import(string fileName)
        {

            Import(fileName, false);

        }

        public static void Import(string fileName, bool removeCurrent)
        {

            if (!File.Exists(fileName))
                throw new InvalidOperationException("文件不存在");
            using var input = File.OpenRead(fileName);
            Order[] arr = _serializer.Deserialize(input) as Order[];
            if (arr == null)
                throw new InvalidOperationException("读取失败");
            if (removeCurrent)
            {
                _orders.Clear();
            }
            foreach (var o in arr)
            {
                AddOrder(o);
            }

        }


    }
}

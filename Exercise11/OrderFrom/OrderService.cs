using OrderManagerFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderManager
{

    public static class OrderService
    {




        public static IEnumerable<Order> QueryAll()
        {
            
            using (var _context = new OrdingDBContext())
            {
                return (from o in _context.Orders.Include(o => o.Details)
                       orderby o.OrderAmount
                       select o).ToList();
            }
        }


        public static bool AddOrder(Order order)
        {
            using (var _context = new OrdingDBContext())
            {
                if (order == null || order.Details == null)
                    throw new ArgumentException("参数不能为null");
                //检查是否已经存在
                if (_context.Orders.Where(o => o.OrderId == order.OrderId).Any())
                {
                    return false;
                }

                _context.Orders.Add(order);
                _context.Entry(order).State = EntityState.Added;
                _context.SaveChanges();
                return true; 
            }
        }

        public static void EditOrder(Order order)
        {
            if (order == null)
                throw new ArgumentException("参数不能为null");

            using (var _context = new OrdingDBContext())
            {
                var currentOrder = _context.Orders.Include(o => o.Details).Where(o => o.OrderId == order.OrderId).FirstOrDefault();
                if (currentOrder == null)
                    throw new InvalidOperationException("要编辑的订单不存在！");


                if (!string.IsNullOrEmpty(order.CustomerName))
                    currentOrder.CustomerName = order.CustomerName;
                if (order.Details != null && order.Details.Count > 0)
                    currentOrder.Details = order.Details;
                if (order.OrderAmount > 0)
                    currentOrder.OrderAmount = order.OrderAmount;

                _context.Entry(currentOrder).State = EntityState.Modified;
                _context.SaveChanges(); 
            }
        }

        public static void DeleteOrder(int orderId)
        {
            using (var _context = new OrdingDBContext())
            {
                var currentOrder = _context.Orders.Include(o => o.Details).Where(o => o.OrderId == orderId).FirstOrDefault();
                if (currentOrder == null)
                    throw new InvalidOperationException("要删除的订单不存在！");

                _context.Orders.Remove(currentOrder);
                _context.SaveChanges(); 
            }
        }


        /// <summary>
        /// 全删了
        /// </summary>
        public static void RemoveAll()
        {
            using (var _context = new OrdingDBContext())
            {
                _context.Orders.RemoveRange(_context.Orders.Include(o => o.Details).ToList());
                _context.SaveChanges(); 
            }
        }

        private static XmlSerializer _serializer = new XmlSerializer(typeof(Order[]), new[] { typeof(Order), typeof(OrderDetails) });

        public static void Export(string fileName)
        {
            using (var _context = new OrdingDBContext())
            {
                using (var output = File.OpenWrite(fileName))
                {
                    _serializer.Serialize(output, _context.Orders.Include(o => o.Details).ToArray());
                }
                _context.SaveChanges();
            }

        }


        public static void Import(string fileName)
        {

            Import(fileName, false);

        }

        public static void Import(string fileName, bool removeCurrent)
        {

            if (!File.Exists(fileName))
                throw new InvalidOperationException("文件不存在");
            Order[] arr = null;
            using (var input = File.OpenRead(fileName))
            {
                arr = _serializer.Deserialize(input) as Order[];
            }
            if (arr == null)
                throw new InvalidOperationException("读取失败");
            if (removeCurrent)
            {
                RemoveAll();
            }
            foreach (var o in arr)
            {
                AddOrder(o);
            }

        }

    }
}

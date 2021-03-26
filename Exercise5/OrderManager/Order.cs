using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManager
{
    public class Order
    {
        public Order()
        {

        }

        public Order(int orderId, string productName, int productNum, string customerName, decimal orderAmount)
        {
            OrderId = orderId;
            CustomerName = customerName;
            OrderAmount = orderAmount;
            Details = new[] { new OrderDetails(productName, productNum) };
        }

        public Order(int orderId, string customerName, decimal orderAmount, params OrderDetails[] details)
        {
            CustomerName = customerName;
            OrderAmount = orderAmount;
            OrderId = orderId;
            Details = details;
        }

        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 顾客名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 价格，是不是应该根据订单详情计算更好？
        /// 算了x偷懒
        /// </summary>
        public decimal OrderAmount { get; set; }

        public OrderDetails[] Details { get; set; }

        public override string ToString()
        {
            return $"订单号: {OrderId}, 订单价格: {OrderAmount}, 客户名称: {CustomerName}, 订单详情：[{string.Join<OrderDetails>(',', Details)}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class OrderDetails
    {

        public OrderDetails(string productName, int productNumber)
        {
            ProductName = productName;
            ProductNumber = productNumber;
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int ProductNumber { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   ProductName == details.ProductName &&
                   ProductNumber == details.ProductNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, ProductNumber);
        }

        public override string ToString()
        {
            return $"商品名称：{ProductName} 商品数量：{ProductNumber}";
        }


    }
}

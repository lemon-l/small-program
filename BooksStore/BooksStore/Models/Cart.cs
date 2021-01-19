using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        //添加
        public void AddItem(Books product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.books.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine() { books = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        ////点击数量+号或点击数量-号或自己输入一个值
        //public void IncreaseOrDecreaseOne(Books product, int quantity)
        //{
        //    CartLine line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
        //    if (line != null)
        //    {
        //        line.Quantity = quantity;
        //    }
        //}

        //移除
        public void RemoveLine(Books product)
        {
            lineCollection.RemoveAll(p => p.books.Id == product.Id);
        }

        //计算总价
        public decimal ComputeTotalPrice()
        {
            return lineCollection.Sum(p => (decimal)p.books.Price * p.Quantity);
        }


        //清空
        public void Clear()
        {
            lineCollection.Clear();
        }

        //获取
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public class CartLine
        {
            public Books books { get; set; }
            public int Quantity { get; set; }
        }

    }
}
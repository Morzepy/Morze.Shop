using System;
using System.Collections.Generic;
using System.Text;

namespace Morze.Shop.Db_context
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public virtual Client Client { get; set; }
    }
}

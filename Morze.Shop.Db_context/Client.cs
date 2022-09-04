using System;
using System.Collections.Generic;
using System.Text;

namespace Morze.Shop.Db_context
{
    public class Client
    {
        public int ID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientLogin { get; set; }
        public string ClientPassword { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

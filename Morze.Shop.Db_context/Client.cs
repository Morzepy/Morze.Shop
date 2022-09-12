using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Morze.Shop.Db_context
{
    public class Client
    {
        
        [Key] public int ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientLogin { get; set; }
        public string ClientPassword { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

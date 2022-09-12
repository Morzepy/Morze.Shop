using System.ComponentModel.DataAnnotations;


namespace Morze.Shop.Db_context
{
    public class Product
    {
        [Key] public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class HoadonbanResponse
    {
        public Guid Id { get; set; }
        public Guid IdCustomer { get; set; }
        public string NameCustomer{ get; set; }
        public string NameProduct { get; set; }
        public Guid IdProduct { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime BuyDate { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class HoadonbanRequest
    {
        public Guid Id { get; set; }
        public Guid IdCustomer { get; set; }
        [ForeignKey(nameof(IdCustomer))]
        public KhachHangRequest KhachHang { get; set; }      
        public Guid IdProduct { get; set; }
        [ForeignKey(nameof(IdProduct))]
        public ProductRequest Products { get; set; }

        [DataType(DataType.Date)]
        public DateTime BuyDate { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
    }
}

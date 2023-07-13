using BackendAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Entities
{
    public class Hoadonban
    {
        public Guid Id { get; set; }
        public Guid IdCustomer { get; set; }   
        public Guid IdProduct { get; set; }
        [DataType(DataType.Date)]
        public DateTime BuyDate { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
    }
}

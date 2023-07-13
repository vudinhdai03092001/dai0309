using BackendAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Entities
{
    public class DonDatHang
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        [ForeignKey(nameof(IdProduct))]
        public ProductRequest? Product { get; set; }
        public Guid? IdDonhang { get; set; }
        [ForeignKey(nameof(IdDonhang))]
        public Donhang? Donhang { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}

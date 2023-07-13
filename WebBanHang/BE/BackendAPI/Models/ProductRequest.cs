
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        public Guid IdCategory { get; set; }
        [ForeignKey(nameof(IdCategory))]
        public string NameProduct { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Image { get; set; }
        public string NameSupplier { get; set; }
        public string Describe { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2{ get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
        public string Parameter5 { get; set; }
        public string Parameter6 { get; set; }
        public string Parameter7 { get; set; }
        public string Amount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class KhachHangRequest
    {
        public Guid Id { get; set; }
        public string NameCustomer { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public string GioiTinh { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
    }
}

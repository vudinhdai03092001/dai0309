using BackendAPI.Entities;

namespace BackendAPI.Models
{
    public class DonhangRequest
    {
        public Donhang Donhang { get; set; }
        public List<DonDatHang> DonDatHang { get; set; }
    }
}

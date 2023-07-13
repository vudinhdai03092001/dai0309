namespace BackendAPI.Models
{
    public class HoadonnhapRequest
    {
        public Guid Id { get; set; }
        public string NamePersonnel { get; set; }
        public string NameProduct { get; set; }
        public DateTime BuyDate { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
    }
}

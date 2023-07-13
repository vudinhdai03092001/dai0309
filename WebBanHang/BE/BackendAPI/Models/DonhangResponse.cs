namespace BackendAPI.Models
{
    public class DonhangResponse
    {
        public Guid Id { get; set; }    
        public string NameProduct { get; set; }
        public string NameCustomer { get; set; }
        public int NumberPhone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }   
        public int Total { get; set; }
    
    }
}

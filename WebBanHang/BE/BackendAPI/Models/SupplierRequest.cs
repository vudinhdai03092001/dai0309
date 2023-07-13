namespace BackendAPI.Models
{
    public class SupplierRequest
    {
        public Guid Id { get; set; }
        public string NameSupplier { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        
    }
}

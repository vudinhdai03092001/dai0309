using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class BlogRequest
    {
        public Guid Id { get; set; }    
        public string NameBlog { get; set; }       
        public string Image { get; set; }       
        public string Describe1 { get; set; }
        public string Describe2 { get; set; }
        public string Describe3 { get; set; }

    }
}

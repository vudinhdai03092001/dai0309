using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class PersonnelRequest
    {
        public Guid Id { get; set; }
        public string NamePersonnel { get; set; }     

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public string Address{ get; set; }
        public string NumberPhone{ get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
    }
}

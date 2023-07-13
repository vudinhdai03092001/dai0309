using Microsoft.AspNetCore.Identity;

namespace BackendAPI.Entities
{
    public class AppRole : IdentityRole<Guid>
    { public string Description { get; set; }
    }
}

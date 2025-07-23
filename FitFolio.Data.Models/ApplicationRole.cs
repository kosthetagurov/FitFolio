using Microsoft.AspNetCore.Identity;

namespace FitFolio.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public bool AutoAssignable { get; set; }
    }
}

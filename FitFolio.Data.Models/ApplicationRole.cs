using Microsoft.AspNetCore.Identity;

namespace FitFolio.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool AutoAssignable { get; set; }
    }
}

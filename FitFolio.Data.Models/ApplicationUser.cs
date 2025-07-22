using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace FitFolio.Data.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class ApplicationUser : IdentityUser<Guid>
    {
        public Gender Gender { get; set; }
        public string? Bio { get; set; }
        public string? Avatar { get; set; }

        public string GetUserPublicDataJson()
        {
            return JsonSerializer.Serialize(new
            {
                UserName,
                Bio,
                Gender,
                Avatar,
                Email,
                PhoneNumber
            });
        }
    }
}

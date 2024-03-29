﻿using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitFolio.Data.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class ApplicationUser : IdentityUser
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

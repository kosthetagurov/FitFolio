using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool AutoAssignable { get; set; }
    }
}

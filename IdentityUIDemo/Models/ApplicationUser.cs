﻿using Microsoft.AspNetCore.Identity;

namespace IdentityUIDemo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

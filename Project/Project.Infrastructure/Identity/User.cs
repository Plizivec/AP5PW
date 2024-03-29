﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Project.Infrastructure.Identity
{
    /// <summary>
    /// Our User class which can be modified
    /// </summary>
    public class User : IdentityUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}


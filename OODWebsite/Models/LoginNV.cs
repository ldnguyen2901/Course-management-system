﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OODWebsite.Models
{
    public class LoginNV
    {
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
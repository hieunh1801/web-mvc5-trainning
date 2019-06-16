using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson_12___Login_with_Session.Models
{
    public class Account
    {
        [Display(Name = "Username")]
        public string Username
        {
            get;
            set;
        }

        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        public string[] Roles
        {
            get;
            set;
        }
    }
}
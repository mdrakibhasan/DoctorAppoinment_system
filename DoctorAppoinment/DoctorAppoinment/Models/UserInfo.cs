using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppoinment.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter user Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Enter full Name")]
        public string Password { get; set; }
    }
}
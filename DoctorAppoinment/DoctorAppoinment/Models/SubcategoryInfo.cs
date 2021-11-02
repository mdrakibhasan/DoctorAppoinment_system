using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppoinment.Models
{
    public class SubcategoryInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public CategoryInfo CategoryInfo { get; set; }
        public string CategoryInfoId { get; set; }
        public string Code { get; set; }
        public int? AddBy { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppoinment.Models
{
    public class DoctorInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Father Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Enter Mother Name")]
        public string MotherName { get; set; }

        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int DistrictInfoID { get; set; }
        public DistrictInfo DistrictInfo { get; set; }
        public int ThanaInfoId { get; set; }
        public ThanaInfo ThanaInfo { get; set; }
        public string Address { get; set; }
        public int CountryInfoId { get; set; }
        public CountryInfo CountryInfo { get; set; }
        [Required(ErrorMessage = "Enter Date of Birth")]
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public int? AddBy { get; set; }
        public DateTime? AddDate { get; set; }

        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
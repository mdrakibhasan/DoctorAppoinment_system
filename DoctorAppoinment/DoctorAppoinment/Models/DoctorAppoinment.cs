using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppoinment.Models
{
    public class DoctorAppoinment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Patient Name")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "Enter MobileNo")]
        public string MobileNo { get; set; }
        public string FatherName { get; set; }
        public string AppoinmentNo { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public string SerialNo { get; set; }
        public DoctorInfo DoctorInfo { get; set; }
        public int DoctorInfoId { get; set; }
        public string Address { get; set; }        
        public string Gender { get; set; }
        public string PatientHistory { get; set; }
        public int? AddBy { get; set; }
        public DateTime? AddDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
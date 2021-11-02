using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppoinment.Models
{
    public class medicineInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Father Name")]
        public MedicineGroup MedicineGroup { get; set; }
        public int MedicineGroupId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int? AddBy { get; set; }
        public DateTime? AddDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
using DoctorAppoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppoinment.Controllers
{
    public class DoctorInfoController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: DoctorInfo
        public ActionResult DoctorSetup()
        {
            var DistrictInfos = _db.DistrictInfoes.ToList();
            ViewBag.DistrictList = new SelectList(DistrictInfos, "Id", "Name");
            var Country = _db.CountryInfoes.ToList();
            ViewBag.Country = new SelectList(Country, "Id", "Name");
            var Thana = _db.ThanaInfoes.ToList();
            ViewBag.Thana = new SelectList(Thana, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult DoctorSetup(DoctorInfo model)
        {
            if (model.Id == 0)
            {
                //Save 
                _db.DoctorInfoes.Add(model);
                var isSave = _db.SaveChanges();
                //if (isSave > 0)
                //{
                //    ViewBag.Message = "Save Success";
                //}

                return View(); 
            }
            else
            {
                //Update
                var aDoctor = _db.DoctorInfoes.SingleOrDefault(c => c.Id == model.Id);

                aDoctor.Name = model.Name;
                aDoctor.Address = model.Address;
                aDoctor.Email = model.Email;
                aDoctor.DateofBirth = model.DateofBirth;
                aDoctor.FatherName = model.FatherName;
                aDoctor.MobileNo = model.MobileNo;
                aDoctor.ThanaInfoId = model.ThanaInfoId;
                aDoctor.CountryInfoId = model.CountryInfoId;
                

                var isUpdate = _db.SaveChanges();
                //if (isUpdate > 0)
                //{
                //    ViewBag.Message = "Update Success";
                //}

                return View();
            }
        }

    }
}
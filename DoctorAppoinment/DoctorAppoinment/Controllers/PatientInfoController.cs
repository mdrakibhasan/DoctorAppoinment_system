using DoctorAppoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppoinment.Controllers
{
    public class PatientInfoController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: PatientInfo
        public ActionResult PatientInformation()
        {
            var DistrictInfos = _db.DistrictInfoes.ToList();
            ViewBag.DistrictList = new SelectList(DistrictInfos, "Id", "Name");
            var Country = _db.CountryInfoes.ToList();
            ViewBag.Country = new SelectList(Country, "Id", "Name");
            var Thana = _db.ThanaInfoes.ToList();
            ViewBag.Thana = new SelectList(Thana, "Id", "Name");
            return View();
        }
    }
}
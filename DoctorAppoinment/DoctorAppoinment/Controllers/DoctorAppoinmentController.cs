
using DoctorAppoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppoinment.Controllers
{
    public class DoctorAppoinmentController : Controller
    {
        // GET: DoctorAppoinment
        ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult AppoinmentInfo()
        {
            var Doctor = _db.DoctorInfoes.ToList();
            ViewBag.DoctorInfo = new SelectList(Doctor, "Id", "Name");
            
            return View();
           
        }
    }
}
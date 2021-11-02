using DoctorAppoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorAppoinment.Controllers.Api
{
    public class PatientInfoController : ApiController
    {
        ApplicationDbContext _DbContext = new ApplicationDbContext();
        // GET: api/PatientInfo
        public IHttpActionResult Get()
        {
            var Patient = _DbContext.PatientInfoes.ToList();
            return Ok(Patient);
        }

        // GET: api/PatientInfo/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _DbContext.PatientInfoes.SingleOrDefault(a => a.Id == id);
                if (entity == null)
                    return NotFound();

                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/PatientInfo
        public IHttpActionResult Post([FromBody] PatientInfo db)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
                return BadRequest("Input Value Not Valid");
            _DbContext.PatientInfoes.Add(db);
            _DbContext.SaveChanges();
            return Ok(1);
        }

        // PUT: api/PatientInfo/5
        public IHttpActionResult Put(int id, [FromBody] PatientInfo db)
        {
            var aPatientInfo = _DbContext.PatientInfoes.SingleOrDefault(a => a.Id == id);
            if (aPatientInfo != null)
            {
                aPatientInfo.Name = db.Name;
                aPatientInfo.Address = db.Address;
                aPatientInfo.Email = db.Email;
                aPatientInfo.DateofBirth = db.DateofBirth;
                aPatientInfo.FatherName = db.FatherName;
                aPatientInfo.MobileNo = db.MobileNo;
                aPatientInfo.ThanaInfoId = db.ThanaInfoId;
                aPatientInfo.DistrictInfoId = db.DistrictInfoId;
                aPatientInfo.CountryInfoId = db.CountryInfoId;
                aPatientInfo.Gender = db.Gender;
                aPatientInfo.MotherName = db.MotherName;
                aPatientInfo.PatientHistory = db.PatientHistory;
                _DbContext.SaveChanges();
            }
            return Ok(1);
        }

        // DELETE: api/PatientInfo/5
        public IHttpActionResult Delete(int id)
        {
            var db = _DbContext.PatientInfoes.SingleOrDefault(a => a.Id == id);
            if (db == null)
            {
                return BadRequest();
            }
            _DbContext.PatientInfoes.Remove(db);
            _DbContext.SaveChanges();
            return Ok();
        }
    }
}

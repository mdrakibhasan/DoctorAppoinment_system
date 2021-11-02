using DoctorAppoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorAppoinment.Controllers.Api
{
    public class DoctorInfoController : ApiController
    {
        ApplicationDbContext _DbContext = new ApplicationDbContext();
       
        // GET: api/DoctorInfo
        public IHttpActionResult Get()
        {
            var DoctorInf = _DbContext.DoctorInfoes.ToList();
            return Ok(DoctorInf);
        }

        // GET: api/DoctorInfo/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _DbContext.DoctorInfoes.SingleOrDefault(a => a.Id == id);
                if (entity == null)
                    return NotFound();

                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/DoctorInfo
        public IHttpActionResult Post([FromBody] DoctorInfo db)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
                return BadRequest("Input Value Not Valid");
            _DbContext.DoctorInfoes.Add(db);
            _DbContext.SaveChanges();
            return Ok(1);
        }

        // PUT: api/DoctorInfo/5
        public IHttpActionResult Put(int id, [FromBody] DoctorInfo db)
        {
            var aDoctor = _DbContext.DoctorInfoes.SingleOrDefault(a => a.Id == id);
            if (aDoctor != null)
            {
                aDoctor.Name = db.Name;
                aDoctor.Address = db.Address;
                aDoctor.Email = db.Email;
                aDoctor.DateofBirth = db.DateofBirth;
                aDoctor.FatherName = db.FatherName;
                aDoctor.MobileNo = db.MobileNo;
                aDoctor.ThanaInfoId = db.ThanaInfoId;
                aDoctor.DistrictInfoID = db.DistrictInfoID;
                aDoctor.CountryInfoId = db.CountryInfoId;
                aDoctor.Gender = db.Gender;
                aDoctor.MotherName = db.MotherName;

                _DbContext.SaveChanges();
            }
            return Ok(1);
        }

        // DELETE: api/DoctorInfo/5
        public IHttpActionResult Delete(int id)
        {
            var db = _DbContext.DoctorInfoes.SingleOrDefault(a => a.Id == id);
            if (db == null)
            {
                return BadRequest();
            }
            _DbContext.DoctorInfoes.Remove(db);
            _DbContext.SaveChanges();
            return Ok();
        }
    }
}

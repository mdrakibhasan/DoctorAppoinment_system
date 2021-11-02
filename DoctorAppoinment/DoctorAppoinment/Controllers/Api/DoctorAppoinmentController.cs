using DoctorAppoinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorAppoinment.Controllers.Api
{
    public class DoctorAppoinmentController : ApiController
    {
        ApplicationDbContext _DbContext = new ApplicationDbContext();
        // GET: api/DoctorAppoinment
        public IHttpActionResult Get()
        {
            var Patient = _DbContext.DoctorAppoinments.ToList();
            return Ok(Patient);
        }
        [Route("api/DoctorAppoinment/SearchAutoComplete")]
        [HttpGet]
        public IHttpActionResult SearchAutoComplete(string pNumber)
        {
            try
            {
                var info = _DbContext.PatientInfoes.SingleOrDefault(c => c.Id.ToString() == pNumber);
                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("api/DoctorAppoinment/CountSerialNumber")]
        [HttpGet]
        public IHttpActionResult CountSerialNumber(string DoctorID, string Date)
        {
            DateTime dt = Convert.ToDateTime(Date);

            try
            {
                if (dt.Date < DateTime.Now.Date)
                {
                    return Ok(0);
                }
                int info = _DbContext.DoctorAppoinments.Count(c => c.DoctorInfoId.ToString() == DoctorID && c.AppoinmentDate == dt);
                return Ok(info + 1);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("api/DoctorAppoinment/Search")]
        [HttpGet]
        public IHttpActionResult Search(string query = null)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                var a = _DbContext.PatientInfoes.Where(c => c.Name.Contains(query) || c.MobileNo.Contains(query)).ToList();
                return Ok(a);
            }
            return Ok(0);
        }


        // GET: api/DoctorAppoinment/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _DbContext.DoctorAppoinments.SingleOrDefault(a => a.Id == id);
                if (entity == null)
                    return NotFound();

                entity.AppoinmentDate = entity.AppoinmentDate.Date;
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/DoctorAppoinment
        public IHttpActionResult Post([FromBody] DoctorAppoinment.Models.DoctorAppoinment db)
        {
            try
            {
                if (db.AppoinmentDate.Date < DateTime.Now.Date)
                {
                    return Ok(0);
                }
                ModelState.Remove("Id");
                if (!ModelState.IsValid)
                    return BadRequest("Input Value Not Valid");
                _DbContext.DoctorAppoinments.Add(db);
                _DbContext.SaveChanges();
                return Ok(1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/DoctorAppoinment/5
        public IHttpActionResult Put(int id, [FromBody] DoctorAppoinment.Models.DoctorAppoinment db)
        {
            var aDoctor = _DbContext.DoctorAppoinments.SingleOrDefault(a => a.Id == id);
            if (aDoctor != null)
            {
                aDoctor.PatientName = db.PatientName;
                aDoctor.Address = db.Address;
                aDoctor.SerialNo = db.SerialNo;
                aDoctor.AppoinmentNo = db.AppoinmentNo;
                aDoctor.PatientHistory = db.PatientHistory;
                aDoctor.MobileNo = db.MobileNo;
                aDoctor.DoctorInfoId = db.DoctorInfoId;
                aDoctor.Gender = db.Gender;
                aDoctor.Address = db.Address;
                aDoctor.FatherName = db.FatherName;

                _DbContext.SaveChanges();
            }
            return Ok(1);
        }

        // DELETE: api/DoctorAppoinment/5
        public IHttpActionResult Delete(int id)
        {
            var db = _DbContext.DoctorAppoinments.SingleOrDefault(a => a.Id == id);
            if (db == null)
            {
                return BadRequest();
            }
            _DbContext.DoctorAppoinments.Remove(db);
            _DbContext.SaveChanges();
            return Ok();
        }
    }
}

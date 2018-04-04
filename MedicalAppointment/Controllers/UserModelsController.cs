using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MedicalAppointment.Models;

namespace MedicalAppointment.Controllers
{
    public class UserModelsController : ApiController
    {
        private MedicalAppointmentContext db = new MedicalAppointmentContext();

        // GET: api/UserModels
        public IQueryable<UserModel> GetUserModels()
        {
            return db.UserModels;
        }

        // GET: api/UserModels/5
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult GetUserModel(int id)
        {
            UserModel userModel = db.UserModels.Find(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // PUT: api/UserModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserModel(int id, UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModel.UId)
            {
                return BadRequest();
            }

            db.Entry(userModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserModels
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PostUserModel(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserModels.Add(userModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userModel.UId }, userModel);
        }

        // DELETE: api/UserModels/5
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult DeleteUserModel(int id)
        {
            UserModel userModel = db.UserModels.Find(id);
            if (userModel == null)
            {
                return NotFound();
            }

            db.UserModels.Remove(userModel);
            db.SaveChanges();

            return Ok(userModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserModelExists(int id)
        {
            return db.UserModels.Count(e => e.UId == id) > 0;
        }
    }
}
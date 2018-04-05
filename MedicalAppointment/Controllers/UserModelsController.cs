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
using MedicalAppointment.DAL;

namespace MedicalAppointment.Controllers
{
    public class UserModelsController : ApiController
    {
        //private MedicalAppointmentContext db = new MedicalAppointmentContext();

        private IUserRepository userRepository;

        public UserModelsController()
        {
            this.userRepository = new UserRepository(new RepositoryContext());
        }
        // GET: api/UserModels
        public List<UserModel> GetUserModels()
        {
            List<UserModel> userList = userRepository.GetUsers();
            return userList; //db.UserModels;
        }

        // GET: api/UserModels/5
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult GetUserModel(int id)
        {
            UserModel userModel = userRepository.GetUserByID(id);//db.UserModels.Find(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // POST: api/UserModels
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult PostUserModel(UserModel userModel)
        {
            UserModel localUserModel = userRepository.GetUsers().Find(x => x.Nombre == userModel.Nombre);//db.UserModels.Find(id);
            if (localUserModel == null)
            {
                return NotFound();
            }

            return Ok(localUserModel);
            
        }


        /*TODO IMPLEMENT USER HANDLING*/
        //// PUT: api/UserModels/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUserModel(int id, UserModel userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != userModel.UId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(userModel).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/UserModels
        //[ResponseType(typeof(UserModel))]
        //public IHttpActionResult PostUserModel(UserModel userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.UserModels.Add(userModel);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = userModel.UId }, userModel);
        //}

        //// DELETE: api/UserModels/5
        //[ResponseType(typeof(UserModel))]
        //public IHttpActionResult DeleteUserModel(int id)
        //{
        //    UserModel userModel = db.UserModels.Find(id);
        //    if (userModel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserModels.Remove(userModel);
        //    db.SaveChanges();

        //    return Ok(userModel);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepository.Dispose();//db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*private bool UserModelExists(int id)
        {
            return db.UserModels.Count(e => e.UId == id) > 0;
        }*/
    }
}
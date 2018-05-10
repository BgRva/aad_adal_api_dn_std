using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AADx.Common.Models;
using AADx.TodoApi.DAL;

namespace AADx.TodoApi.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private UserContext db = new UserContext();

        // GET: api/User
        public IQueryable<UserProfile> GetUserProfiles()
        {
            logger.Debug("returning all ...");
            return db.UserProfiles;
        }

        // GET: api/User/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult GetUserProfile(long id)
        {
            logger.DebugFormat("Getting user {0}", id);
            UserProfile user = db.UserProfiles.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProfile(long id, UserProfile user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            logger.Debug(string.Format("Updating user with id {0}", user.Id));
            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // POST: api/User
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult PostUserProfile(UserProfile user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfiles.Add(user);
            db.SaveChanges();
            logger.Debug(string.Format("Created user with id {0}", user.Id));

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult DeleteUserProfile(long id)
        {
            UserProfile user = db.UserProfiles.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            logger.Debug(string.Format("Deleting user with id {0}", user.Id.ToString()));
            db.UserProfiles.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileExists(long id)
        {
            return db.UserProfiles.Count(e => e.Id == id) > 0;
        }
    }
}
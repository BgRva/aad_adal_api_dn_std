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
using AADx.Common.Models;
using AADx.EventsApi.DAL;

namespace AADx.EventsApi.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private EventContext db = new EventContext();
        
        [AllowAnonymous]
        // GET: api/Event
        public IQueryable<EventItem> GetEventItems()
        {
            logger.Debug("returning all ...");
            return db.EventItems;
        }

        // GET: api/Event/5
        [ResponseType(typeof(EventItem))]
        public IHttpActionResult GetEventItem(long id)
        {
            logger.DebugFormat("Getting eventItem {0}", id);
            EventItem eventItem = db.EventItems.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        // PUT: api/Event/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventItem(long id, EventItem eventItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventItem.Id)
            {
                return BadRequest();
            }

            logger.Debug(string.Format("Updating eventItem with id {0}", eventItem.Id));
            logger.Debug(string.Format("Updating eventItem with id {0}", eventItem.Description));
            db.Entry(eventItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(eventItem);
        }

        // POST: api/Event
        [ResponseType(typeof(EventItem))]
        public IHttpActionResult PostEventItem(EventItem eventItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventItems.Add(eventItem);
            db.SaveChanges();
            logger.Debug(string.Format("Created eventItem with id {0}", eventItem.Id));

            return CreatedAtRoute("DefaultApi", new { id = eventItem.Id }, eventItem);
        }

        // DELETE: api/Event/5
        [ResponseType(typeof(EventItem))]
        public IHttpActionResult DeleteEventItem(long id)
        {
            EventItem eventItem = db.EventItems.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            logger.Debug(string.Format("Deleting event with id {0}", eventItem.Id));
            db.EventItems.Remove(eventItem);
            db.SaveChanges();

            return Ok(eventItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventItemExists(long id)
        {
            return db.EventItems.Count(e => e.Id == id) > 0;
        }
    }
}
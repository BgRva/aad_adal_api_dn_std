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
    public class EventAnonController : ApiController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private EventContext db = new EventContext();

        // GET: api/EventAnon
        public IQueryable<EventItem> GetEventItems()
        {
            logger.Debug("returning all ...");
            return db.EventItems;
        }
    }
}
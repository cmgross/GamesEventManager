using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GamesEventManager.Models;
using ServiceStack.OrmLite;

namespace GamesEventManager.DataLayer
{
    public class EventService
    {
        public static IList<Event> GetAll()
        {
            IList<Event> events;
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                events = db.Select<Event>();
            }
            return events;
        }

        public static Event GetEvent(int id)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                return db.Select<Event>(e => e.Id == id).FirstOrDefault();
            }
        }

        public static void UpdateEvent(Event gameEvent)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                db.Update(gameEvent);
            }
        }

        public static IList<Event> GetFutureEvents()
        {
            IList<Event> events;
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                events = db.Select<Event>(e => e.EventDateTime > DateTime.Now);
            }
            return events;
        }

        public static void Create(Event gameEvent)
        {
            using (IDbConnection db = MvcApplication.DbFactory.OpenDbConnection())
            {
                db.Insert(gameEvent);
            }
        }
    }
}
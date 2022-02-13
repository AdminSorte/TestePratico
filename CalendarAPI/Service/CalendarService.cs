using CalendarAPI.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CalendarAPI.Models.CalendarAPIModel;
using static CalendarAPI.Models.CalendarModel;

namespace CalendarAPI.Service
{
    public class CalendarService : ICalendarServiceInterface
    {
        private CalendarDB _db;
        private IUserServiceInterface _users;
        public CalendarService(CalendarDB db, IUserServiceInterface userService)
        {
            this._db = db;
            this._users = userService;
        }

        public List<EventResponse> GetAllEventsUser(string token)
        {
            var email = this._users.GetEmailFromToken(token);
            var events = this._db.events.Where(x => x.useremail == email).Select(x => new EventResponse(x)).ToList();

            return events;

        }

        public Events CreateEvent(string token, EventsPost newEvent)
        {
            var userEmail = this._users.GetEmailFromToken(token);
            var calendar = GetCalendar(token, newEvent.calendar);
            var eventDB = new Events();
            eventDB.description = newEvent.description;
            eventDB.dateStart = newEvent.dateStart;
            eventDB.dateEnd = newEvent.dateEnd;
            eventDB.name = newEvent.name;
            eventDB.id = Guid.NewGuid().ToString();
            eventDB.useremail = userEmail;
            eventDB.calendar = calendar;
            this._db.Add(eventDB);
            this._db.SaveChanges();
            return eventDB;
        }

        public void DeleteEvent(string token, string id)
        {
            var email = this._users.GetEmailFromToken(token);
            var eventDelete = this._db.events.Where(x => (x.id == id) && (x.useremail == email)).FirstOrDefault();
            if (eventDelete is null)
            {
                throw new Exception("Not found");
            }
            this._db.Remove(eventDelete);
            this._db.SaveChanges();
        }

        public List<Events> GetAllEventsInInterval(string token, DateTime startDate)
        {
            var userEmail = this._users.GetEmailFromToken(token);
            var events = this._db.events.Where(x => (x.dateStart >= startDate) && (x.useremail == userEmail)).ToList();
            return events;
        }

        public List<Calendar> GetAllCalendars(string token)
        {
            var userEmail = this._users.GetEmailFromToken(token);
            var calendars = this._db.calendar.Where(x => x.useremail == userEmail).ToList();
            return calendars;
        }

        public Calendar GetCalendar(string token, string id)
        {
            var email = this._users.GetEmailFromToken(token);
            var calendar = this._db.calendar.Where(x => (x.useremail == email) & (x.id == id)).FirstOrDefault();
            return calendar;
        }

        public Calendar CreateCalendar(string token, string name)
        {
            var userEmail = this._users.GetEmailFromToken(token);
            var calendar = new Calendar { name = name, id = Guid.NewGuid().ToString(), useremail = userEmail };
            this._db.calendar.Add(calendar);
            this._db.SaveChanges();
            return calendar;
        }

        public Calendar CreateCalendar(string token, CalendarPost calendar)
        {
            var userEmail = this._users.GetEmailFromToken(token);
            var calendarDB = new Calendar { name = calendar.name, id = Guid.NewGuid().ToString(), useremail = userEmail };
            if (!(calendar.description is null))
            {
                calendarDB.description = calendar.description;
            }
            this._db.calendar.Add(calendarDB);
            this._db.SaveChanges();
            return calendarDB;
        }


        public void DeleteCalendar(string token, string id)
        {
            var email = this._users.GetEmailFromToken(token);
            var calendar = this._db.calendar.Where(x => (x.id == id) && (x.useremail == email)).FirstOrDefault();
            if (calendar is null)
            {
                throw new Exception("Not Found");
            }
            this._db.calendar.Remove(calendar);
            this._db.SaveChanges();
        }

        public EventResponse UpdateEvent(string token,string id, EventsUpdate eventUpdate)
        {
            var email = this._users.GetEmailFromToken(token);
            var eventDBUpdate = this._db.events.Where(x => (x.id == id) && (x.useremail == email)).FirstOrDefault();
            if(eventDBUpdate is null)
            {
                throw new Exception("Not Found");
            }
            if(!(eventUpdate.dateEnd is null))
            {
                eventDBUpdate.dateEnd = (DateTime)eventUpdate.dateEnd;
            }
            if (!(eventUpdate.dateStart is null))
            {
                eventDBUpdate.dateStart = (DateTime)eventUpdate.dateStart;
            }
            if (!(eventUpdate.name is null))
            {
                eventDBUpdate.name = eventUpdate.name;
            }
            if (!(eventUpdate.description is null))
            {
                eventDBUpdate.description = eventUpdate.description;
            }

            this._db.events.Update(eventDBUpdate);
            this._db.SaveChanges();
            return new EventResponse(eventDBUpdate);

        }

        public Calendar UpdateCalendar(string token,string id, CalendarUpdate calendar)
        {
            var email = this._users.GetEmailFromToken(token);
            var calendarDBUpdate = this._db.calendar.Where(x => (x.id == id) && (x.useremail == email)).FirstOrDefault();
            if (calendarDBUpdate is null)
            {
                throw new Exception("Not Found");
            }
            if (!(calendar.name is null))
            {
                calendarDBUpdate.name = calendar.name;
            }
            if (!(calendar.description is null))
            {
                calendarDBUpdate.description = calendar.description;
            }

            this._db.calendar.Update(calendarDBUpdate);
            this._db.SaveChanges();
            return calendarDBUpdate;
        }
    }


    public interface ICalendarServiceInterface
    {
        List<EventResponse> GetAllEventsUser(string token);
        Events CreateEvent(string token, EventsPost newEvent);
        void DeleteEvent(string token, string id);
        List<Events> GetAllEventsInInterval(string token, DateTime startDate);
        Calendar GetCalendar(string token, string id);
        Calendar CreateCalendar(string token, string name);
        void DeleteCalendar(string token, string id);
        Calendar CreateCalendar(string token, CalendarPost calendar);
        List<Calendar> GetAllCalendars(string token);
        EventResponse UpdateEvent(string token,string id, EventsUpdate eventUpdate);

        Calendar UpdateCalendar(string token, string id,  CalendarUpdate calendar);

    }
}

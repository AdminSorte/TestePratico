using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CalendarAPI.Models.CalendarModel;

namespace CalendarAPI.Service
{
    public class CalendarService
    {
    }


    public interface ICalendarServiceInterface
    {
        List<Events> GetAllEventsUser(string token);
        Events CreateEvent(string token, Events newEvent);
        void DeleteEvent(string token, string id);
        List<Events> GetAllEventsInInterval(string token, DateTime startDate);
        Calendar GetCalendar(string token, string id);
        Calendar CreateCalendar(string token, string name);
        void DeleteCalendar(string token, string id);
        Calendar CreateCalendar(string token, Calendar calendar);
        List<Calendar> GetAllCalendars(string token);

    }
}

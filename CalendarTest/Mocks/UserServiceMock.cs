using System;
using System.Collections.Generic;
using System.Text;
using static CalendarAPI.Models.CalendarAPIModel;

namespace CalendarTest.Mocks
{
    public class UserServiceMock
    {

        public static List<EventResponse> GetEventDependUser(string token)
        {
            if(token.Replace("Bearer","").Trim() == "0.0.0.1")
            {
                var eventFake = new EventResponse() { id = "0.0.0.1" };
                var events = new List<EventResponse>();
                events.Add(eventFake);
                return events;
            }
            return new List<EventResponse>();
        }

        public static List<EventResponse> GetFailDependUser(string token)
        {
            if (!(token.Replace("Bearer", "").Trim() == "0.0.0.1"))
            {
                var eventFake = new EventResponse() { id = "0.0.0.1" };
                var events = new List<EventResponse>();
                events.Add(eventFake);
                return events;
            }
            throw new Exception("Error");
        }
    }
}

using CalendarAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CalendarAPI.Models.CalendarAPIModel;

namespace CalendarAPI.Controllers
{
    [Route("api/calendar")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CalendarController : Controller
    {

        private readonly ICalendarServiceInterface calendarService;

        public CalendarController(ICalendarServiceInterface calendarService)
        {
            this.calendarService = calendarService;
        }

        [HttpPost("calendar")]
        public async Task<ActionResult> CreateCalendar([FromBody] CalendarPost calendar)
        {
            var newCalendar = calendarService.CreateCalendar(Request.Headers["Authorization"], calendar);
            return Ok(JsonConvert.SerializeObject(newCalendar));
        }

        [HttpPost("events")]
        public async Task<ActionResult> CreateEvent([FromBody] EventsPost newEvent)
        {
            var eventDB = calendarService.CreateEvent(Request.Headers["Authorization"], newEvent);
            return Ok(JsonConvert.SerializeObject(eventDB));
        }

        [HttpGet("calendar")]
        public async Task<ActionResult> GetCalendars()
        {
            var calendars = calendarService.GetAllCalendars(Request.Headers["Authorization"]);
            return Ok(JsonConvert.SerializeObject(calendars));
        }

        [HttpGet("calendar/unique/{id}")]
        public async Task<ActionResult> GetCalendar(string id)
        {
            var calendarDB = calendarService.GetCalendar(Request.Headers["Authorization"], id);
            return Ok(JsonConvert.SerializeObject(calendarDB));
        }



        [HttpGet("events")]
        public async Task<ActionResult> GetEvents()
        {
            var eventDB = calendarService.GetAllEventsUser(Request.Headers["Authorization"]);
            return Ok(eventDB);
        }

        [HttpGet("events/filter")]
        public async Task<ActionResult> GetEventFilter(DateTime starDate)
        {
            var eventDB = calendarService.GetAllEventsInInterval(Request.Headers["Authorization"], starDate);
            return Ok(JsonConvert.SerializeObject(eventDB));
        }

        [HttpDelete("calendar/{id}")]
        public async Task<ActionResult> DeleteCalendar(string id)
        {
            calendarService.DeleteCalendar(Request.Headers["Authorization"], id);
            return Ok();
        }
        [HttpDelete("events/{id}")]
        public async Task<ActionResult> DeleteEvent(string id)
        {
            calendarService.DeleteEvent(Request.Headers["Authorization"], id);
            return Ok();
        }

        [HttpPut("calendar/{id}")]
        public async Task<ActionResult> UpdateCalendar(string id,[FromBody]CalendarUpdate calendar)
        {
            var newCalendar = calendarService.UpdateCalendar(Request.Headers["Authorization"], id, calendar);
            return Ok(newCalendar);
        }
        [HttpPut("events/{id}")]
        public async Task<ActionResult> UpdateEvent(string id ,[FromBody]EventsUpdate eventUpdate)
        {
            var newEvent = calendarService.UpdateEvent(Request.Headers["Authorization"], id, eventUpdate);
            return Ok(newEvent);
        }



    }
}

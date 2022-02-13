using CalendarAPI.Controllers;
using CalendarAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CalendarAPI.Models.CalendarAPIModel;

namespace CalendarTest
{
    public class Tests
    {

        private DefaultHttpContext _http;
        [SetUp]
        public void Setup()
        {
            var httpContext = new DefaultHttpContext(); // DefaultHttpContext class is part of Microsoft.AspNetCore.Http namespace
            httpContext.Request.Headers.Add("Authorization", "0.0.0.1");
            _http = httpContext;
        }

        [Test]
        public async Task TestSimpleGetEvent()
        {
            var mockRepo = new Mock<ICalendarServiceInterface>();
            mockRepo.Setup(repo => repo.GetAllEventsUser(It.IsAny<string>())).Returns<string>((a) => new System.Collections.Generic.List<EventResponse>());
            var controller = new CalendarController(mockRepo.Object);
            controller.ControllerContext.HttpContext = this._http;
            IActionResult result = await controller.GetEvents();
            OkObjectResult okResult = (OkObjectResult)result;
            var events = (List<EventResponse>)okResult.Value;
            Assert.IsTrue(events.Count() == 0);
           
            
        }
    }
}
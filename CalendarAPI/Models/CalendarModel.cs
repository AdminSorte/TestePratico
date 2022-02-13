using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static CalendarAPI.Models.CalendarModel;

namespace CalendarAPI.Models
{
    public class CalendarModel
    {
        [Table("calendar")]
        public class Calendar
        {
            [Column("name")]
            [Required]
            public string name { get; set; }
            [Column("description")]
            public string description { get; set; }
            [Required]
            public string useremail { get; set; }
            [Key]
            public string id { get; set; }

        }

        [Table("events")]
        public class Events
        {
            [Column("name")]
            [Required]
            public string name { get; set; }
            [Key]
            [Column("id")]
            public string id { get; set; }
            [Column(TypeName = "varchar(200)")]
            public string description { get; set; }
            [Required]
            public string useremail { get; set; }
            [Required]
            public Calendar calendar { get; set; }
            [Column(TypeName = "Date")]
            public DateTime dateStart { get; set; }
            [Column(TypeName = "Date")]
            public DateTime dateEnd { get; set; }
        }

        [Table("share_events")]
        public class EventsShare
        {
            public Events events { get; set; }
            public string id { get; set; }
            public string useremailOwner { get; set; }
            public string useremailShare { get; set; }

        }
    }


    public class CalendarAPIModel
    {
        public class CalendarPost
        {
            [Required]
            public string name { get; set; }
            public string description { get; set; }
        }

        public class CalendarUpdate
        {
            public string name { get; set; } = null;
            public string description { get; set; } = null;
        }

        public class EventsPost
        {
            [Required]
            public string name { get; set; }
            public string description { get; set; }
            [Required]
            public string calendar { get; set; }
            [Required]
            public DateTime dateStart { get; set; } = DateTime.Now;
            [Required]
            public DateTime dateEnd { get; set; } = DateTime.Now.AddHours(2);
        }

        public class EventsUpdate
        {
            public string name { get; set; } = null;
            public string description { get; set; } = null;
            public DateTime? dateStart { get; set; } = null;
            public DateTime? dateEnd { get; set; } = null;
        }


        public class EventResponse
        {
            public string name { get; set; }
            public string description { get; set; }

            public string calendarId { get; set; }

            public DateTime dateStart { get; set; }

            public DateTime dateEnd { get; set; }

            public string id { get; set; }

            public EventResponse(Events ev)
            {
                this.name = ev.name;
                this.description = ev.description;
                this.calendarId = ev.calendar?.id;
                this.dateStart = ev.dateStart;
                this.dateEnd = ev.dateEnd;
                this.id = ev.id;

            }

            public EventResponse()
            {

            }
        }


    }

}

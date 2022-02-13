using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

}

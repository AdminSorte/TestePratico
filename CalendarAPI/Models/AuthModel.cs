using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Models
{
    public class AuthModel
    {
        public string email { get; set; }
        public string password { get; set; }

    }


    public class TokenResponse
    {
        public string token { get; }
        public string typeToken { get; }

        public TokenResponse(string token)
        {
            this.token = token;
            typeToken = "Bearer";
        }
    }


    [Table("users")]
    public class User
    {
        [Required]
        [Column("nome")]
        public string username { get; set; }
        [Required]
        [Column("senha")]
        public string password { get; set; }
        [Key]
        [Column("email")]
        public string email { get; set; }
        [Column(TypeName = "Date")]
        [Required]
        public DateTime dateCreated { get; set; }
    }


    public class UserCreate
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}

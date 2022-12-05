using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IdentityNum { get; set; }
        public int Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
    }
}

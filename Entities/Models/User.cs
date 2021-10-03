using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public int Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

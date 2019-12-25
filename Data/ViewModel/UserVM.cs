using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Department { get; set; }
        public int Manager { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModel
{
    public class UserVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Department { get; set; }
        public string Manager { get; set; }
    }
}

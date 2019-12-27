using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public class Authorization
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Authorization() { }

        public Authorization(AuthorizationVM authorizationVM)
        {
            this.Username = authorizationVM.Username;
            this.Password = authorizationVM.Password;
        }
        public void Update(AuthorizationVM authorizationVM)
        {
            this.Username = authorizationVM.Username;
            this.Password = authorizationVM.Password;
        }
    }
}

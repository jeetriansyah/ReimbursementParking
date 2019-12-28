using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IAuthorizationRepository
    {
        IEnumerable<Authorization> Get();
        Authorization Get(string Id);
        int Create(AuthorizationVM authorizationVM);
        int Update(string Id, AuthorizationVM authorizationVM);
        int Delete(string Id);
        Authorization Get(AuthorizationVM authorizationVM);
        Authorization Gets(string Email, string Password);
    }
}

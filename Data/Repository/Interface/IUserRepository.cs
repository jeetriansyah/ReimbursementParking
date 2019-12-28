using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(string Id);        
        int Create(UserVM userVM);
        int Update(string Id,UserVM userVM);
        int Delete(string Id);
        User Get(UserVM userVM);
    }
}

using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Get();
        User Get(string Id);
        int Create(UserVM userVM);
        int Update(string Id, UserVM userVM);
        int Delete(string Id);
        User Get(UserVM userVM);
    }
}

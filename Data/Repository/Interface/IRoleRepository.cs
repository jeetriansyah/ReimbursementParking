using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> Get();
        Role Get(int Id);
        int Create(RoleVM roleVM);
        int Update(int Id, RoleVM roleVM);
        int Delete(int Id);
    }
}

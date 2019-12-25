using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public int Create(RoleVM roleVM)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Get()
        {
            throw new NotImplementedException();
        }

        public Role Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, RoleVM roleVM)
        {
            throw new NotImplementedException();
        }
    }
}

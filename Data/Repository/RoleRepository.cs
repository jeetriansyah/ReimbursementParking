using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        MyContext myContext = new MyContext();

        public int Create(RoleVM roleVM)
        {
            var role = myContext.Roles.Where(r => r.RoleName == roleVM.RoleName);
            var result = 0;
            if (role != null)
            {
                var push = new Role(roleVM);
                myContext.Roles.Add(push);
                return myContext.SaveChanges();
            }
            return result;
        }

        public int Delete(int Id)
        {
            var delete = myContext.Roles.Find(Id);
            if (delete != null)
            {
                delete.IsDelete = true;
                delete.DeleteDate = DateTimeOffset.Now;
            }
            return myContext.SaveChanges();
        }

        public IEnumerable<Role> Get()
        {
            return myContext.Roles.Where(r => r.IsDelete == false).ToList().OrderByDescending(r => r.Id);
        }

        public Role Get(int Id)
        {
            return myContext.Roles.Find(Id);
        }

        public int Update(int Id, RoleVM roleVM)
        {
            var result = 0;
            var update = myContext.Roles.Find(Id);
            update.Update(roleVM);
            result = myContext.SaveChanges();
            return result;
        }
    }
}

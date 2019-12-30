using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        MyContext myContext = new MyContext();
        public int Create(UserVM userVM)
        {
            var user = myContext.Users.Where(u => u.FirstName.ToLower() == userVM.FirstName.ToLower() || u.LastName.ToLower() == userVM.LastName.ToLower());
            var result = 0;
            if (user != null)
            {
                var push = new User(userVM);
                push.Role = myContext.Roles.Where(r => r.Id == userVM.Role).FirstOrDefault();
                push.Department = myContext.Departments.Where(d => d.Id == userVM.Department).FirstOrDefault();
                push.Manager = myContext.Users.Where(m => m.Id == userVM.Manager).FirstOrDefault();
                myContext.Users.Add(push);
                return myContext.SaveChanges();
            }
            return result;
            //throw new NotImplementedException();
        }

        public int Delete(string Id)
        {
            var delete = myContext.Users.Find(Id);
            if (delete != null)
            {
                delete.IsDelete = true;
                delete.DeleteDate = DateTimeOffset.Now;
            }
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            var sup = myContext.Users.Include("Role").Include("Department").Include(u=>u.Manager).Where(i => i.IsDelete == false).ToList();
            return sup;
            //return myContext.Users.ToList();
            //throw new NotImplementedException();
        }

        public User Get(string Id)
        {
            return myContext.Users.Find(Id);
            //throw new NotImplementedException();
        }

        public User Get(UserVM userVM)
        {
            //return myContext.Users.Where(u => u.Username == userVM.Username && u.Password == userVM.Password && u.IsDelete == false).FirstOrDefault();
            return myContext.Users.FromSql($"call SP_UserLogin({userVM.Email},{userVM.Password})").SingleOrDefault();
        }

        //public int Update(int Id, UserVM userVM)
        //{
        //    var update = myContext.Users.Find(Id);
        //    update.Role = myContext.Roles.Where(r => r.Id == userVM.Role).FirstOrDefault();
        //    update.Department = myContext.Departments.Where(d => d.Id == userVM.Department).FirstOrDefault();
        //    update.Update(userVM);
        //    return myContext.SaveChanges();
        ////    throw new NotImplementedException();
        //}

        public int Update(string Id, UserVM userVM)
        {
            var update = myContext.Users.Find(Id);
            update.Role = myContext.Roles.Where(r => r.Id == userVM.Role).FirstOrDefault();
            update.Department = myContext.Departments.Where(d => d.Id == userVM.Department).FirstOrDefault();
            update.Manager = myContext.Users.Where(m => m.Id == userVM.Manager).FirstOrDefault();
            update.Update(userVM);
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}

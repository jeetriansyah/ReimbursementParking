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
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            return myContext.Users.ToList();
            //throw new NotImplementedException();
        }

        public User Get(int Id)
        {
            throw new NotImplementedException();
        }

        public User Get(UserVM userVM)
        {
            //return myContext.Users.Where(u => u.Username == userVM.Username && u.Password == userVM.Password && u.IsDelete == false).FirstOrDefault();
            return myContext.Users.FromSql($"call SP_UserLogin({userVM.Email},{userVM.Password})").SingleOrDefault();
        }

        public int Update(int Id, UserVM userVM)
        {
            throw new NotImplementedException();
        }
    }
}

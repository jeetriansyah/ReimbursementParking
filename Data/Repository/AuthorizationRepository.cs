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
    public class AuthorizationRepository : IAuthorizationRepository
    {
        MyContext myContext = new MyContext();

        public int Create(AuthorizationVM authorizationVM)
        {
            var auth = myContext.Authorizations.Where(a => a.Email.ToLower() == authorizationVM.Email);
            var result = 0;
            if (auth != null)
            {
                var push = new Authorization(authorizationVM);
                myContext.Authorizations.Add(push);
                return myContext.SaveChanges();
            }
            return result;
            //throw new NotImplementedException();
        }

        public int Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Authorization> Get()
        {
            return myContext.Authorizations.ToList();
            //throw new NotImplementedException();
        }

        public Authorization Get(string Id)
        {
            throw new NotImplementedException();
        }

        public Authorization Get(AuthorizationVM authorizationVM)
        {
            return myContext.Authorizations.Where(a => a.Email == authorizationVM.Email && a.Password == authorizationVM.Password).FirstOrDefault();
            //throw new NotImplementedException();
        }

        public Authorization Gets(string Email, string Password)
        {
            return myContext.Authorizations.FromSql($"call SP_AuthLogin({Email},{Password})").SingleOrDefault();
            //return myContext.Authorizations.Where(a => a.Email == authorizationVM.Email && a.Password == authorizationVM.Password).FirstOrDefault();
            throw new NotImplementedException();
        }

        public int Update(string Id, AuthorizationVM authorizationVM)
        {
            var result = 0;
            var update = myContext.Authorizations.Find(Id);
            update.Update(authorizationVM);
            result = myContext.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }
    }
}

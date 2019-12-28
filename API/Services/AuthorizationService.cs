using API.Services.Interface;
using Data.Model;
using Data.Repository;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IAuthorizationRepository _authorizationRepository = new AuthorizationRepository();

        public AuthorizationService() { }

        public AuthorizationService(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

        public int Create(AuthorizationVM authorizationVM)
        {
            if (string.IsNullOrWhiteSpace(authorizationVM.Email))
            {
                return 0;
            }
            else
            {
                return _authorizationRepository.Create(authorizationVM);
            }
            throw new NotImplementedException();
        }

        public int Delete(string Id)
        {
            //if (string.IsNullOrWhiteSpace(Id))
            //{
            //    return 0;
            //}
            //else
            //{
            //    return _authorizationRepository.Delete(Id);
            //}
            throw new NotImplementedException();
        }

        public IEnumerable<Authorization> Get()
        {
            //throw new NotImplementedException();
            return _authorizationRepository.Get();
        }

        public Authorization Get(string Id)
        {
            throw new NotImplementedException();
            //return _authorizationRepository.Get(Id);
        }

        public Authorization Get(AuthorizationVM authorizationVM)
        {
            return _authorizationRepository.Get(authorizationVM);
            //throw new NotImplementedException();
        }

        public Authorization Gets(string Email, string Password)
        {
            return _authorizationRepository.Gets(Email, Password);
            //throw new NotImplementedException();
        }

        public int Update(string Id, AuthorizationVM authorizationVM)
        {
            //if (string.IsNullOrWhiteSpace(authorizationVM.Email))
            //{
            //    return 0;
            //}
            //else
            //{
            //    return _authorizationRepository.Update(Id, authorizationVM);
            //}
            throw new NotImplementedException();
        }
    }
}

using API.Services.Interface;
using Data.Model;
using Data.Repository;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Data.Context;

namespace API.Services
{
    public class UserService : IUserService
    {
        //MyContext myContext = new MyContext();
        private IUserRepository _userRepository = new UserRepository();

        public UserService() { }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Create(UserVM userVM)
        {
            if (string.IsNullOrWhiteSpace(userVM.FirstName) || string.IsNullOrWhiteSpace(userVM.LastName) || string.IsNullOrWhiteSpace(userVM.Role.ToString()) || string.IsNullOrWhiteSpace(userVM.Department.ToString()))
            {
                return 0;
            }
            else
            {
                return _userRepository.Create(userVM);
            }
            //throw new NotImplementedException();
        }

        public int Delete(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return 0;
            }
            else
            {
                return _userRepository.Delete(Id);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            //throw new NotImplementedException();
            return _userRepository.Get();
        }

        public User Get(string Id)
        {
            //throw new NotImplementedException();
            return _userRepository.Get(Id);
        }

        public User Get(UserVM userVM)
        {
            throw new NotImplementedException();
        }

        public int Update(string Id, UserVM userVM)
        {
            if (string.IsNullOrWhiteSpace(userVM.FirstName) || string.IsNullOrWhiteSpace(userVM.LastName) || string.IsNullOrWhiteSpace(userVM.Role.ToString()) || string.IsNullOrWhiteSpace(userVM.Department.ToString()))
            {
                return 0;
            }
            else
            {
                return _userRepository.Update(Id, userVM);
            }
        }
    }
}

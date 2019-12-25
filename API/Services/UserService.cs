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
        readonly IUserRepository userRepository = new UserRepository();

        public UserService()
        {
        }

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

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
            //throw new NotImplementedException();
            return userRepository.Get();
        }

        public User Get(int Id)
        {
            throw new NotImplementedException();
        }

        public User Get(UserVM userVM)
        {
            return userRepository.Get(userVM);
        }

        public int Update(int Id, UserVM userVM)
        {            
            throw new NotImplementedException();
        }
    }
}

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
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository = new RoleRepository();

        public RoleService() { }

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public int Create(RoleVM roleVM)
        {
            if (string.IsNullOrWhiteSpace(roleVM.RoleName))
            {
                return 0;
            }
            else
            {
                return _roleRepository.Create(roleVM);
            }
        }

        public int Delete(int Id)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return 0;
            }
            else
            {
                return _roleRepository.Delete(Id);
            }
        }

        public IEnumerable<Role> Get()
        {
            return _roleRepository.Get();
        }

        public Role Get(int Id)
        {
            return _roleRepository.Get(Id);
        }

        public int Update(int Id, RoleVM roleVM)
        {
            if (string.IsNullOrWhiteSpace(roleVM.RoleName))
            {
                return 0;
            }
            else
            {
                return _roleRepository.Update(Id, roleVM);
            }
        }
    }
}

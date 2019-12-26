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
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository departmentRepository = new DepartmentRepository();

        public DepartmentService()
        {
        }

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public int Create(DepartmentVM departmentVM)
        {
            if (string.IsNullOrWhiteSpace(departmentVM.DepartmentName))
            {
                return 0;
            }
            else
            {
                return departmentRepository.Create(departmentVM);
            }
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return 0;
            }
            else
            {
                return departmentRepository.Delete(Id);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            return departmentRepository.Get();
            //throw new NotImplementedException();
        }

        public Department Get(int Id)
        {
            return departmentRepository.Get(Id);
            //throw new NotImplementedException();
        }

        public User Get(UserVM userVM)
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, DepartmentVM departmentVM)
        {
            if (string.IsNullOrWhiteSpace(departmentVM.DepartmentName))
            {
                return 0;
            }
            else
            {
                return departmentRepository.Update(Id, departmentVM);
            }
            //throw new NotImplementedException();
        }
    }
}

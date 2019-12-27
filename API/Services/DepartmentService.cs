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
        private IDepartmentRepository _departmentRepository = new DepartmentRepository();

        public DepartmentService() { }

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int Create(DepartmentVM departmentVM)
        {
            if (string.IsNullOrWhiteSpace(departmentVM.DepartmentName))
            {
                return 0;
            }
            else
            {
                return _departmentRepository.Create(departmentVM);
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
                return _departmentRepository.Delete(Id);
            }
        }

        public IEnumerable<Department> Get()
        {
            return _departmentRepository.Get();
        }

        public Department Get(int Id)
        {
            return _departmentRepository.Get(Id);
        }

        public int Update(int Id, DepartmentVM departmentVM)
        {
            if (string.IsNullOrWhiteSpace(departmentVM.DepartmentName))
            {
                return 0;
            }
            else
            {
                return _departmentRepository.Update(Id, departmentVM);
            }
        }
    }
}

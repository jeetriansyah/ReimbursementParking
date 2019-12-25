using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public int Create(DepartmentVM departmentVM)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            throw new NotImplementedException();
        }

        public Department Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(int Id, DepartmentVM departmentVM)
        {
            throw new NotImplementedException();
        }
    }
}

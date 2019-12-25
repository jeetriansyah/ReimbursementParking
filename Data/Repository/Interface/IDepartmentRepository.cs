using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Get();
        Department Get(int Id);
        int Create(DepartmentVM departmentVM);
        int Update(int Id, DepartmentVM departmentVM);
        int Delete(int Id);
    }
}

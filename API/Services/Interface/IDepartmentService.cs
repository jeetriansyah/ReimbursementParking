using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<Department> Get();
        Department Get(int Id);
        int Create(DepartmentVM departmentVM);
        int Update(int Id, DepartmentVM departmentVM);
        int Delete(int Id);
        User Get(UserVM userVM);
    }
}

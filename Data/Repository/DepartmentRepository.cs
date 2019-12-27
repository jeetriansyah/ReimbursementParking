using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MyContext myContext = new MyContext();

        public int Create(DepartmentVM departmentVM)
        {
            var department = myContext.Departments.Where(d => d.DepartmentName == departmentVM.DepartmentName);
            var result = 0;
            if (department != null)
            {
                var push = new Department(departmentVM);
                myContext.Departments.Add(push);
                return myContext.SaveChanges();
            }
            return result;
        }

        public int Delete(int Id)
        {
            var delete = myContext.Departments.Find(Id);
            if (delete != null)
            {
                delete.Delete();
                return myContext.SaveChanges();
            }
            return 0;
            //throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            //throw new NotImplementedException();
            return myContext.Departments.Where(d => d.IsDelete == false).ToList().OrderByDescending(r => r.Id);
        }

        public Department Get(int Id)
        {
            return myContext.Departments.Find(Id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, DepartmentVM departmentVM)
        {
            var result = 0;
            var update = myContext.Departments.Find(Id);
            update.Update(departmentVM);
            result = myContext.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }
    }
}

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
            {
                var department = myContext.Departments.Where(d => d.DepartmentName.ToLower() == departmentVM.DepartmentName);
                var result = 0;
                if (department != null)
                {
                    var push = new Department(departmentVM);
                    myContext.Departments.Add(push);
                    return myContext.SaveChanges();
                }
                return result;
            }
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            var delete = myContext.Departments.Find(Id);
            if(delete != null)
            {
                delete.IsDelete = true;
                delete.DeleteDate = DateTimeOffset.Now;
            }
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            //throw new NotImplementedException();
            return myContext.Departments.Where(d => d.IsDelete == false).ToList().OrderByDescending(d => d.Id);
        }

        public Department Get(int Id)
        {
            //throw new NotImplementedException();
            return myContext.Departments.Find(Id);
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

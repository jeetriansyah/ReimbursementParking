using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Department : BaseModel
    {
        public string DepartmentName { get; set; }

        public Department() { }
        public Department(DepartmentVM departmentVM)
        {
            this.DepartmentName = departmentVM.DepartmentName;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }

        public void Update(DepartmentVM departmentVM)
        {
            this.DepartmentName = departmentVM.DepartmentName;
            this.UpdateDate = DateTimeOffset.Now;
        }

        public void Delete(DepartmentVM departmentVM)
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}

using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Role : BaseModel
    {
        public string RoleName { get; set; }

        public Role() { }

        public Role(RoleVM roleVM)
        {
            this.RoleName = roleVM.RoleName;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }

        public void Update(RoleVM roleVM)
        {
            this.RoleName = roleVM.RoleName;
            this.UpdateDate = DateTimeOffset.Now;
        }

        public void Delete(RoleVM roleVM)
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}

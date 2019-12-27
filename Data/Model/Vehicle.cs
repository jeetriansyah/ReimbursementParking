using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Vehicle : BaseModel
    {
        public string VehicleType { get; set; }
        public Vehicle() { }
        public Vehicle(VehicleVM vehicleVM)
        {
            this.VehicleType = vehicleVM.VehicleType;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }

        public void Update(VehicleVM departmentVM)
        {
            this.VehicleType = departmentVM.VehicleType;
            this.UpdateDate = DateTimeOffset.Now;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}

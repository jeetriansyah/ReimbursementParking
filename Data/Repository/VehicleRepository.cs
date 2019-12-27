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
    public class VehicleRepository : IVehicleRepository
    {
        MyContext myContext = new MyContext();

        public int Create(VehicleVM vehicleVM)
        {
            var vehicle = myContext.Vehicles.Where(v => v.VehicleType == vehicleVM.VehicleType);
            var result = 0;
            if (vehicle != null)
            {
                var push = new Vehicle(vehicleVM);
                myContext.Vehicles.Add(push);
                return myContext.SaveChanges();
            }
            return result;
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            var delete = myContext.Vehicles.Find(Id);
            if (delete != null)
            {
                delete.Delete();
                return myContext.SaveChanges();
            }
            return 0;
            //throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> Get()
        {
            return myContext.Vehicles.Where(v => v.IsDelete == false).ToList().OrderByDescending(v => v.Id);
            //throw new NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            return myContext.Vehicles.Find(id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, VehicleVM vehicleVM)
        {
            var result = 0;
            var update = myContext.Vehicles.Find(Id);
            update.Update(vehicleVM);
            result = myContext.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }
    }
}

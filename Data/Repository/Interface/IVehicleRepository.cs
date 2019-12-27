using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> Get();
        Vehicle Get(int id);
        int Create(VehicleVM vehicleVM);
        int Update(int Id, VehicleVM vehicleVM);
        int Delete(int Id);
    }
}

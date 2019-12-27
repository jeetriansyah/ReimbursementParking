using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> Get();
        Vehicle Get(int id);
        int Create(VehicleVM vehicleVM);
        int Update(int Id, VehicleVM vehicleVM);
        int Delete(int Id);
    }
}

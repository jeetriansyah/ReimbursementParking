using API.Services.Interface;
using Data.Model;
using Data.Repository;
using Data.Repository.Interface;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _vehicleRepository = new VehicleRepository();

        public VehicleService() { }

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public int Create(VehicleVM vehicleVM)
        {
            if (string.IsNullOrWhiteSpace(vehicleVM.VehicleType))
            {
                return 0;
            }
            else
            {
                return _vehicleRepository.Create(vehicleVM);
            }
        }

        public int Delete(int Id)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return 0;
            }
            else
            {
                return _vehicleRepository.Delete(Id);
            }
        }

        public IEnumerable<Vehicle> Get()
        {
            return _vehicleRepository.Get();
        }

        public Vehicle Get(int id)
        {
            return _vehicleRepository.Get(id);
        }

        public int Update(int Id, VehicleVM vehicleVM)
        {
            if (string.IsNullOrWhiteSpace(vehicleVM.VehicleType))
            {
                return 0;
            }
            else
            {
                return _vehicleRepository.Update(Id, vehicleVM);
            }
        }
    }
}

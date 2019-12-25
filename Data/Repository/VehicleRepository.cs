using Data.Model;
using Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        public IEnumerable<Vehicle> Get()
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

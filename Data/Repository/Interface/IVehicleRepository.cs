using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> Get();
        Vehicle Get(int id);
    }
}

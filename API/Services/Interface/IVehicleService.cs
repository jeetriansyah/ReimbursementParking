using Data.Model;
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
    }
}

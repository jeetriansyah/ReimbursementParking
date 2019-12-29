using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface IParameterService
    {
        IEnumerable<Parameter> Get();
        Parameter Get(int id);
        int Create(ParameterVM parameterVM);
        int Update(int Id, ParameterVM parameterVM);
    }
}

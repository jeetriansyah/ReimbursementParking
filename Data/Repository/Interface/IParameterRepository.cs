using Data.Model;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IParameterRepository
    {
        IEnumerable<Parameter> Get();
        Parameter Get(int id);
        int Create(ParameterVM parameterVM);
        int Update(int Id, ParameterVM parameterVM);
    }
}

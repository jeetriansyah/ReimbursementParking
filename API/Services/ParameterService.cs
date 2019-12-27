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
    public class ParameterService : IParameterService
    {
        private IParameterRepository _parameterRepository = new ParameterRepository();

        public ParameterService() { }

        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public int Create(ParameterVM parameterVM)
        {
            if ((string.IsNullOrWhiteSpace(parameterVM.Name)) || (string.IsNullOrWhiteSpace(parameterVM.Value.ToString())))
            {
                return 0;
            }
            else
            {
                return _parameterRepository.Create(parameterVM);
            }
        }

        public IEnumerable<Parameter> Get()
        {
            return _parameterRepository.Get();
        }

        public Parameter Get(int id)
        {
            return _parameterRepository.Get(id);
        }

        public int Update(int Id, ParameterVM parameterVM)
        {
            if ((string.IsNullOrWhiteSpace(parameterVM.Name)) || (string.IsNullOrWhiteSpace(parameterVM.Value.ToString())))
            {
                return 0;
            }
            else
            {
                return _parameterRepository.Update(Id, parameterVM);
            }
        }
    }
}

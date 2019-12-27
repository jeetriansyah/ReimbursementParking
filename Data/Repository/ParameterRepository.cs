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
    public class ParameterRepository : IParameterRepository
    {
        MyContext myContext = new MyContext();

        public int Create(ParameterVM parameterVM)
        {
            var parameter = myContext.Parameters.Where(p => p.Name == parameterVM.Name);
            var result = 0;
            if (parameter != null)
            {
                var push = new Parameter(parameterVM);
                myContext.Parameters.Add(push);
                return myContext.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Parameter> Get()
        {
            return myContext.Parameters.ToList();
        }

        public Parameter Get(int id)
        {
            return myContext.Parameters.Find(id);
        }

        public int Update(int Id, ParameterVM parameterVM)
        {
            var result = 0;
            var update = myContext.Parameters.Find(Id);
            update.Update(parameterVM);
            result = myContext.SaveChanges();
            return result;
        }
    }
}

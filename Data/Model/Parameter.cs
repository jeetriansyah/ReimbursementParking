using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Parameter : BaseModel
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Parameter() { }

        public Parameter(ParameterVM parameterVM)
        {
            this.Name = parameterVM.Name;
            this.Value = parameterVM.Value;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }

        public void Update(ParameterVM parameterVM)
        {
            this.Name = parameterVM.Name;
            this.Value = parameterVM.Value;
            this.UpdateDate = DateTimeOffset.Now;
        }
    }
}

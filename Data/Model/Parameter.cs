using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Parameter : BaseModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}

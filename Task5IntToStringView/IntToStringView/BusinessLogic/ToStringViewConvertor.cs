using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToStringView.BusinessLogic
{
    public abstract class ToStringViewConvertor<T>
    {

        public ToStringViewConvertor(T valueToConvert)
        {
            this.ValueToConvert = valueToConvert;
        }

        public T ValueToConvert
        {
          get;
        }
    }
}

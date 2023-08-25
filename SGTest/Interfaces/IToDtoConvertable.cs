using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Interfaces
{
    internal interface IToDtoConvertable
    {
        public T ConvertToDto<T>(string line);
    }
}

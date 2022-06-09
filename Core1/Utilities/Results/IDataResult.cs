using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.Results
{
   public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}

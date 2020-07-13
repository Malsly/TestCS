using BL.Abstract.ResultWrappers;

namespace BL.Implementation.ResultWrappers
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }
    }
}
using BL.Abstract.ResultWrappers;

namespace BL.Implementation.ResultWrappers
{
    public class Result : IResult
    {
        public ResponseMessageType Message { get; set; }
        public ResponseStatusType ResponseStatusType { get; set; }
    }
}

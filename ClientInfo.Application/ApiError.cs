using System.Collections.Generic;

namespace ClientInfo.Application
{
    public class ApiError
    {
        public ApiError()
        {

        }
        public ApiError(string message, IEnumerable<string> errors) => (Message, Errors) = (message, errors);
        public void AddFailureMessages(IEnumerable<string> failureMessages) => Errors = failureMessages;
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }     
    }
}
using Flunt.Notifications;
using ProjetoMongDb.Application;
using System.Collections.Generic;

namespace ProjetoMongDb.API
{
    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(IEnumerable<Notification> errors, ErrorCode? error = null)
        {
            this.ErrorType = error;
            this.Errors = errors;
        }

        public ErrorCode? ErrorType { get; private set; }
        public IEnumerable<Notification> Errors { get; private set; }

        public static ApiError FromResult(Result result)
        {
            return new ApiError(result.Notifications, result.Error);
        }
    }
}

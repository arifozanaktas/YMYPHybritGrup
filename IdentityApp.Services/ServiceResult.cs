using System.Net;
using System.Text.Json.Serialization;

namespace IdentityApp.Services
{
    // Anemic Model / Rich Domain Model
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }


        [JsonIgnore] public HttpStatusCode Status { get; set; }

        [JsonIgnore] public bool IsSuccess => Errors is null || Errors?.Count == 0;

        [JsonIgnore] public bool IsFail => !IsSuccess;

        // Static factory Methods
        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T> { Data = data, Status = status };
        }

        public static ServiceResult<T> Failure(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = errors, Status = status };
        }

        public static ServiceResult<T> Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = [error], Status = status };
        }
    }


    public class ServiceResult
    {
        public List<string>? Errors { get; set; }

        [JsonIgnore] public bool IsSuccess => Errors is null || Errors?.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        // Static factory Methods
        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status,
            };
        }

        public static ServiceResult Failure(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult { Errors = errors, Status = status };
        }

        public static ServiceResult Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                Errors = [error],
                Status = status
            };
        }
    }
}
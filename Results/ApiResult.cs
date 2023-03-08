using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TulparResponses.v1.Responses;

namespace TulparResponses.v1.Results
{
    public class ApiResult<T> : DataResponse<T>
    {
        [JsonIgnore]
        public static ApiResult<T> SuccessResult => new ApiResult<T>
        {
            Success = true,
            StatusCode = 200
        };

        [JsonIgnore]
        public static ApiResult<T> NotFoundResult => new ApiResult<T>
        {
            Success = false,
            StatusCode = 404
        };

        [JsonIgnore]
        public static ApiResult<T> UnauthorizedResult => new ApiResult<T>
        {
            Success = false,
            StatusCode = 401
        };

        [JsonIgnore]
        public static ApiResult<T> ForbiddenResult => new ApiResult<T>
        {
            Success = false,
            StatusCode = 403
        };

        [JsonIgnore]
        public static ApiResult<T> UnprocessableEntityResult => new ApiResult<T>
        {
            Success = false,
            StatusCode = 422
        };

        [JsonIgnore]
        public static ApiResult<T> ErrorResult => new ApiResult<T>
        {
            Success = false,
            StatusCode = 500
        };

        public ApiResult()
        {
        }

        public ApiResult(T data)
            : this(data, -1, (string)null)
        {
        }

        public ApiResult(T data, int statusCode)
            : this(data, statusCode, (string)null)
        {
        }

        public ApiResult(T data, int statusCode, string message)
        {
            Data = data;
            Success = StatusCode == 200 || (statusCode == -1 && data != null);
            StatusCode = statusCode;
            Message = message;
        }

        public ApiResult(bool success, int statusCode, string message)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        public static ApiResult<T> SuccessDataResult(T data)
        {
            return new ApiResult<T>(data)
            {
                Success = true,
                StatusCode = 200
            };
        }

        public static ApiResult<T> UnprocessableEntityWithMessageResult(string message)
        {
            return new ApiResult<T>
            {
                Message = message,
                Success = false,
                StatusCode = 422
            };
        }
    }
}

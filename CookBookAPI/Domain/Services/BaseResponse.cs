using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Services
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public T Resource { get; private set; }

        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        protected BaseResponse(string message, bool success = false)
        {
            Success = success;
            Message = message;
            Resource = default;
        }
    }
}

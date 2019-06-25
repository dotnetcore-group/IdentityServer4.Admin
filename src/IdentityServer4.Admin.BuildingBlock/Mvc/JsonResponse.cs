using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.BuildingBlock.Mvc
{
    public class JsonResponse<T>
    {
        public JsonResponse() : this(false, default, null)
        {

        }
        public JsonResponse(IEnumerable<string> errors = null) : this(false, default, errors)
        {

        }
        public JsonResponse(bool success, T data) : this(success, data, null)
        {
        }
        public JsonResponse(bool success, T data, IEnumerable<string> errors)
        {
            Success = success;
            Data = data;
            Errors = errors;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public object DeveloperMessage { get; set; }
    }
}

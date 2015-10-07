using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStepsWebAPIMVC6
{
    public class DemoActionResult : IActionResult
    {
        public int Id
        {
            get; set;
        }

        public int StatusCode
        {
            get; set;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            response.Headers["X-Version"] = "7";
            response.Headers["Location"] = "/api/hotels/" + Id;

            response.StatusCode = StatusCode;

            return Task.FromResult<object>(null);

            // response.Body

        }
    }
}

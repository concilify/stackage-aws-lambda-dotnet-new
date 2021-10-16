using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stackage.Aws.Lambda.FakeRuntime.Services;

namespace Stackage.Aws.Lambda.FakeRuntime.Controllers
{
   [ApiController]
   [Route("{functionName}/2018-06-01/runtime/invocation")]
   public class RuntimeInvocationController : ControllerBase
   {
      private readonly IFunctionsService _functionsService;

      public RuntimeInvocationController(IFunctionsService functionsService)
      {
         _functionsService = functionsService;
      }

      [HttpGet("next")]
      public async Task<IActionResult> NextAsync(string functionName)
      {
         var (awsRequestId, body) = await _functionsService.WaitForNextInvocationAsync(functionName, HttpContext.RequestAborted);

         Response.Headers.Add("Lambda-Runtime-Aws-Request-Id", awsRequestId);
         Response.Headers.Add("Lambda-Runtime-Invoked-Function-Arn", $"arn:aws:lambda:region-name:account-name:function:{functionName}");
         Response.Headers.Add("Lambda-Runtime-Deadline-Ms", (DateTimeOffset.UtcNow.AddSeconds(30).ToUnixTimeSeconds() * 1000).ToString());

         return Content(body, "application/json", Encoding.UTF8);
      }

      [HttpPost("{awsRequestId}/response")]
      public async Task<IActionResult> ResponseAsync(string functionName, string awsRequestId)
      {
         using (var reader = new StreamReader(Request.Body))
         {
            _functionsService.InvocationResponse(functionName, awsRequestId, await reader.ReadToEndAsync());
         }

         return Ok();
      }

      [HttpPost("{awsRequestId}/error")]
      public async Task<IActionResult> ErrorAsync(string functionName, string awsRequestId)
      {
         using (var reader = new StreamReader(Request.Body))
         {
            _functionsService.InvocationError(functionName, awsRequestId, await reader.ReadToEndAsync());
         }

         return Ok();
      }
   }
}
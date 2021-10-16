using Lambda.Middleware.Example.Integrations;
using Lambda.Middleware.Example.Middleware;
using Lambda.Middleware.Example.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stackage.Aws.Lambda.Abstractions;
using Stackage.Aws.Lambda.Extensions;
using Stackage.Aws.Lambda.Middleware;

namespace Lambda.Middleware.Example
{
   public class LambdaStartup : ILambdaStartup<InputPoco>
   {
      private readonly IConfiguration _configuration;

      public LambdaStartup(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddSingleton<ILambdaResultFactory, HttpLambdaResultFactory>();

         // TODO: Create correlationId type service
      }

      public void ConfigurePipeline(ILambdaPipelineBuilder<InputPoco> pipelineBuilder)
      {
         pipelineBuilder.Use<RequestLoggingMiddleware<InputPoco>, InputPoco>();
         pipelineBuilder.Use<ExceptionHandlingMiddleware<InputPoco>, InputPoco>();
      }
   }
}
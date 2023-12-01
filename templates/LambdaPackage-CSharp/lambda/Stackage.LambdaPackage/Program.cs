using Amazon.Lambda.Serialization.SystemTextJson;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stackage.Aws.Lambda;
using Stackage.Aws.Lambda.Extensions;
using Stackage.LambdaPackage;

using var consoleLifetime = new ConsoleLifetime();

await new LambdaListenerBuilder()
   .UseHandler<LambdaHandler, Request>()
   .UseStartup<LambdaStartup>()
   .UseSerializer<SourceGeneratorLambdaJsonSerializer<LambdaJsonSerializerContext>>()
   .Build()
   .ListenAsync(consoleLifetime.Token);


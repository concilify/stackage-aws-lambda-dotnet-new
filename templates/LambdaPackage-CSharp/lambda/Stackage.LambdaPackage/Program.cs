﻿using Amazon.Lambda.Serialization.SystemTextJson;
using Stackage.Aws.Lambda;
using Stackage.LambdaPackage;

using var consoleLifetime = new ConsoleLifetime();

await new LambdaListenerBuilder()
   .UseHandler<LambdaHandler, Request>()
   .UseStartup<LambdaStartup>()
   .UseSerializer<SourceGeneratorLambdaJsonSerializer<LambdaJsonSerializerContext>>()
   .Build()
   .ListenAsync(consoleLifetime.Token);


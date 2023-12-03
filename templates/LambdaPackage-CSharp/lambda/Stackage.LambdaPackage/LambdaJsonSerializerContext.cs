using System.Text.Json.Serialization;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Stackage.LambdaPackage;

[assembly: LambdaSerializer(typeof(SourceGeneratorLambdaJsonSerializer<LambdaJsonSerializerContext>))]

namespace Stackage.LambdaPackage;

[JsonSerializable(typeof(Request))]
public partial class LambdaJsonSerializerContext : JsonSerializerContext
{
}

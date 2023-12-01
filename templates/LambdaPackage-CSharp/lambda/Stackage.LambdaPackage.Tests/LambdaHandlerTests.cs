using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using FakeItEasy;
using NUnit.Framework;
using Stackage.Aws.Lambda.Abstractions;
using Stackage.Aws.Lambda.Results;

namespace Stackage.LambdaPackage.Tests;

public class LambdaHandlerTests
{
   [Test]
   public async Task handler_returns_greetings()
   {
      var context = A.Fake<ILambdaContext>();
      var handler = new LambdaHandler();

      var result = await handler.HandleAsync(new Request {Name = "FOO"}, context);

      Assert.That(result, Is.InstanceOf<StringResult>());
      // TODO: Uncomment when NuGet updated
      // var stringResult = (StringResult)result;
      // Assert.That(stringResult.Content, Is.EqualTo("Greetings FOO!"));
   }
}

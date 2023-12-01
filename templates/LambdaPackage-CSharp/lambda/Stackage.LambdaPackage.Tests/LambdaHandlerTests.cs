using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using FakeItEasy;
using NUnit.Framework;
using Stackage.Aws.Lambda.Abstractions;

namespace Stackage.LambdaPackage.Tests;

public class LambdaHandlerTests
{
   [Test]
   public async Task handler_returns_greetings()
   {
      var context = A.Fake<ILambdaContext>();
      var handler = new LambdaHandler();

      var result = await handler.HandleAsync(new Request {Name = "FOO"}, context);

      // var stream = result.SerializeResult(new CamelCaseLambdaJsonSerializer(), context);
      //
      // Assert.That(await stream.ReadToEndAsync(), Is.EqualTo("Greetings FOO!"));

      Assert.Fail();
   }
}

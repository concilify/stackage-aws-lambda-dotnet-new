using System.Threading.Tasks;
using Amazon.Lambda.Core;
using FakeItEasy;
using NUnit.Framework;
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
      var stringResult = (StringResult)result;
      Assert.That(stringResult.Content, Is.EqualTo("Greetings FOO!"));
   }
}

using NUnit.Framework;
using System;
using System.Net.Http;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void Exception_DefaultConstructor()
        {
            var ex1 = new RestException();
            Assert.That(ex1.Response, Is.EqualTo(null));
            Assert.That(ex1.Message, Is.EqualTo("A REST request failed."));
            Assert.That(ex1.InnerException, Is.Null);

            var ex2 = new NotFoundException();
            Assert.That(ex2.Response, Is.EqualTo(null));
            Assert.That(ex2.Message, Is.EqualTo("The requested resource was not found."));
            Assert.That(ex2.InnerException, Is.Null);

            var ex3 = new RateLimitExceededException();
            Assert.That(ex3.Response, Is.EqualTo(null));
            Assert.That(ex3.Message, Is.EqualTo("The rate limit for the current API key was exceeded."));
            Assert.That(ex3.InnerException, Is.Null);

            var ex4 = new RestTimeoutException();
            Assert.That(ex4.Response, Is.EqualTo(null));
            Assert.That(ex4.Message, Is.EqualTo("A REST request timed out."));
            Assert.That(ex4.InnerException, Is.Null);

            var ex5 = new ConnectionFailedException();
            Assert.That(ex5.Response, Is.EqualTo(null));
            Assert.That(ex5.Message, Is.EqualTo("Failed to connect to the server."));
            Assert.That(ex5.InnerException, Is.Null);
        }

        [Test]
        public void Exception_ResponseConstructor()
        {
            var response = new RiotResponse(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            var ex1 = new RestException(response);
            Assert.That(ex1.Response, Is.EqualTo(response));

            var ex2 = new NotFoundException(response);
            Assert.That(ex2.Response, Is.EqualTo(response));

            var ex3 = new RateLimitExceededException(response);
            Assert.That(ex3.Response, Is.EqualTo(response));

            var ex4 = new RestTimeoutException(response);
            Assert.That(ex4.Response, Is.EqualTo(response));

            var ex5 = new ConnectionFailedException(response);
            Assert.That(ex5.Response, Is.EqualTo(response));
        }

        [Test]
        public void Exception_ResponseConstructor_NullHttpResponse()
        {
            var response = new RiotResponse(null);

            var ex1 = new RestException(response);
            Assert.That(ex1.Response, Is.EqualTo(response));

            var ex2 = new NotFoundException(response);
            Assert.That(ex2.Response, Is.EqualTo(response));

            var ex3 = new RateLimitExceededException(response);
            Assert.That(ex3.Response, Is.EqualTo(response));

            var ex4 = new RestTimeoutException(response);
            Assert.That(ex4.Response, Is.EqualTo(response));

            var ex5 = new ConnectionFailedException(response);
            Assert.That(ex5.Response, Is.EqualTo(response));
        }

        [Test]
        public void Exception_ResponseMessageConstructor()
        {
            var response = new RiotResponse(null);
            var message = "TEST";

            var ex1 = new RestException(response, message);
            Assert.That(ex1.Response, Is.EqualTo(response));
            Assert.That(ex1.Message, Is.EqualTo(message));

            var ex2 = new NotFoundException(response, message);
            Assert.That(ex2.Response, Is.EqualTo(response));
            Assert.That(ex2.Message, Is.EqualTo(message));

            var ex3 = new RateLimitExceededException(response, message);
            Assert.That(ex3.Response, Is.EqualTo(response));
            Assert.That(ex3.Message, Is.EqualTo(message));

            var ex4 = new RestTimeoutException(response, message);
            Assert.That(ex4.Response, Is.EqualTo(response));
            Assert.That(ex4.Message, Is.EqualTo(message));

            var ex5 = new ConnectionFailedException(response, message);
            Assert.That(ex5.Response, Is.EqualTo(response));
            Assert.That(ex5.Message, Is.EqualTo(message));
        }

        [Test]
        public void Exception_ResponseMessageInnerExceptionConstructor()
        {
            var response = new RiotResponse(null);
            var message = "TEST";
            var innerException = new Exception();

            var ex1 = new RestException(response, message, innerException);
            Assert.That(ex1.Response, Is.EqualTo(response));
            Assert.That(ex1.Message, Is.EqualTo(message));
            Assert.That(ex1.InnerException, Is.EqualTo(innerException));

            var ex2 = new NotFoundException(response, message, innerException);
            Assert.That(ex2.Response, Is.EqualTo(response));
            Assert.That(ex2.Message, Is.EqualTo(message));
            Assert.That(ex2.InnerException, Is.EqualTo(innerException));

            var ex3 = new RateLimitExceededException(response, message, innerException);
            Assert.That(ex3.Response, Is.EqualTo(response));
            Assert.That(ex3.Message, Is.EqualTo(message));
            Assert.That(ex3.InnerException, Is.EqualTo(innerException));

            var ex4 = new RestTimeoutException(response, message, innerException);
            Assert.That(ex4.Response, Is.EqualTo(response));
            Assert.That(ex4.Message, Is.EqualTo(message));
            Assert.That(ex4.InnerException, Is.EqualTo(innerException));

            var ex5 = new ConnectionFailedException(response, message, innerException);
            Assert.That(ex5.Response, Is.EqualTo(response));
            Assert.That(ex5.Message, Is.EqualTo(message));
            Assert.That(ex5.InnerException, Is.EqualTo(innerException));
        }
    }
}

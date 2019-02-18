using AspNet.WebApi.Common.Exceptions;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace AspNet.WebApi.Common.Tests.Exceptions
{
    /// <summary>Exceptions tests.</summary>
    public class ExceptionsTests
    {
        /// <summary>Test for all current assembly Exceptions based on <see cref="ApiException"/>.</summary>
        [Fact]
        public void StatusCodes()
        {
            var exceptions = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where typeof(ApiException).IsAssignableFrom(type)
                             select type;

            const int fakeStatusCode = 10;
            const string fakeReasonCode = "FAKE";
            const string message = "test message";
            const string innerMessage = "test inner message";

            var exception = new ArgumentNullException(innerMessage);

            foreach (var type in exceptions)
            {
                var statusCodeField = type.GetField("STATUS_CODE", BindingFlags.Static | BindingFlags.Public);
                var reasonCodeField = type.GetField("REASON_CODE", BindingFlags.Static | BindingFlags.Public);

                Assert.NotNull(statusCodeField);
                Assert.NotNull(reasonCodeField);

                var statusCode = (int)statusCodeField.GetValue(null);
                var reasonCode = (string)reasonCodeField.GetValue(null);
                var instance = Activator.CreateInstance(type) as ApiException;

                Assert.IsAssignableFrom<ApiException>(instance);
                Assert.NotNull(instance);
                Assert.Equal(statusCode, instance.StatusCode);
                Assert.Equal(reasonCode, instance.ReasonCode);

                var apiException = Activator.CreateInstance(type, message) as ApiException;

                Assert.IsAssignableFrom<ApiException>(instance);
                Assert.NotNull(apiException);
                Assert.Equal(statusCode, apiException.StatusCode);
                Assert.Equal(reasonCode, instance.ReasonCode);
                Assert.Equal(message, apiException.Message);

                var apiExceptionInner = Activator.CreateInstance(type, message, exception) as ApiException;

                Assert.IsAssignableFrom<ApiException>(instance);
                Assert.NotNull(apiExceptionInner);
                Assert.Equal(statusCode, apiExceptionInner.StatusCode);
                Assert.Equal(reasonCode, instance.ReasonCode);
                Assert.Equal(message, apiExceptionInner.Message);
                Assert.Equal(exception.Message, apiExceptionInner.InnerException?.Message);

                var apiExceptionStatusCode = Activator.CreateInstance(type, fakeStatusCode, fakeReasonCode, message, exception) as ApiException;

                Assert.IsAssignableFrom<ApiException>(instance);
                Assert.NotNull(apiExceptionStatusCode);
                Assert.Equal(fakeStatusCode, apiExceptionStatusCode.StatusCode);
                Assert.Equal(fakeReasonCode, apiExceptionStatusCode.ReasonCode);
                Assert.Equal(message, apiExceptionStatusCode.Message);
                Assert.Equal(exception.Message, apiExceptionStatusCode.InnerException?.Message);
            }
        }
    }
}
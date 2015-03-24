using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Histrio.Commands;
using Newtonsoft.Json;

namespace Histrio.Net.Http.Controlers
{
    internal class TheaterController : ApiController
    {
        private readonly Theater _theater;

        private static readonly MethodInfo DispatchMethodInfo = typeof(TheaterController)
            .GetMethod("Dispatch", BindingFlags.Static | BindingFlags.NonPublic);

        public TheaterController(Theater theater)
        {
            _theater = theater;
        }

        [Route("")]
        public HttpResponseMessage Post([FromBody] UntypedMessage untypedMessage)
        {
            var conversionType = Type.GetType(untypedMessage.AssemblyQualifiedName);
            var jtoken = untypedMessage.Body;
            var messageBody = JsonConvert.DeserializeObject(jtoken.ToString(), conversionType);
            MethodInfo dispatchMethod = DispatchMethodInfo.MakeGenericMethod(conversionType);
            
            var universalActorName = new Uri(untypedMessage.Address);

            dispatchMethod.Invoke(this, new[] {_theater, messageBody, universalActorName});

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private static void Dispatch<TMessage>(Theater theater,
            TMessage body, Uri universalActorName)
            where TMessage : class
        {
            var message = new Message<TMessage>(body);
            theater.Dispatch(message, universalActorName);
        }
    }
}
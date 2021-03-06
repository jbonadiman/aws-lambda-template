using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using DefaultLambda.Models;

[assembly: LambdaSerializer(typeof(CamelCaseLambdaJsonSerializer))]

namespace DefaultLambda
{
    public class Function
    {
        public Function()
        { }

        public async Task<APIGatewayProxyResponse> FunctionHandler(
            APIGatewayProxyRequest request,
            ILambdaContext context)
        {
            var input = JsonSerializer.Deserialize<Request>(request.Body);
            if (input == null)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int) HttpStatusCode.BadRequest,
                    Body = $"incorrect input: {request.Body}"
                };
            }
            
            throw new NotImplementedException();
        }
    }
}
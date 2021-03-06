using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

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
            throw new NotImplementedException();
        }
    }
}
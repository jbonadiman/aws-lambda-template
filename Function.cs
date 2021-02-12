using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(JsonSerializer))]

namespace DefaultLambda
{
    public class Function
    {
        public Function()
        { }

        public async Task FunctionHandler(string input, ILambdaContext context)
        { }
    }
}
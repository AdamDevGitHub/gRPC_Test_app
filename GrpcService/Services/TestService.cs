using Grpc.Core;
using GrpcService;
using GrpcService.Interfaces;
using GrpcService.Logic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcServiceClient
{
    public class TestService : Test.TestBase
    {
        private readonly ILogger<TestService> _logger;
        private readonly IRepository _data;

        public TestService(ILogger<TestService> logger, IRepository data)
        {
            _logger = logger;
            _data = data;
        }

        public override Task<Reply> IsInDB(Request request, ServerCallContext context)
        {
            var listOfPeople = _data.GetMockData();
            var people = new People();
            
            people.Firstname = request.FirstName;
            people.LastName = request.LastName;
            people.City = request.City;

            bool exist = listOfPeople.Contains(people);

            return Task.FromResult(new Reply
            {
                Exist = exist == true ? true : false,
                Message = string.Join(", ", request.FirstName, request.LastName, request.City) 
            });
        }
    }
}
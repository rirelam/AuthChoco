
using HotChocolate.AspNetCore.Authorization;

namespace AuthChoco.Resolvers
{
    public class QueryResolver
    {
        [Authorize(Policy = "claim-policy-2")]
        public string Welcome()
        {
            return "Welcome To Custom Authentication Services In GraphQL In Pure Code First";
        }
    }
}
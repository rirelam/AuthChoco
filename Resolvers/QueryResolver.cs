
using HotChocolate.AspNetCore.Authorization;

namespace AuthChoco.Resolvers
{
    public class QueryResolver
    {
        [Authorize(Roles = new[] { "admin", "super-admin" })]
        public string Welcome()
        {
            return "Welcome To Custom Authentication Services In GraphQL In Pure Code First";
        }
    }
}
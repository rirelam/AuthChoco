
using AuthChoco.InputTypes;
using AuthChoco.Logics;

namespace AuthChoco.Resolvers
{
    public class MutationResolver
    {
        public string Register([Service] IAuthLogic authLogic, RegisterInputType registerInput)
        {
            return authLogic.Register(registerInput);
        }

        public string Login([Service] IAuthLogic authLogic, LoginInputType loginInput)
        {
            return authLogic.Login(loginInput);
        }
    }
}
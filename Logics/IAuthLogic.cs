using AuthChoco.InputTypes;
using AuthChoco.Models;

namespace AuthChoco.Logics
{
    public interface IAuthLogic
    {
        string Register(RegisterInputType registerInput);
        TokenResponseModel Login(LoginInputType loginInput);
        TokenResponseModel RenewAccessToken(RenewTokenInputType renewToken);
    }
}
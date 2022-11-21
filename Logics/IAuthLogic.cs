using AuthChoco.InputTypes;

namespace AuthChoco.Logics
{
    public interface IAuthLogic
    {
        string Register(RegisterInputType registerInput);
        string Login(LoginInputType loginInput);
    }
}
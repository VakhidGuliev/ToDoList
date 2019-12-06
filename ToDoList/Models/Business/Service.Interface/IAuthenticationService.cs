using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface IAuthenticationService
    {
        bool SignIn(string email, string password);
    }
}

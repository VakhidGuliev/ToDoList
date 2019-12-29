using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface IAppRole
    {
        
      User.Role SetRole(string email, string password);

    }
}

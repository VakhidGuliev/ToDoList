using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface IAppRole
    {
        
      string SetRole(string email, string password);

    }
}

using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
        
    public interface IAccountService
    {
        User InsertToAccount(string email, string password);
    }

}

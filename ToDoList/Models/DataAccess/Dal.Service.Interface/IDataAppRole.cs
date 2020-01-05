using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    public interface IDataAppRole
    {
        string SetRole(string email, string password);
   
    }
}

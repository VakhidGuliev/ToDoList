using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{

    public interface IDataAccountService
    {
        User InsertToAccount(string email, string password);
        int SetUserAccountId(string email, string password);
        
 
    }
   

}

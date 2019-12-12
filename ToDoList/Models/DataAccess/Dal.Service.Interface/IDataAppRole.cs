namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using ToDoList.Models.DataAccess.Dal.Entites;

    public interface IDataAppRole
    {
       User.Role SetRole(string email, string password);
   
    }
}

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using System.Threading.Tasks;
    using ToDoList.Models.DataAccess.Dal.Entites;

    public interface IDataAppRole
    {
      User.Role SetRole(string email, string password);
   
    }
}

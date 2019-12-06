using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    public  interface IDataAuthentication
    {
        bool SignIn(string email, string password);
    }
}

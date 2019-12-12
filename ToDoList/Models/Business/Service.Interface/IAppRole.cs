namespace ToDoList.Models.Business.Service.Interface
{
    using ToDoList.Models.Business.Entites;

    public interface IAppRole
    {
        User.Role SetRole(string email, string password);
    }
}

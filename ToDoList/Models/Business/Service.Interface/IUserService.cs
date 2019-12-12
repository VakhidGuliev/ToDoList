namespace ToDoList.Models.Business.Service.Interface
{
    using System.Collections.Generic;
    using ToDoList.Models.Business.Entites;

    public interface IUserService
    {
           void Create(User authUser);

           List<User> GetRegistrationUsers();
        }
}

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using System.Collections.Generic;
    using ToDoList.Models.DataAccess.Dal.Entites;
    public interface IDataUserService
    {
        void Create(User user);

        List<User> GetRegistrationUsers();
    }
 
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    public interface IDataUserService
    {
        void Create(User user);

        Task <List<User>> GetRegistrationUsers();
    }
 
}

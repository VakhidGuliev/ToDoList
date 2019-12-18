using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
    public interface IUserService
    {
           void Create(User authUser);

           Task <List<User>> GetRegistrationUsers();
    }
}

using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.Helpers;

namespace ToDoList.Models.Business.Service.Implementation
{
    public class AppRoleService : IAppRole
    {
        private readonly IDataAppRole _dataAppRole;

        public AppRoleService(IDataAppRole dataAppRole)
        {
            _dataAppRole = dataAppRole;
        }

        public User.Role SetRole(string email, string password)
        {
       
         return CommonConverter.FromDalToBl(_dataAppRole.SetRole(email, password));
        }
    }
}

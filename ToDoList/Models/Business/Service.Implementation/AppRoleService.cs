using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;

namespace ToDoList.Models.Business.Service.Implementation
{
    public class AppRoleService : IAppRole
    {
        private readonly IDataAppRole _dataAppRole;

        public AppRoleService(IDataAppRole dataAppRole)
        {
            _dataAppRole = dataAppRole;
        }

  
    }
}

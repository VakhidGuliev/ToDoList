namespace ToDoList.Models.Business.Service.Implementation
{
  
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;

    public class AppRoleService : IAppRole
    {
        private readonly IDataAppRole _dataAppRole;

        public AppRoleService(IDataAppRole dataAppRole)
        {
            this._dataAppRole = dataAppRole;
        }

  
    }
}

using System.Linq;
using ToDoList.Models.DataAccess.Dal.Entites;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.DataAccess.Data;

namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    public class AppRoleDataService : IDataAppRole
    {
        private readonly DataToDoListContext _context;

        public AppRoleDataService(DataToDoListContext context)
        {
            _context = context;
        }

        public  User.Role SetRole(string email, string password)
        {
            var setAdmin =  _context.Users.FirstOrDefault();
            var selectAdmin = _context.Users.FirstOrDefault(x => x.Email == setAdmin.Email);
            if (setAdmin != null && (selectAdmin != null && (email == selectAdmin.Email && password == setAdmin.Password)))
            {
                return User.Role.Admin;
            }

            return User.Role.User;
        }
    }
}

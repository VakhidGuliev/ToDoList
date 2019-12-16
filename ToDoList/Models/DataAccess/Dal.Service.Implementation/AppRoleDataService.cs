namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;


    public class AppRoleDataService : IDataAppRole
    {
        private readonly DataToDoListContext context;

        public AppRoleDataService(DataToDoListContext context)
        {
            this.context = context;
        }

        public  User.Role SetRole(string email, string password)
        {
            var setAdmin =   this.context.Users.FirstOrDefault();
            var selectAdmin =  this.context.Users.FirstOrDefault(x => x.Email == setAdmin.Email);
            if (email == selectAdmin.Email && password == setAdmin.Password)
            {
                return User.Role.Admin;
            }

            return User.Role.User;
        }
    }
}

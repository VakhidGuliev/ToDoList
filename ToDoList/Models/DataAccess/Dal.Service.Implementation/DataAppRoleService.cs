namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.Linq;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;

    public class DataAppRoleService : IDataAppRole
    {
        private readonly string _connectionString;


        public DataAppRoleService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        public string SetRole(string email, string password)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                var Admin = db.Roles.First();

                if (Admin != null && (Admin != null && (email == Admin.Email && password == Admin.Password)))
                {
                    return Admin.Role;
                }
                AppRole appRole = new AppRole
                {
                    Email = email,
                    Password = password,
                    Role = "User",
                    Name = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password).FirstName

                };

                db.Roles.Add(appRole);
                db.SaveChanges();

                return appRole.Role;
            }

        }
        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            var options = optionsBuilder.UseSqlServer(_connectionString)
              .Options;
            return options;
        }
    }
}

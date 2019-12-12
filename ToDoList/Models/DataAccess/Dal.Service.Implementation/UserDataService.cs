namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;
    using ToDoList.Models.Helpers;

    public class UserDataService : IDataUserService
    {
        private readonly string connectionString;

        public UserDataService(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        public void Create(User user)
        {
            using (var db = new DataToDoListContext(this.Options()))
            {
                if (string.IsNullOrWhiteSpace(user.Password))
                {
                    throw new AppException("Password is required");
                }

                if (db.Users.Any(x => x.Email == user.Email))
                {
                    throw new AppException("Email \"" + user.Email + "\" is already taken");
                }

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public List<User> GetRegistrationUsers()
        {
            using (var db = new DataToDoListContext(this.Options()))
            {
                return db.Users.ToList();
            }
        }

        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            DbContextOptions<DataToDoListContext> options = optionsBuilder.UseSqlServer(this.connectionString)
              .Options;
            return options;
        }
    }
}
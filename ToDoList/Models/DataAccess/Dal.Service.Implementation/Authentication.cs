namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;
    using System.Linq;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.Business.Service.Implementation.Converters;

    public class Authentication : IDataAuthentication
    {
        private readonly string connectionString;

        public Authentication(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DataToDoListContext");
        }
      
        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            DbContextOptions<DataToDoListContext> options = optionsBuilder.UseSqlServer(this.connectionString)
              .Options;
            return options;
        }

         bool IDataAuthentication.SignIn(string email, string password)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                RegistrationUser user = db.RegistrationUsers.FirstOrDefault(x => (x.Email == email) && x.Password == password);
                var authUserEmail = user.Email;
                var authUserPassword = user.Password;

                if (authUserEmail.Equals(email) && authUserPassword.Equals(password))
                {
                    return true;
                }
                else
                {
                    throw new Exception("This User is not exit");
                }
            }
        }
    }
}

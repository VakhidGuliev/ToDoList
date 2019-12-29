namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;
    using System.Linq;
    using ToDoList.Models.DataAccess.Dal.Entites;

    public class DataAccountService : IDataAccountService
    {
        private readonly string _connectionString;

        public DataAccountService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        public User InsertToAccount(string email, string password)
        {
              using (var db = new DataToDoListContext(Options()))
            {
                var getAccoundUser = db.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                return getAccoundUser;

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

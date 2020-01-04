using System.Linq;

namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Entites;
    using Interface;
    using Data;
    using Helpers;

    public class DataUserService : IDataUserService
    {
        private readonly string _connectionString;
        

        public DataUserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

    

        public async void Create(User user)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                if (string.IsNullOrWhiteSpace(user.Password))
                {
                    throw new AppException("Password is required");
                }
                var res = db.Users.AnyAsync(x => x.Email == user.Email).Result;
                if (res)
                {
                    throw new AppException("Email \"" + user.Email + "\" is already taken");
                }

                db.Users.Add(user);
               await  db.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<List<User>> GetRegistrationUsers()
        {
            using (var db = new DataToDoListContext(Options()))
            {
                return await db.Users.ToListAsync();
            }
            
        }

        public User GetUser(string email)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                var user = db.Users.FirstOrDefault(x => x.Email == email);
                return  db.Users.FirstOrDefault(x=>x.Email ==email);
            }

       
        }

        public string RegUserEmail()
        {
            return null;
        }


//        public string RegUserEmail()
//        {
//          
//            using (var db = new DataToDoListContext(Options()))
//            {
//                
//             
//
//         
//
//
//            }
//        }

        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            var options = optionsBuilder.UseSqlServer(_connectionString)
              .Options;
            return options;
        }
    }
}
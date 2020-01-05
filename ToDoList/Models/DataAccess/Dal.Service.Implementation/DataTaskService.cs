
namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Interface;
    using Data;
    using Helpers;
    using Task = Entites.Task;
    using System.Threading.Tasks;
    using System.Linq;

    public class DataTaskService : IDataTaskService
    {
        private readonly string _connectionString;


        public DataTaskService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        public async void CreateTask(Task item)
        {

            using (var db = new DataToDoListContext(Options()))
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                {
                    throw new AppException("Name is required");
                }

                db.Tasks.Add(item);

                await db.SaveChangesAsync();
            }
        }



      


        public void DeleteTask(int id)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                db.Tasks.Remove(db.Tasks.Find(id));
            }
        }


        public Task GetTask(int id)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                return db.Tasks.Find(id);
            }
        }

        public async Task<List<Task>> GetTaskList(int  userAccountId )
        {
            using (var db = new DataToDoListContext(Options()))
            {
               var res = db.Tasks.Where(x => x.UserAccountId == userAccountId).ToList();
      
               return await db.Tasks.Where(x => x.UserAccountId == userAccountId).ToListAsync();
                
            }
        }

        public async Task<Task> UpdateTask(Task item)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                db.Tasks.Update(item);
                await db.SaveChangesAsync();

            }

            return item;
        }



        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            var options = optionsBuilder.UseSqlServer(_connectionString)
              .Options;
            return options;
        }

        public int Count()
        {

            using (var db = new DataToDoListContext(Options()))
            {
                int count = 0;

                List<Entites.Category> categories = db.Categories.ToList();

                foreach (Task item in db.Tasks.ToList())
                {
                    if (item.CategoryId == categories.FirstOrDefault().Id)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }
    }
}

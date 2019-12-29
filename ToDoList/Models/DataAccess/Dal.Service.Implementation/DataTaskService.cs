
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



        public int GetCategoryTasksCountAll()
        {
            var res = GetTaskList().Result;
            int countAll = 0;

            foreach (Task item in res)
            {
                ++countAll;
            }
            return countAll;
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

        public async Task<List<Task>> GetTaskList()
        {
            using (var db = new DataToDoListContext(Options()))
            {
                return await db.Tasks.ToListAsync();
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


    }
}

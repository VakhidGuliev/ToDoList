using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Models.DataAccess.Dal.Entites;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.DataAccess.Data;

namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    public class CategoryDataService : IDataCategoryService
    {
        private readonly string _connectionString;

        private DataToDoListContext Context { get; }

        public CategoryDataService(IConfiguration configuration, DataToDoListContext context)
        {
            Context = context;
            _connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            var options = optionsBuilder.UseSqlServer(_connectionString)
                .Options;
            return options;
        }

        public bool CreateCategory(Category category)
        {
            var isCheck = Context.Categories.Any(x => x.Name == category.Name);

            if (isCheck)
            {
                return false;
            }

            using (var db = new DataToDoListContext(Options()))
            {

                if (!db.Categories.Contains(category))
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"{category.Name} is already exist in DataBase, please crete another name");
                }
            }

            return true;
        }

        public IEnumerable<Category> Categories()
        {
            using (var db = new DataToDoListContext(Options()))
            {

                return db.Categories.ToList();
            }

        }

        public async Task<Category> UpdateCategory(Category category)
        {
            if (category.Name != null)
            {
                using (var db = new DataToDoListContext(Options()))
                {

                   db.Categories.Update(category);
                  await db.SaveChangesAsync();

                }
            }
            return category;
        }
        public async void DeleteCategory(int? id)
        {

            using (var db = new DataToDoListContext(Options()))
            {

                var category = await db.Categories
               .FirstOrDefaultAsync(m => m.Id == id);
                db.Categories.Remove(category);
                await db.SaveChangesAsync();

            }

        }
    }
}
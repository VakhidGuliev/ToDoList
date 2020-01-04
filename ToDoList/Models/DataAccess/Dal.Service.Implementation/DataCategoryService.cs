namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;

    public class DataCategoryService : IDataCategoryService
    {
        private readonly string _connectionString;
        //  private readonly IDataAppRole _dataAppRole;
        private DataToDoListContext Context { get; }

        public DataCategoryService(IConfiguration configuration, DataToDoListContext context)
        {
            Context = context;
            _connectionString = configuration.GetConnectionString("DataToDoListContext");
            // _dataAppRole = dataAppRole;
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

            using (var db = new DataToDoListContext(Options()))
            {

                User user = db.Users.FirstOrDefault(x => x.UserAccountId == category.UserAccountId);
                var isContains = false;
                var names = db.Categories.Where(x => x.UserAccountId == category.UserAccountId).ToList();
                foreach (var item in names)
                {
                    if (item.Name.Contains(category.Name))
                    {
                        isContains = true;
                    }
                }
                var isChek = Categories(user.UserAccountId).FirstOrDefault(x => x.Name == category.Name);
      
                if (!isContains)
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

        public List<Category> Categories(int? userAccountId)
        {
             using (var db = new DataToDoListContext(Options()))
                {
                    User getUser = db.Users.FirstOrDefault(x => x.UserAccountId == userAccountId);

                     List<Category> categories = new List<Category>();

                    foreach (Category item in db.Categories.ToList())
                    {
                        if (item.UserAccountId == userAccountId)
                        {
                            categories.Add(item);
                        }

                    }
                    
                    return categories;
                }
        }
         

        



        public Category UpdateCategory(Category category)
        {
            if (category.Name != null)
            {
                using (var db = new DataToDoListContext(Options()))
                {

                    db.Categories.Update(category);
                    db.SaveChangesAsync();

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

        public int Count(int userAccountId)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                int count = 0;

                Category cateories = db.Categories.FirstOrDefault(x => x.UserAccountId == userAccountId);

                foreach (var item in db.Categories.ToList())
                {
                    if (db.Categories.Contains(cateories))
                    {
                        ++count;
                    }
                }
                return count;
            }
        }


    }
}
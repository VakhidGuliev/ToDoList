namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;

    public class CategoryDataService :IDataCategoryService
    {
        private readonly string connectionString;

        public DataToDoListContext Context { get; }

        public CategoryDataService( IConfiguration configuration , DataToDoListContext context)
        {
            this.Context = context;
            this.connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            DbContextOptions<DataToDoListContext> options = optionsBuilder.UseSqlServer(this.connectionString)
                .Options;
            return options;
        }

        public async Task<bool> CreateCategory(Category category)
        {
           var isChek = await this.Context.Categories.AnyAsync(x => x.Name == category.Name);

           if (isChek)
            {
                return false;
            }

              using (var db = new DataToDoListContext(this.Options()))
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
             }

           return true;
        }
    }
}
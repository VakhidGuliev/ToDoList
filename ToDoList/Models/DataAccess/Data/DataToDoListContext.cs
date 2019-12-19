using Microsoft.EntityFrameworkCore;
using ToDoList.Models.DataAccess.Dal.Entites;

namespace ToDoList.Models.DataAccess.Data
{
    #region DataToDoListContext
    public class DataToDoListContext : DbContext
    {
        public DataToDoListContext(DbContextOptions<DataToDoListContext> options)
                   : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> TasksList { get; set; }
        
    }
    #endregion
}

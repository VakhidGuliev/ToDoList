using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    public class DbToDoListContext : DbContext
    {
        public DbToDoListContext(DbContextOptions<DbToDoListContext> options)
            : base(options)
        {
        }

        public DbSet<Models.User> User { get; set; }
    }
}

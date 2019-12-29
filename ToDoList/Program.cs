using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ToDoList
{
    #region Program
    public class Program
    {
        public static void Main(string[] args)
        {
           CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
    #endregion
}
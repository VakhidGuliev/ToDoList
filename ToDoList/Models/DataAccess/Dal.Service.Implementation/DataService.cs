// <copyright file="DataService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.DataAccess.Data;

    public class DataService : IDataAuthUserService
    {
        private readonly string connectionString;

        public DataService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DataToDoListContext");
        }

        public void Create(AuthUser user)
        {
            using (var db = new DataToDoListContext(Options()))
            {
                if (!db.AuthUser.Contains(user))
                {
                    db.AuthUser.Add(user);
                    db.SaveChanges();
                }

            }
        }

        public List<AuthUser> GetAuthUsers()
        {
            using (var db = new DataToDoListContext(Options()))
            {
                return db.AuthUser.ToList();
            }
        }

        private DbContextOptions<DataToDoListContext> Options()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataToDoListContext>();
            DbContextOptions<DataToDoListContext> options = optionsBuilder.UseSqlServer(this.connectionString)
              .Options;
            return options;
        }
    }
}

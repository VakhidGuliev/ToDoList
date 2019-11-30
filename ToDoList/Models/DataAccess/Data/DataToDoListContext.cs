// <copyright file="DataToDoListContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.DataAccess.Data
{
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Models.DataAccess.Dal.Entites;

    public class DataToDoListContext : DbContext
    {
        public DataToDoListContext(DbContextOptions<DataToDoListContext> options)
                   : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<AuthUser> AuthUser { get; set; }
    }
}

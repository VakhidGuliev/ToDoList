// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.Business.Service.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Implementation.Converters;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;

    public class RegistrationUserService : IRegistrationUserService
    {
        private readonly IDataRegistrationUserService dataService;

        public RegistrationUserService(IDataRegistrationUserService dataService)
        {
            this.dataService = dataService;
        }

        public void Create(RegistrationUser authUser)
        {
            var today = DateTime.Today;

            var user = UserConverter.FromBlToDl(authUser, today);

            this.dataService.Create(user);
        }

        public List<RegistrationUser> GetAuthUsers()
        {
            List<DataAccess.Dal.Entites.RegistrationUser> data = this.dataService.GetAuthUsers();
            var today = DateTime.Today;
            return data.Select(dbData => UserConverter.FromDalToBl(dbData, today)).ToList();
        }
    }
}

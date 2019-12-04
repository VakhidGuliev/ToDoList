// <copyright file="IDataAuthUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using System.Collections.Generic;
    using ToDoList.Models.DataAccess.Dal.Entites;

    public interface IDataRegistrationUserService
    {
        void Create(RegistrationUser user);

        List<RegistrationUser> GetAuthUsers();
    }
}

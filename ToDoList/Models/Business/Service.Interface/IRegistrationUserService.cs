// <copyright file="IAuthUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.Business.Service.Interface
{
    using System.Collections.Generic;
    using ToDoList.Models.Business.Entites;

    public interface IRegistrationUserService
    {
        void Create(RegistrationUser authUser);

        List<RegistrationUser> GetRegistrationUsers();
    }
    }

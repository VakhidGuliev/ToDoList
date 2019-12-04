// <copyright file="AuthUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.Business.Entites
{
    using System;

    public class RegistrationUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}

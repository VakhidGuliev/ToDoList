// <copyright file="AuthUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.DataAccess.Dal.Entites
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AuthUser
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}

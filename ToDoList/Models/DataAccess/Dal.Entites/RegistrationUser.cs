// <copyright file="AuthUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ToDoList.Models.DataAccess.Dal.Entites
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegistrationUser
    {
        public int Id { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Required(ErrorMessage = "Missing Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Missing FirstName")]
        [MinLength(3)]
        [StringLength(16)]
        public string FirstName { get; set; }

        [StringLength(16)]
        [MinLength(3)]
        [Required(ErrorMessage = "Missing LastName")]
        public string LastName { get; set; }

        [StringLength(16)]
        [MinLength(3)]
        [Required(ErrorMessage = "Missing Password")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [StringLength(16)]
        [MinLength(3)]
        [Compare("Password")]
        [Required(ErrorMessage = "Missing ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Missing DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}

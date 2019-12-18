﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.DataAccess.Dal.Entites
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(100)]

        [EmailAddress(ErrorMessage = "Email not correct")]

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

        [StringLength(30)]

        [Required(ErrorMessage = "Missing Password")]

        [Compare("ConfirmPassword")]

        public string Password { get; set; }

        [StringLength(30)]

        [Compare("Password")]

        [Required(ErrorMessage = "Missing ConfirmPassword")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Missing DateOfBirth")]

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public enum Role
        {
            Admin,
            User,
            Moderator
        }
    }
}

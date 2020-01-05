using System;

namespace ToDoList.Models.Business.Entites
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public  int UserAccountId { get; set; }
        
        public int Phone { get; set; }
  
    }
}

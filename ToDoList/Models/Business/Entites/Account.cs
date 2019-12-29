using System.Collections.Generic;

namespace ToDoList.Models.Business.Entites
{
    // Not using
    public class Account
    {
      public int Id { get; set; }

        private Dictionary<int, User> UsersAcounts { get; set; }
    }
}

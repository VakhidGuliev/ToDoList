using System.Collections.Generic;

namespace ToDoList.Models.DataAccess.Dal.Entites
{
    public class Account
    {
        public int Id { get; set; }

        public List<User> User { get; set; }
    }
}

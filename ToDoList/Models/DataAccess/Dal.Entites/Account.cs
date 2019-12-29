namespace ToDoList.Models.DataAccess.Dal.Entites
{
    using System.Collections.Generic;

    public class Account
    {
        public int Id { get; set; }

        public List<User> User { get; set; }
    }
}

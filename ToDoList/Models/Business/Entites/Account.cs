namespace ToDoList.Models.Business.Entites
{
    using System.Collections.Generic;

    public class Account
    {

        Dictionary<int, User> UsersAcounts { get; set; }
    }
}

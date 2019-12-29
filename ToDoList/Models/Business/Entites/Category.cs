using System.Collections.Generic;

namespace ToDoList.Models.Business.Entites
{
    public class Category
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public string Name { get; set; }

        public List<Task> Tasks;
    }
}
using System.Collections.Generic;

namespace ToDoList.Models.Business.Entites
{
    public class Category
    {
        public string Name { get; set; }
        public List<Task> Tasks;
    }
}
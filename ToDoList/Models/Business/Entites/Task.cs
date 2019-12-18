using System.Collections.Generic;

namespace ToDoList.Models.Business.Entites
{
    public class Task
    {
        public string Name { get; set; }
        public List<Task> Tasks;
    }
}

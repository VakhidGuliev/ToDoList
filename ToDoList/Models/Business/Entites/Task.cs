namespace ToDoList.Models.Business.Entites
{

    using System.Collections.Generic;

    public class Task
    {
        public string Name { get; set; }
        public List<Task> Tasks;
    }
}

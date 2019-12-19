using System.Collections.Generic;

namespace ToDoList.Models.Business.Entites
{
    public class Tasks
    {
        public string Name { get; set; }
        public List<Tasks> TaskList;
    }
}

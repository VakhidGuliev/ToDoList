using System.Collections.Generic;

namespace ToDoList.Models.Business.Entites
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tasks> Tasks;
    }
}
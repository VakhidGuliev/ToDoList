namespace ToDoList.Models.Business.Entites
{
    using System;

    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime DurationTime { get; set; }
        
        public int UserAccountId { get; set; }
        public int CategoryId { get; set; }
        
    }
}

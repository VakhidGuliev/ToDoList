namespace ToDoList.Models.DataAccess.Dal.Entites
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        [Required]

        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime DurationTime { get; set; }

    }
   
}
using System.Collections.Generic;

namespace ToDoList.Models.DataAccess.Dal.Entites
{
    // Not using
    #region Task
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks;
    }
    #endregion
}
namespace ToDoList.Models.DataAccess.Dal.Service.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Task = Entites.Task;

    public interface IDataTaskService
    {

        Task<List<Task>> GetTaskList(int userAccountId);
        
        Task GetTask(int id); 

        void CreateTask(Task item);

        Task<Task> UpdateTask(Task item);

        void DeleteTask(int id);

        int Count();
   
    }
}

using System.Collections.Generic;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{
   public interface ITaskService
    {
        System.Threading.Tasks.Task<List<Task>> GetTaskList(int userAccountId);

        void GetCategoryTasksCount();

        Task GetTask(int id);

        void CreateTask(Task item);

        void UpdateTask(Task item);

        void DeleteTask(int id);
        int Count();
    }
}

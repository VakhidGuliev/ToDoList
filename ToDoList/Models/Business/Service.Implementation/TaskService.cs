namespace ToDoList.Models.Business.Service.Implementation
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interface;
    using System.Threading.Tasks;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.Helpers;

    public class TaskService : ITaskService
    {
        private readonly IDataTaskService _dataTaskService;

        public TaskService(IDataTaskService dataTaskService)
        {
            _dataTaskService = dataTaskService;
        }

        public int Count()
        {
          return  _dataTaskService.Count();
        }

        public async void CreateTask(Entites.Task item)
        {
           var convert = CommonConverter.FromBlToDal(item);

           await Task.Run(() => _dataTaskService.CreateTask(convert));
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public void GetCategoryTasksCount()
        {
            throw new NotImplementedException();
        }

        public Entites.Task GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entites.Task>> GetTaskList(int userAccountId)
        {
            return await Task.Run(() => _dataTaskService.GetTaskList(userAccountId).Result.Select(CommonConverter.FromDalToBl).ToList());
        }

        public void UpdateTask(Entites.Task item)
        {
            throw new NotImplementedException();
        }

    }
}

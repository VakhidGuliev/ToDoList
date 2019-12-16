namespace ToDoList.Models.Business.Service.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Implementation.Converters;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;

    public class UserService : IUserService
    {
        private readonly IDataUserService dataUserService;

        public UserService(IDataUserService dataUserService)
        {
            this.dataUserService = dataUserService;
        }

        public async void Create(User authUser)
        {
            await Task.Run(()=>dataUserService.Create(UserConverter.FromDalToBl(authUser, DateTime.Today)));
        }

        public async Task<List<User>> GetRegistrationUsers()
        {
         return  await Task.Run(()=> this.dataUserService.GetRegistrationUsers().Result.
             Select(dbData => UserConverter.FromBlToDal(dbData, DateTime.Today)).ToList());
        }
    }
}

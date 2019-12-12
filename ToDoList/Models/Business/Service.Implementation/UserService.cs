namespace ToDoList.Models.Business.Service.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public void Create(User authUser)
        {
            this.dataUserService.Create(UserConverter.FromDalToBl(authUser, DateTime.Today));
        }

        public List<User> GetRegistrationUsers() =>
         this.dataUserService.GetRegistrationUsers().
                Select(dbData => UserConverter.FromBlToDal(dbData, DateTime.Today)).ToList();
    }
}

using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.Helpers;

namespace ToDoList.Models.Business.Service.Implementation
{
   
    public class AccountService : IAccountService
    {
        private readonly IDataAccountService _dataAccountService;
        public AccountService(IDataAccountService dataAccountService)
        {
            _dataAccountService = dataAccountService;
        }
        public User InsertToAccount(string email, string password) =>
                    CommonConverter.FromDalToBl(_dataAccountService.InsertToAccount(email, password));


    }
}

using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Implementation.Converters;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;

namespace ToDoList.Models.Business.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDataAuthentication _dataService;

        public AuthenticationService(IDataAuthentication dataService)
        {
            this._dataService = dataService;
        }
        public bool SignIn(string email, string password) => this._dataService.SignIn(email, password);
        
           
        
    
        }
    }


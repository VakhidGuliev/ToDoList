namespace ToDoList.Models.Business.Service.Implementation
{

    using System.Threading.Tasks;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;
    using ToDoList.Models.Helpers;

    public class EmailService : IEmailService
    {
        private readonly IDataEmailService _dataEmailService;
        public EmailService(IDataEmailService dataEmailService)
        {
            _dataEmailService = dataEmailService;
        }
        public EmailSetting GetEmailSettings() =>
               CommonConverter.FromDalToBl(_dataEmailService.GetEmailSettings());


        public async Task<string> SendEmailAsync(string email, string subject, string message) =>
               await System.Threading.Tasks.Task.Run(() => _dataEmailService.SendEmailAsync(email, subject, message));

    }
}



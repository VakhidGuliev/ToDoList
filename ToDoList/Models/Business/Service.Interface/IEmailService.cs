using System.Threading.Tasks;
using ToDoList.Models.Business.Entites;

namespace ToDoList.Models.Business.Service.Interface
{


    public interface IEmailService
    {
        Task<string> SendEmailAsync(string email, string subject, string message);
        EmailSetting GetEmailSettings();
    }

  
}

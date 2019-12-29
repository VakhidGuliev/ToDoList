namespace ToDoList.Models.DataAccess.Dal.Service.Implementation
{

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Options;
    using MimeKit;
    using System;
    using ToDoList.Models.DataAccess.Dal.Entites;
    using ToDoList.Models.DataAccess.Dal.Service.Interface;

    public class DataEmailSenderService : IDataEmailService 
    {
        private readonly EmailSetting _emailSettings;
        private readonly IHostingEnvironment _env;
      
        public DataEmailSenderService(IOptions<EmailSetting> emailSettings, IHostingEnvironment env)
        {
            _emailSettings = emailSettings.Value;
            _env = env;

        }
        public async System.Threading.Tasks.Task<string> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                string status = "";

                if (mimeMessage.Date.DateTime.ToShortTimeString().Equals(_emailSettings.TimeSender))
                {
                    mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));

                    mimeMessage.To.Add(new MailboxAddress(email));

                    mimeMessage.Subject = subject;

                    mimeMessage.Body = new TextPart("html")
                    {
                        Text = message
                    };
                 


                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {

                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        if (_env.IsDevelopment())
                        {
                          await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true);
                        }
                        else
                        {
                            await client.ConnectAsync(_emailSettings.MailServer);
                        }

                        await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);

                        await client.SendAsync(mimeMessage);

                        await client.DisconnectAsync(true);
                    }
                  return  status = "Ok";
                }
                else
                {
                    status = "Not Found";

                    return  status;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public EmailSetting GetEmailSettings()
        {
           return _emailSettings;
        }
    }
}

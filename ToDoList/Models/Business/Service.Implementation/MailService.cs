//using Microsoft.Extensions.Logging;
//using System;
//using System.IO;
//using System.Linq;
//using System.Net.Mail;
//using System.Text;
//using System.Text.RegularExpressions;
//using ToDoList.Models.Business.Service.Interface;

//namespace ToDoList.Models.Business.Service.Implementation
//{
//    public class MailService : IMailService
//    {
//        private readonly IDomainSettings domainSettings;
//        private readonly ILogger logger;

//        public MailService(IDomainSettings domainSettings, ILogger logger)
//        {
//            this.domainSettings = domainSettings;
//            this.logger = logger;
//        }
//        public void Send(string to, string from, string subject, string body, bool isBodyHtml = false, bool useRestrictedEmailList = true)
//        {
//            if (string.IsNullOrEmpty(to))
//            {
//                logger.WarnFormat("Email address is empty.");
//            }

//            using (var smtpClient = new SmtpClient(domainSettings.SmtpServer))
//            {
//                var mailMessage = new MailMessage
//                {
//                    From = new MailAddress(from),
//                    Subject = subject,
//                    Body = body,
//                    IsBodyHtml = isBodyHtml
//                };
//                string[] mails = to.Split(';');
//                foreach (string mail in mails)
//                {
//                    if (mail.IsEmail() && !useRestrictedEmailList)
//                    {
//                        mailMessage.To.Add(mail);
//                    }
//                    else if (mail.IsEmail()
//                        && (!domainSettings.RestrictedEmailList.Any()
//                            || domainSettings.RestrictedEmailList.Contains(mail, StringComparer.OrdinalIgnoreCase)))
//                    {
//                        mailMessage.To.Add(mail);
//                    }
//                }

//                if (mailMessage.To.Count > 0)
//                {
//                    smtpClient.Send(mailMessage);
//                }
//            }
//        }


//        public void Send(string to, string subject, string body, MemoryStream attachment, bool isBodyHtml = false)
//        {

//            if (string.IsNullOrEmpty(to))
//            {
//                logger.WarnFormat("Email address is empty.");
//            }

//            using (var smtpClient = new SmtpClient(domainSettings.SmtpServer))
//            {
//                var mailMessage = new MailMessage
//                {
//                    From = new MailAddress(domainSettings.UnityExceptionNotificationSenderEmail),
//                    Subject = subject,
//                    Body = body,
//                    IsBodyHtml = isBodyHtml,
//                    BodyEncoding = Encoding.GetEncoding("utf-8")
//                };

//                AlternateView plainView = AlternateView
//                    .CreateAlternateViewFromString(Regex.Replace(body, @"<(.|\n)*?>", string.Empty), null, "text/plain");
//                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
//                mailMessage.AlternateViews.Add(plainView);
//                mailMessage.AlternateViews.Add(htmlView);

//                string[] mails = to.Split(';');
//                foreach (string mail in mails)
//                {
//                    if (mail.IsEmail())
//                    {
//                        mailMessage.To.Add(mail);
//                    }
//                }

//                var mailAttachment = new Attachment(attachment, "xlsx");

//                mailAttachment.ContentDisposition.FileName = string
//                    .Format("{0}_{1}.xlsx", domainSettings.UnityExceptionNotificationFileName, DateTime.Now.ToString("MMddyyyy"));

//                mailMessage.Attachments.Add(mailAttachment);

//                if (mailMessage.To.Count > 0)
//                {
//                    smtpClient.Send(mailMessage);
//                }
//            }
//        }
//    }
//}


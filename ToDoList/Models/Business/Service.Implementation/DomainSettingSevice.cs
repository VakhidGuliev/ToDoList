// Not using

//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Linq;
//using ToDoList.Models.Business.Service.Interface;

//namespace ToDoList.Models.Business.Service.Implementation
//{
//    public class DomainSetting : IDomainSettings
//    {
//        private readonly IGenericSettings genericSettings;
//        private readonly ILogger logger;

//        public DomainSetting(IGenericSettings genericSettings, ILogger logger = null)
//        {
//            this.genericSettings = genericSettings;
//            this.logger = logger;
//        }

//        public string ApplicationName
//        {
//            get { return genericSettings.ReadString("ApplicationName"); }
//        }



//        public string SmtpServer
//        {
//            get { return genericSettings.ReadString("SmtpServer"); }
//        }

//        public string UnityExceptionNotificationReceiverEmail
//        {
//            get { return genericSettings.ReadString("UnityException.NotificationReceiverEmail"); }
//        }

//        public string UnityExceptionNotificationSenderEmail
//        {
//            get { return genericSettings.ReadString("UnityException.NotificationSenderEmail"); }
//        }


//        public List<string> RestrictedEmailList
//        {
//            get
//            {
//                string emailList = genericSettings.ReadString("EmailRestrictedList");
//                if (string.IsNullOrWhiteSpace(emailList))
//                {
//                    return new List<string>();
//                }

//                return emailList.Split(';').ToList();
//            }
//        }

//        public string MercerFlowEmailSender
//        {
//            get { return genericSettings.ReadString("MercerFlowEmailSender"); }
//        }





//        public string CPMarketplaceOEDateChangesEmailList
//        {
//            get { return genericSettings.ReadString("CP.MarketplaceOEDateChangesEmailList"); }
//        }

//        public string MM365DefaultReceiverEmailList
//        {
//            get { return genericSettings.ReadString("MM365.DefaultReceiverEmailList"); }
//        }

//        public string ConsultingDefaultReceiverEmailList
//        {
//            get { return genericSettings.ReadString("Consulting.DefaultReceiverEmailList"); }
//        }





//        public IDictionary<string, string> DefectFileLoadingAccountInfo
//        {
//            get
//            {
//                return new Dictionary<string, string>
//                {
//                    { "ExchangeServer", genericSettings.ReadString("DefectFileLoading.EmailExchangeServer") },
//                    { "EmailAccount", genericSettings.ReadString("DefectFileLoading.EmailWatcherAccount") },
//                    { "UserName", genericSettings.ReadString("DefectFileLoading.EmailUserName") },
//                    { "UserPassword", genericSettings.ReadString("DefectFileLoading.EmailUserPassword") },
//                    { "UserDomain", genericSettings.ReadString("DefectFileLoading.EmailUserDomain") }
//                };
//            }
//        }
//    }
//}


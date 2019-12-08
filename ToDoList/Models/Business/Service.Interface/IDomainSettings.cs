namespace ToDoList.Models.Business.Service.Interface
{
    using System;
    using System.Collections.Generic;
    public interface IDomainSettings
    {
        /// <summary>
        ///     Gets the name of the application.
        /// </summary>
        /// <value>
        ///     The name of the application.
        /// </value>
        string ApplicationName { get; }

        /// <summary>
        ///     Gets the name of the cordys user.
        /// </summary>
        /// <value>
        ///     The name of the cordys user.
        /// </value>
        string CordysUserName { get; }

        /// <summary>
        ///     Gets the cordys password.
        /// </summary>
        /// <value>
        ///     The cordys password.
        /// </value>
        string CordysPassword { get; }

        /// <summary>
        ///     Gets the cordys timeout.
        /// </summary>
        /// <value>
        ///     The cordys timeout.
        /// </value>
        string CordysTimeout { get; }

        /// <summary>
        ///     Gets the cordys URL prefix.
        /// </summary>
        /// <value>
        ///     The cordys URL prefix.
        /// </value>
        string CordysUrlPrefix { get; }

        /// <summary>
        ///     Gets the organization dn.
        /// </summary>
        /// <value>
        ///     The organization dn.
        /// </value>
        string OrganizationDN { get; }

        /// <summary>
        ///     Gets the cordys mercer gateway.
        /// </summary>
        /// <value>
        ///     The cordys mercer gateway.
        /// </value>
        string CordysMercerGateway { get; }

        /// <summary>
        ///     Gets the user dn pattern.
        /// </summary>
        /// <value>
        ///     The user dn pattern.
        /// </value>
        string UserDnPattern { get; }

        /// <summary>
        ///     Gets the SmtpServer.
        /// </summary>
        /// <value>
        ///     The SmtpServer.
        /// </value>
        string SmtpServer { get; }

        /// <summary>
        ///     Gets the UnityExceptionNotificationReceiverEmail.
        /// </summary>
        /// <value>
        ///     The UnityExceptionNotificationReceiverEmail.
        /// </value>
        string UnityExceptionNotificationReceiverEmail { get; }

        /// <summary>
        ///     Gets the UnityExceptionNotificationSenderEmail.
        /// </summary>
        /// <value>
        ///     The UnityExceptionNotificationSenderEmail.
        /// </value>
        string UnityExceptionNotificationSenderEmail { get; }

        /// <summary>
        ///     Gets the UnityExceptionNotificationSubject.
        /// </summary>
        /// <value>
        ///     The UnityExceptionNotificationSubject.
        /// </value>
        string UnityExceptionNotificationSubject { get; }

        /// <summary>
        ///     Gets the UnityExceptionNotificationFileName.
        /// </summary>
        /// <value>
        ///     The UnityExceptionNotificationFileName.
        /// </value>
        string UnityExceptionNotificationFileName { get; }

        /// <summary>
        ///     Gets the restricted email list.
        /// </summary>
        /// <value>
        ///     The restricted list.
        /// </value>
        List<string> RestrictedEmailList { get; }

        /// <summary>
        ///     Gets the list of holidays.
        /// </summary>
        /// <value>
        ///     The list of holidays.
        /// </value>
        List<DateTime> LargeMarketListOfHolidays { get; }

        /// <summary>
        ///     Gets the list of holidays.
        /// </summary>
        /// <value>
        ///     The list of holidays.
        /// </value>
        List<DateTime> MM365ListOfHolidays { get; }

        /// <summary>
        ///     Gets the mercer flow email sender.
        /// </summary>
        /// <value>
        ///     The mercer flow email sender.
        /// </value>
        string MercerFlowEmailSender { get; }

        /// <summary>
        ///     Gets the ticket range start date to search iSupport tickets within range.
        /// </summary>
        /// <value>
        ///     The ticket range start date.
        /// </value>
        string TicketRangeStart { get; }

        /// <summary>
        ///     Gets the ticket range end date to search iSupport tickets within range.
        /// </summary>
        /// <value>
        ///     The ticket range end date.
        /// </value>
        string TicketRangeEnd { get; }

        /// <summary>
        ///     Gets the category to search iSupport tickets
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportParentCategory { get; }

        /// <summary>
        ///     Gets the category level 2 to search iSupport tickets
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportCategoryLevelSecond { get; }

        /// <summary>
        ///     Gets the category level 3 to search iSupport tickets
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportCategoryLevelThird { get; }

        /// <summary>
        ///     Gets the category level 4 to search iSupport tickets
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        List<string> ISupportCategoryLevelFourth { get; }

        /// <summary>
        ///     Gets the OutboundSubSytem field name
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportOutboundSubSytemField { get; }

        /// <summary>
        ///     Gets the list of Task Unique keys for WebDelivery.
        /// </summary>
        /// <value>
        ///     The list of Web Delivery keys.
        /// </value>
        List<string> WebDeliveryTasksUniqueKeys { get; }

        /// <summary>
        ///     Gets the list of Task Unique keys for BW.
        /// </summary>
        /// <value>
        ///     The list of BW keys.
        /// </value>
        List<string> BWTasksUniqueKeys { get; }

        /// <summary>
        ///     Gets the outgoing workflow dashboard minimum date.
        /// </summary>
        /// <value>
        ///     The outgoing workflow dashboard minimum date.
        /// </value>
        DateTime OutgoingWorkflowMinDate { get; }

        /// <summary>
        ///     Gets the category to search iSupport changes
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportChangeParentCategory { get; }

        /// <summary>
        ///     Gets the category level 2 to search iSupport changes
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportChangeCategoryLvlSecond { get; }

        /// <summary>
        ///     Gets the category level 3 to search iSupport changes
        /// </summary>
        /// <value>
        ///     The ticket category.
        /// </value>
        string ISupportChangeCategoryLvlThird { get; }

        /// <summary>
        ///     Gets the unity exception upload user.
        /// </summary>
        /// <value>
        ///     The unity exception upload user.
        /// </value>
        string CPUnitySiteUploadUser { get; }

        /// <summary>
        ///     Gets the unity exception upload password.
        /// </summary>
        /// <value>
        ///     The unity exception upload password.
        /// </value>
        string CPUnitySiteUploadPassword { get; }

        /// <summary>
        ///     Gets the unity exception upload report identifier.
        /// </summary>
        /// <value>
        ///     The unity exception upload report identifier.
        /// </value>
        string CPUnitySiteUploadReportId { get; }

        /// <summary>
        ///     Gets the OutboundSubSytem field name for changes
        /// </summary>
        /// <value>
        ///     The Change category.
        /// </value>
        string ISupportChangeSubSytemField { get; }

        /// <summary>
        ///     Gets the cp marketplace share point link.
        /// </summary>
        /// <value>
        ///     The cp marketplace share point link.
        /// </value>
        string CpMarketplaceSharePointLink { get; }

        /// <summary>
        ///     Gets the cp marketplace share point login.
        /// </summary>
        /// <value>
        ///     The cp marketplace share point login.
        /// </value>
        string CpMarketplaceSharePointLogin { get; }

        /// <summary>
        ///     Gets the cp marketplace share point password.
        /// </summary>
        /// <value>
        ///     The cp marketplace share point password.
        /// </value>
        string CpMarketplaceSharePointPassword { get; }

        /// <summary>
        ///     Gets the current environment.
        /// </summary>
        /// <value>
        ///     The current environment.
        /// </value>
        string Environment { get; }

        /// <summary>
        ///     Gets the cp unity site export URL.
        /// </summary>
        /// <value>
        ///     The cp unity site export URL.
        /// </value>
        string CPUnitySiteExportUrl { get; }

        /// <summary>
        ///     Gets the cp marketplace oe date changes email list.
        /// </summary>
        /// <value>
        ///     The cp marketplace oe date changes email list.
        /// </value>
        string CPMarketplaceOEDateChangesEmailList { get; }

        /// <summary>
        ///     Gets the m M365 default receiver email list.
        /// </summary>
        /// <value>
        ///     The m M365 default receiver email list.
        /// </value>
        string MM365DefaultReceiverEmailList { get; }

        /// <summary>
        /// Gets the Consulting default receiver email list.
        /// </summary>
        /// <value>
        /// The Consulting default receiver email list.
        /// </value>
        string ConsultingDefaultReceiverEmailList { get; }

        /// <summary>
        ///     Allows to use raw SQL in reports.
        /// </summary>
        /// <value>
        ///     Switch value.
        /// </value>
        bool CPUseRawSqlInReports { get; }

        /// <summary>
        /// Gets the consulting effective date task.
        /// </summary>
        /// <value>
        /// The consulting effective date task.
        /// </value>
        string ConsultingEffectiveDateTask { get; }

        /// <summary>
        /// Gets the cp marketplace share point client basics tab.
        /// </summary>
        /// <value>
        /// The cp marketplace share point client basics tab.
        /// </value>
        string CpMarketplaceSharePointClientBasicsTab { get; }

        /// <summary>
        /// Gets the cp marketplace share point people counts tab.
        /// </summary>
        /// <value>
        /// The cp marketplace share point people counts tab.
        /// </value>
        string CpMarketplaceSharePointPeopleCountsTab { get; }

        /// <summary>
        /// Gets the cp marketplace share point team members tab.
        /// </summary>
        /// <value>
        /// The cp marketplace share point team members tab.
        /// </value>
        string CpMarketplaceSharePointTeamMembersTab { get; }

        /// <summary>
        /// Gets the cp marketplace share point open enrollment dates tab.
        /// </summary>
        /// <value>
        /// The cp marketplace share point open enrollment dates tab.
        /// </value>
        string CpMarketplaceSharePointOpenEnrollmentDatesTab { get; }

        /// <summary>
        /// The oe update plan coordinators
        /// </summary>
        List<string> OeUpdatePlanCoordinators { get; }

        /// <summary>
        /// Defect file loading Account Info
        /// </summary>
        IDictionary<string, string> DefectFileLoadingAccountInfo { get; }
    }
}

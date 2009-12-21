using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models;
using TFS.Web.ActionFilters;
using TFS.Web.ViewModels.Messages;
using TFS.Models.Messages;
using AutoMapper;
using TFS.Web.ViewModels;
using NHibernate;
using TFS.Extensions;

namespace TFS.Web.Controllers
{
    [Authorize, UnitOfWork]
    public partial class MessagesController : Controller
    {
        private readonly ISession session;
        private readonly IMessagesRepository messagesRepository;

        public MessagesController(ISession session, IMessagesRepository messagesRepository)
        {
            this.session = session;
            this.messagesRepository = messagesRepository;
        }

        public virtual ViewResult ListMessages()
        {
            var viewModel = new SortedListViewModel<MessageViewModel>();
            var allRecentMessages = messagesRepository.GetAllActiveNonUserMessages();
            var announcements = allRecentMessages.Where(x => x.MessageType == MessageType.Announcement).Cast<Announcement>();
            var systemAlerts = allRecentMessages.Where(x => x.MessageType == MessageType.SystemAlert).Cast<SystemAlert>();
            var messages = Mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementViewModel>>(announcements).Cast<MessageViewModel>()
                   .Concat(Mapper.Map<IEnumerable<SystemAlert>, IEnumerable<SystemAlertViewModel>>(systemAlerts).Cast<MessageViewModel>());
            messages = messages.OrderByDescending(x => x.ActiveFromDate);
            viewModel.SetItems(messages);
            ViewData["CanEdit"] = DetermineCanEdit();
            return View(Views.ListMessages, viewModel);
        }

        public virtual ViewResult ListAllMessages(MessageType messageType)
        {
            var viewModel = new SortedListViewModel<MessageViewModel>();
            IEnumerable<MessageViewModel> messages;
            switch (messageType)
            {
                case MessageType.Announcement:
                    var announcements = messagesRepository.GetAllAnnouncements();
                    messages = Mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementViewModel>>(announcements).Cast<MessageViewModel>();
                    break;
                case MessageType.SystemAlert:
                    var systemAlerts = messagesRepository.GetAllSystemAlerts();
                    messages = Mapper.Map<IEnumerable<SystemAlert>, IEnumerable<SystemAlertViewModel>>(systemAlerts).Cast<MessageViewModel>();
                    break;
                default:
                    throw new InvalidOperationException("Invalid Message Type");
            }
            messages = messages.OrderByDescending(x => x.ActiveFromDate);
            viewModel.SetItems(messages);
            ViewData["CanEdit"] = DetermineCanEdit();
            return View(Views.ListMessages, viewModel);
        }

        public virtual ViewResult CreateMessage(MessageType messageType)
        {
            MessageViewModel viewModel = null;
            switch (messageType)
            {
                case MessageType.Announcement:
                    viewModel = new AnnouncementViewModel();
                    break;
                case MessageType.SystemAlert:
                    viewModel = new SystemAlertViewModel();
                    break;
                default:
                    throw new InvalidOperationException("Invalid Message Type");
            }
            return View(Views.CreateMessage, viewModel);
        }

        public virtual ViewResult ViewMessage(int id)
        {
            var message = session.Get<Message>(id);
            MessageViewModel viewModel = null;
            switch (message.MessageType)
            {
                case MessageType.Announcement:
                    viewModel = Mapper.Map<Announcement, AnnouncementViewModel>((Announcement)message);
                    break;
                case MessageType.SystemAlert:
                    viewModel = Mapper.Map<SystemAlert, SystemAlertViewModel>((SystemAlert)message);
                    break;
                case MessageType.UserAlert:
                    viewModel = Mapper.Map<UserAlert, UserAlertViewModel>((UserAlert)message);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Message Type");
            }
            viewModel.CanEdit = DetermineCanEdit();
            return View(Views.ViewMessage, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateAnnouncement(AnnouncementViewModel announcementViewModel)
        {
            this.Validate(announcementViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateMessage, announcementViewModel);
            var announcement = Mapper.Map<AnnouncementViewModel, Announcement>(announcementViewModel);
            announcement.CreatedBy = this.GetCurrentUser();
            announcement.ActiveFromDate = DateTime.Today.ToUniversalTime().WithoutMilliseconds();
            session.Save(announcement);
            return RedirectToAction(MVC.Dashboard.Index());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateSystemAlert(SystemAlertViewModel systemAlertViewModel)
        {
            this.Validate(systemAlertViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateMessage, systemAlertViewModel);
            var aystemAlert = Mapper.Map<SystemAlertViewModel, SystemAlert>(systemAlertViewModel);
            aystemAlert.ActiveFromDate = DateTime.Today.ToUniversalTime().WithoutMilliseconds();
            session.Save(aystemAlert);
            return RedirectToAction(MVC.Dashboard.Index());
        }

        [NonAction]
        private bool DetermineCanEdit()
        {
            return this.GetCurrentUser().Roles.ProgramManager;
        }
    }
}

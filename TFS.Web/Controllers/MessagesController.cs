using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using TFS.Extensions;
using TFS.Models.Messages;
using TFS.Web.ViewModels;
using TFS.Web.ViewModels.Messages;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class MessagesController : BaseController
    {
        private readonly IMessagesRepository messagesRepository;

        public MessagesController(IApplicationSettings applicationSettings, IMessagesRepository messagesRepository)
            :base(applicationSettings, messagesRepository)
        {
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

        public virtual ViewResult ViewMessage(Guid id)
        {
            var message = Repository.Get<Message>(id);
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
            announcement.CreatedBy = this.CurrentUser;
            announcement.ActiveFromDate = DateTime.Today.ToUniversalTime().WithoutMilliseconds();
            Repository.Persist(announcement);
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
            Repository.Persist(aystemAlert);
            return RedirectToAction(MVC.Dashboard.Index());
        }

        [NonAction]
        private bool DetermineCanEdit()
        {
            return CurrentUser.Roles.ProgramManager;
        }
    }
}

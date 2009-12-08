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
    [DomainAuthorize, RequireTransaction]
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
            viewModel.Items.ForEach(x => x.CanEdit = DetermineCanEdit());
            return View(Views.ListMessages, viewModel);
        }

        public virtual ViewResult ListAllMessages(MessageType messageType)
        {
            var viewModel = new SortedListViewModel<MessageViewModel>();
            IEnumerable<MessageViewModel> messages;
            if (messageType == MessageType.Announcement)
            {
                var announcements = messagesRepository.GetAllAnnouncements();
                messages = Mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementViewModel>>(announcements).Cast<MessageViewModel>();
            }
            else if (messageType == MessageType.SystemAlert)
            {
                var systemAlerts = messagesRepository.GetAllSystemAlerts();
                messages = Mapper.Map<IEnumerable<SystemAlert>, IEnumerable<SystemAlertViewModel>>(systemAlerts).Cast<MessageViewModel>();
            }
            else
            {
                throw new InvalidOperationException("Invalid Message Type");
            }
            messages = messages.OrderByDescending(x => x.ActiveFromDate);
            viewModel.SetItems(messages);
            viewModel.Items.ForEach(x => x.CanEdit = DetermineCanEdit());
            return View(Views.ListMessages, viewModel);
        }

        public virtual ViewResult ViewAnnouncement(int id)
        {
            var announcement = session.Get<Announcement>(id);
            var viewModel = Mapper.Map<Announcement, AnnouncementViewModel>(announcement);
            viewModel.CanEdit = DetermineCanEdit();
            return View(Views.ViewMessage, viewModel);
        }

        public virtual ViewResult ViewSystemAlert(int id)
        {
            var systemAlert = session.Get<SystemAlert>(id);
            var viewModel = Mapper.Map<SystemAlert, SystemAlertViewModel>(systemAlert);
            viewModel.CanEdit = DetermineCanEdit();
            return View(Views.ViewMessage, viewModel);
        }

        public virtual ViewResult ViewUserAlert(int id)
        {
            var userAlert = session.Get<UserAlert>(id);
            var viewModel = Mapper.Map<UserAlert, UserAlertViewModel>(userAlert);
            viewModel.CanEdit = DetermineCanEdit();
            return View(Views.ViewMessage, viewModel);
        }

        [NonAction]
        private bool DetermineCanEdit()
        {
            return this.GetCurrentUser().Roles.ProgramManager;
        }
    }
}

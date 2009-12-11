<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="ViewPage<SortedListViewModel<TFS.Web.ViewModels.Messages.MessageViewModel>>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    Announcements and System Alerts
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Announcements and System Alerts</div>
    <p>
        Toggle between viewing:
    </p>
    <ul>
        <li><b><%= Html.ActionLink("Recent Announcements/System Alerts", MVC.Messages.ListMessages()) %></b></li>
        <li><b><%= Html.ActionLink("All Announcements", MVC.Messages.ListAllMessages(TFS.Models.Messages.MessageType.Announcement)) %></b></li>
        <li><b><%= Html.ActionLink("All System Alerts", MVC.Messages.ListAllMessages(TFS.Models.Messages.MessageType.SystemAlert)) %></b></li>
    </ul>
    <% if ((bool)ViewData["CanEdit"]) { %>
    <p>
        EDIT
    </p>
    <% } %>
    <% if (Model.Items.Any()) { %>
    <table class="list-table">
        <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Title</th>
                <th>Date</th>
            </tr>
        </thead>
        <% foreach (var message in Model.Items) { %>
        <tr>
            <td>
                <% if (message.MessageType == TFS.Models.Messages.MessageType.SystemAlert) { %>
                <%= Html.ImageContent(Links.Content.@internal.icons.systemalert_png, "System Alert", new { title = "System Alert" }) %>
                <% } %>
            </td>
            <td>
                <%= Html.ActionLink(message.Title, MVC.Messages.ViewMessage(message.Id.Value)) %>
                <% if (message.MessageType == TFS.Models.Messages.MessageType.Announcement && message.AsAnnouncement().Urgent) { %>
                    <span class="urgent">HOT ITEM</span>
                <% } %>
            </td>
            <td>
                <%= Html.Encode(message.ActiveFromDate.ToShortDateOrEmptyString()) %>
            </td>
        </tr>
        <% } %> 
    </table>
    <% } else { %>
    <p>Nothing to see here.</p>
    <% } %>
</asp:Content>

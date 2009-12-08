<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.Messages.AnnouncementViewModel>" %>

<div class="header-main"><%= Html.Encode(Model.Title) %></div>
<% if (Model.Urgent) { %>
<p>
    Filed as <span class="urgent">HOT ITEM</span>
</p>
<% } %>
<p>    
    Posted by: <b><%= Html.Encode(Model.CreatedByFileByName) %></b> on <b><%= Html.Encode(Model.ActiveFromDate.ToShortDateOrEmptyString()) %></b>
</p>
<hr />
<div class="markdown_content">
    <%= Html.Markdown(Model.Content) %>
</div>
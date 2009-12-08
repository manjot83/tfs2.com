<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.Messages.SystemAlertViewModel>" %>

<div class="header-main">System Alert: <%= Html.Encode(Model.Title) %></div>
<p>    
    Posted automatically on <b><%= Html.Encode(Model.ActiveFromDate.ToShortDateOrEmptyString()) %></b>
</p>
<hr />
<div class="markdown_content">
    <%= Html.Markdown(Model.Content) %>
</div>
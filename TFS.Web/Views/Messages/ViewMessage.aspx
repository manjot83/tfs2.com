<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="ViewPage<TFS.Web.ViewModels.Messages.MessageViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.Encode(Model.MessageType.ToString()) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<% 
    if (Model.MessageType == TFS.Models.Messages.MessageType.Announcement) { 
        Html.RenderPartial(MVC.Messages.Views.ViewAnnouncement, Model);
    } else if (Model.MessageType == TFS.Models.Messages.MessageType.SystemAlert) {
        Html.RenderPartial(MVC.Messages.Views.ViewSystemAlert, Model);
    } else if (Model.MessageType == TFS.Models.Messages.MessageType.UserAlert) {
        Html.RenderPartial(MVC.Messages.Views.ViewUserAlert, Model);
    }
%>

</asp:Content>
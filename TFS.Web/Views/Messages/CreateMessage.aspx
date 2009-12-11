<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.Messages.MessageViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	New <%= Html.Encode(Model.MessageType.ToString()) %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Add a new <%= Html.Encode(Model.MessageType.ToString()) %></div>
    <fieldset class="standard-form">
        <legend>Message Information</legend>        
        <%  
            ActionResult formAction = null;
            string partialName = null;
            if (Model.MessageType == TFS.Models.Messages.MessageType.Announcement)
            {
                formAction = MVC.Messages.CreateAnnouncement();
                partialName = MVC.Messages.Views.EditAnnouncement;
            }
            else
            {
                formAction = MVC.Messages.CreateSystemAlert();
                partialName = MVC.Messages.Views.EditSystemAlert;
            }
            using (Html.BeginForm(formAction, FormMethod.Post, new { @class = "fieldset-content" })) {
                Html.RenderPartial(partialName, Model);                
        %>
            <div class="button-group">
                <input type="submit" value="Add message" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>
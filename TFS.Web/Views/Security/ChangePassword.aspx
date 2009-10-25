<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Models.User>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Change Password - <%= Html.Encode(Model.Username) %></h1>
    <% using (Html.BeginForm(MVC.Security.ChangePassword(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <div class="field-group">
            <div class="field">
                <label for="originalPassword">Current Password</label>
                <%= Html.Password("originalPassword", string.Empty, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("originalPassword")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="newPassword">New Password</label>
                <%= Html.Password("newPassword", string.Empty, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("newPassword")%>
            </div>
            <div class="field">
                <label for="confirmNewPassword">Re-enter New Password</label>
                <%= Html.Password("confirmNewPassword", string.Empty, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("confirmNewPassword")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Change Password" />
        </div>
    <% } %>
</asp:Content>
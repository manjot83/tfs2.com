<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <h1>Create a new user</h1>
    <% using (Html.BeginForm(MVC.Users.Create(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <div class="field-group">
            <div class="field">
                <label for="firstname">First name</label>
                <%= Html.TextBox("firstname", Model.FirstName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("firstname") %>
            </div>
            <div class="field">
                <label for="lastname">Last name</label>
                <%= Html.TextBox("lastname", Model.LastName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("lastname") %>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="displayname">Display name</label>
                <%= Html.TextBox("displayname", Model.DisplayName, new { size = "40", maxlength = "100" })%>
                <%= Html.ValidationMessage("displayname")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="username">Username (@tfs2.com)</label>
                <%= Html.TextBox("username", Model.Username, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("username")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="password">Password</label>
                <%= Html.Password("password", Model.Password, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("password") %>
            </div>
            <div class="field">
                <label for="confirmpassword">Re-enter Password</label>
                <%= Html.Password("confirmpassword", Model.Password, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("confirmpassword")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Create new user" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>
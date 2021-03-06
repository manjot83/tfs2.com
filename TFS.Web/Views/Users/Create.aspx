<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    Create a New User
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <div class="header-main">Create a new user</div>
    <fieldset class="standard-form">
        <legend>User Information</legend>
        <% using (Html.BeginForm(MVC.Users.Create(), FormMethod.Post, new { @class = "fieldset-content" }))
           { %>
        <% Html.RenderPartial(MVC.Users.Views.UserInformation); %>
        <div class="field-group">
            <div class="field">
                <label for="username">Username</label>
                <%= Html.TextBox("username", Model.Username, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("username")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="email">Email (If none provided than = [username]@tacticalflightservices.com)</label>
                <%= Html.TextBox("email", Model.Email, new { size = "20", maxlength = "254" })%>
                <%= Html.ValidationMessage("email")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="password">Password</label>
                <%= Html.TextBox("password", "pirates", new { size = "20", maxlength = "50" })%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Create new user" />
            <input type="reset" value="Reset" />
        </div>
        <% } %>
    </fieldset>
</asp:Content>

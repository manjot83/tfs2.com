<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Change Password
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <div class="header-main">Edit a user - <%= Html.Encode(Model.Username) %></div>
    <fieldset class="standard-form">
        <legend>Change Password</legend>
        <% using (Html.BeginForm(MVC.Users.ChangePassword(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("username", Model.Username) %>
            <div class="field-group">
                <div class="field">
                    <label for="password">New Password</label>
                    <%= Html.TextBox("password", "", new { size = "20", maxlength = "50" })%>
                </div>
            </div>
            <div class="button-group">
                <input type="submit" value="Save" />
                <%= Html.ActionLink("Cancel", MVC.Users.List()) %>
            </div>
        <% } %>
    </fieldset>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <h1>Create a new user</h1>
    <% using (Html.BeginForm(MVC.Users.Create(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <% Html.RenderPartial(MVC.Users.Views.UserInformation); %>
        <div class="field-group">
            <div class="field">
                <label for="username">Username (@tfs2.com)</label>
                <%= Html.TextBox("username", Model.Username, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("username")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Create new user" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>
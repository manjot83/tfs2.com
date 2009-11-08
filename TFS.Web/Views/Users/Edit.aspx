<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <h1>Edit a user - <%= Html.Encode(Model.Username) %></h1>
    <% using (Html.BeginForm(MVC.Users.Edit(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Username) %>
        <% Html.RenderPartial(MVC.Users.Views.UserInformation); %>
        <div class="field-group">
            <div class="field">
                <label for="disabled">Account is disabled</label>
                <%= Html.CheckBox("disabled", Model.Disabled) %>
                <%= Html.ValidationMessage("disabled")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>
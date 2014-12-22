<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Change Password
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Change My Password</div>
    <fieldset class="standard-form">
        <legend>Password</legend>
        <% using (Html.BeginForm(MVC.Security.ChangePassword(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <div class="field-group">
                <div class="field">
                    <label for="password">New Password</label>
                    <%= Html.Password("password", "", new { size = "20", maxlength = "50" })%>
                </div>
            </div>
            <div class="field-group">
                <div class="field">
                    <label for="password">Conform Password</label>
                    <%= Html.Password("confirmPassword", "", new { size = "20", maxlength = "50" })%>
                </div>
            </div>
            <% if (ViewData.ContainsKey("ErrorMessage")) { %>
            <h4 style="color: #8f0d0d;"><%= (string)ViewData["ErrorMessage"] %></h4>
            <% } %> 
            <div class="button-group">
                <input type="submit" value="Save" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>
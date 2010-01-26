<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Edit a New User
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <div class="header-main">Edit a user - <%= Html.Encode(Model.Username) %></div>
    <fieldset class="standard-form">
        <legend>User Information</legend>
        <% using (Html.BeginForm(MVC.Users.Edit(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("username", Model.Username) %>
            <% Html.RenderPartial(MVC.Users.Views.UserInformation); %>        
            <div class="field-group">
                <div class="field">                
                    <%= Html.CheckBox("disabled", Model.Disabled) %>
                    <label for="disabled" class="checkboxlabel">Account is disabled</label>
                    <%= Html.ValidationMessage("disabled")%>
                </div>
            </div>
            <p>Roles:</p>
            <div class="field-group">
                <div class="field">                
                    <%= Html.CheckBox("RolesUserManager", Model.RolesUserManager)%>
                    <label for="RolesUserManager" class="checkboxlabel">Manage users and system permissions</label>
                    <%= Html.ValidationMessage("RolesUserManager")%>
                </div>
            </div>
            <div class="field-group">
                <div class="field">                
                    <%= Html.CheckBox("RolesPersonnelManager", Model.RolesPersonnelManager)%>
                    <label for="RolesPersonnelManager" class="checkboxlabel">Manage personnel and qualification records</label>
                    <%= Html.ValidationMessage("RolesPersonnelManager")%>
                </div>
            </div>
            <div class="field-group">
                <div class="field">                
                    <%= Html.CheckBox("RolesProgramManager", Model.RolesProgramManager)%>
                    <label for="RolesProgramManager" class="checkboxlabel">Manage flight programs and associated records and information</label>
                    <%= Html.ValidationMessage("RolesProgramManager")%>
                </div>
            </div>        
            <div class="field-group">
                <div class="field">                
                    <%= Html.CheckBox("RolesFlightLogManager", Model.RolesFlightLogManager)%>
                    <label for="RolesFlightLogManager" class="checkboxlabel">Manage flight logs, delete and change data</label>
                    <%= Html.ValidationMessage("RolesFlightLogManager")%>
                </div>
            </div>
            <div class="button-group">
                <input type="submit" value="Save" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>
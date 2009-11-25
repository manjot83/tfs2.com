<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.UserViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to user list...", MVC.Users.List()) %>
    </p>
    <div class="header-main">Edit a user - <%= Html.Encode(Model.Username) %></div>
    <% using (Html.BeginForm(MVC.Users.Edit(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Username) %>
        <h3 class="section-header underlined">User Information</h3>
        <% Html.RenderPartial(MVC.Users.Views.UserInformation); %>        
        <div class="field-group">
            <div class="field">                
                <%= Html.CheckBox("disabled", Model.Disabled) %>
                <label for="disabled" class="checkboxlabel">Account is disabled</label>
                <%= Html.ValidationMessage("disabled")%>
            </div>
        </div>
        <h3 class="section-header underlined">Roles</h3>
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
                <label for="RolesFlightLogManager" class="checkboxlabel">Manage access to and edit flight logs</label>
                <%= Html.ValidationMessage("RolesFlightLogManager")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.UserViewModel>" %>
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
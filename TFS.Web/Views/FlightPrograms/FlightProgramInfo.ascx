<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.FlightPrograms.FlightProgramViewModel>" %>
<div class="field-group">
    <div class="field">
        <label for="Name">Flight Program Name</label>
        <%= Html.TextBox("Name", Model.Name, new { size = "30", maxlength = "50" })%>
        <%= Html.ValidationMessage("Name")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="AccountName">Program Account Name</label>
        <%= Html.TextBox("AccountName", Model.AccountName, new { size = "30", maxlength = "50" })%>
        <%= Html.ValidationMessage("AccountName")%>
    </div>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.FlightPrograms.ProgramLocationViewModel>" %>
<div class="field-group">
    <div class="field">
        <label for="Name">Name</label>
        <%= Html.TextBox("Name", Model.Name, new { size = "30", maxlength = "100" })%>
        <%= Html.ValidationMessage("Name")%>
    </div>
</div>

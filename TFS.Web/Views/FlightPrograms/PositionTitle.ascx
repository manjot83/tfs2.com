<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.FlightPrograms.PositionViewModel>" %>
<div class="field-group">
    <div class="field">
        <label for="Title">Title</label>
        <%= Html.TextBox("Title", Model.Title, new { size = "30", maxlength = "50" })%>
        <%= Html.ValidationMessage("Title")%>
    </div>
</div>

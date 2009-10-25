<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary list...", MVC.FlightLogs.List()) %>
    </p>
    <h1>Edit flight time summary</h1>

    <h3 class="form-section-header">Header information</h3>
    <% using (Html.BeginForm(MVC.FlightLogs.EditMissionLog(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("id", Model.FlightLogId) %>
        <div class="field-group">
            <div class="field">
                <label for="aircraftmodel">Aircraft Model</label>
                <%= Html.TextBox("aircraftmodel", Model.AircraftModel, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("aircraftmodel")%>
            </div>
            <div class="field">
                <label for="aircraftserialnumber">Aircraft Serial Number</label>
                <%= Html.TextBox("aircraftserialnumber", Model.AircraftSerialNumber, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("aircraftserialnumber")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="location">Flight/Program Location</label>
                <%= Html.TextBox("location", Model.Location, new { size = "40", maxlength = "100" })%>
                <%= Html.ValidationMessage("location")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary list...", MVC.FlightLogs.List()) %>
    </p>
    <h1>Create a flight log summary</h1>
    <% using (Html.BeginForm(MVC.FlightLogs.CreateMissionLog(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <div class="field-group">
            <div class="field">
                <label for="flightlogdate">Date (mm/dd/yyyy)</label>
                <%= Html.TextBox("flightlogdate", Model.FlightLogDate.ToShortDateOrEmptyString(), new { size = "15", maxlength = "10" })%>
                <%= Html.ValidationMessage("flightlogdate")%>
            </div>
        </div>
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
            <input type="submit" value="Create new flight log summary" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>

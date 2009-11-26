<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.FlightLogViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary list...", MVC.FlightLogs.List()) %>
    </p>
    <div class="header-main">Create a flight log summary</div>
    <fieldset class="standard-form">
        <legend>Flight Log Header</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.CreateFlightLog(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <div class="field-group">
                <div class="field">
                    <label for="LogDate">Date (mm/dd/yyyy)</label>
                    <%= Html.TextBox("LogDate", Model.LogDate.ToShortDateOrEmptyString(), new { size = "15", maxlength = "10" })%>
                    <%= Html.ValidationMessage("LogDate")%>
                </div>
            </div>
            <div class="field-group">
                <div class="field">
                    <label for="AircraftMDS">Aircraft Model</label>
                    <%= Html.TextBox("AircraftMDS", Model.AircraftMDS, new { size = "20", maxlength = "50" })%>
                    <%= Html.ValidationMessage("AircraftMDS")%>
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
    </fieldset>
</asp:Content>

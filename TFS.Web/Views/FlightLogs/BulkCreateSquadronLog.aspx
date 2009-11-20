<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.SquadronLogListViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLog.Id.Value)) %>
    </p>
    <h2>Current flight log info:</h2>
    <p>
        Date: <b><%= Html.Encode(Model.FlightLog.LogDate.ToShortDateOrEmptyString())%></b><br />
        Aircraft: <b><%= Html.Encode(Model.FlightLog.AircraftMDS + " : " + Model.FlightLog.AircraftSerialNumber)%></b><br />
        Location: <b><%= Html.Encode(Model.FlightLog.Location)%></b>
    </p>
    <h1>Add many flight log squadron members</h1>
    <p>
        Click on any squadron member to edit or see more details.
    </p>
    <% if (Model.Items.Any()) { %>
    <table class="list-table">
        <thead>
            <tr>
                <th>Name</th>
                <th>Duty Code</th>
                <th>Total Hours</th>
            </tr>
        </thead>
        <% foreach (var squadronLog in Model.Items) { %>
        <tr>
            <td><%= Html.ActionLink(squadronLog.Person.FileByName(), MVC.FlightLogs.EditSquadronLog(squadronLog.Id.Value))%></td>
            <td><%= Html.Encode(squadronLog.DutyCode) %></td>
            <td><%= Html.Encode(squadronLog.CalculateTotalHours().ToString("F2")) %> hrs</td>
        </tr>
        <% } %>
    </table>
    <% } else { %>
    <p><b>No squadron members entered.</b></p>
    <% } %>
    <% using (Html.BeginForm(MVC.FlightLogs.BulkCreateSquadronLog(Model.FlightLog.Id.Value), FormMethod.Post, new { @class = "standard-form" })) { %>
        <% Html.RenderPartial(MVC.FlightLogs.Views.SquadronLogForm, Model.CurrentSquadronLog); %>
        <div class="button-group">
            <input type="submit" value="Add new flight log squadron member" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.SquadronLogListViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Add Squadron Logs
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary ...", MVC.FlightLogs.EditFlightLog(Model.FlightLog.Id)) %>
    </p>
    <div class="header-sub">Current flight log info:</div>
    <p>
        Date: <b><%= Html.Encode(Model.FlightLog.LogDate.ToShortDateOrEmptyString())%></b><br />
        Aircraft: <b><%= Html.Encode(Model.FlightLog.AircraftMDS + " : " + Model.FlightLog.AircraftSerialNumber)%></b><br />
        Location: <b><%= Html.Encode(Model.FlightLog.Location)%></b>
    </p>
    <div class="header-main">Add many flight log squadron members</div>
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
            <td><%= Html.ActionLink(squadronLog.PersonFileByName, MVC.FlightLogs.EditSquadronLog(squadronLog.Id.Value))%></td>
            <td><%= Html.Encode(squadronLog.DutyCode) %></td>
            <td><%= Html.Encode(squadronLog.TotalHours.ToString("F2")) %> hrs</td>
        </tr>
        <% } %>
    </table>
    <% } else { %>
    <p><b>No squadron members entered.</b></p>
    <% } %>
    <fieldset class="standard-form">
        <legend>Squadron Member</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.BulkCreateSquadronLog(Model.FlightLog.Id), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <% Html.RenderPartial(MVC.FlightLogs.Views.SquadronLogForm, Model.CurrentSquadronLog); %>
            <div class="button-group">
                <input type="submit" value="Add new flight log squadron member" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>
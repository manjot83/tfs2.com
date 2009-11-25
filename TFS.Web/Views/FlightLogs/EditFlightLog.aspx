<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary list...", MVC.FlightLogs.List()) %>
    </p>
    
    <div class="header-main">Edit flight time summary</div>
    
    <fieldset class="standard-form">
        <legend>Flight Log Header</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.EditFlightLog(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("id", Model.FlightLogId)%>
            <div class="field-group">
                <div class="field">
                    <label for="FlightLogDate">Date (mm/dd/yyyy)</label>
                    <%= Html.TextBox("FlightLogDate", Model.FlightLogDate.ToShortDateOrEmptyString(), new { size = "15", maxlength = "10" })%>
                    <%= Html.ValidationMessage("FlightLogDate")%>
                </div>
            </div>
            <div class="field-group">
                <div class="field">
                    <label for="AircraftMDS">Aircraft <acronym title="Mission-Design Series">MDS</acronym></label>
                    <%= Html.TextBox("AircraftMDS", Model.AircraftMDS, new { size = "20", maxlength = "50" })%>
                    <%= Html.ValidationMessage("AircraftMDS")%>
                </div>
                <div class="field">
                    <label for="aircraftserialnumber">Aircraft Serial/Tail Number</label>
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
                <% if (Model.SavedFlightLog) { %>
                <span class="saved-changes">Saved Changes</span>
                <% } %>
            </div>
        <% } %>
    </fieldset>
    
    <div class="header-sub">Missions</div>
    <p>
        Click on any mission to edit or see more details.
    </p>
    <% if (Model.Missions.Any()) { %>
    <table class="list-table">
        <thead>
            <tr>
                <th>Mission</th>
                <th>From</th>
                <th>To</th>
                <th>Take Off Time</th>
                <th>Land Time</th>
                <th>Flight Time</th>
            </tr>
        </thead>
        <% foreach(var mission in Model.Missions) { %>
        <tr>
            <td><%= Html.ActionLink(mission.Name, MVC.FlightLogs.EditMission(mission.Id.Value)) %></td>
            <td><%= Html.Encode(mission.FromICAO) %></td>
            <td><%= Html.Encode(mission.ToICAO) %></td>
            <td><%= Html.Encode(mission.TakeOffTime) %></td>
            <td><%= Html.Encode(mission.LandingTime) %></td>
            <td><%= Html.Encode(mission.ComputeFlightTime().TotalHours.ToString("F2")) %> hrs</td>
        </tr>
        <% } %>
    </table>
    <% } else { %>
    <p><b>No missions entered.</b></p>
    <% } %>
    <% using(Html.BeginForm(MVC.FlightLogs.CreateMission(), FormMethod.Get)) { %>
        <%= Html.Hidden("FlightLogId", Model.FlightLogId)%>
        <p>
            <input type="submit" value="Add a mission" />
        </p>
    <% } %>
        
    <div class="header-sub">Squadron log</div>        
    <p>
        Click on any squadron member to edit or see more details.
    </p>
    <% if (Model.SquadronLogs.Any()) { %>
    <table class="list-table">
        <thead>
            <tr>
                <th>Name</th>
                <th>Duty Code</th>
                <th>Total Hours</th>
            </tr>
        </thead>
        <% foreach(var squadronLog in Model.SquadronLogs) { %>
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
    <% using(Html.BeginForm(MVC.FlightLogs.CreateSquadronLog(), FormMethod.Get)) { %>
        <%= Html.Hidden("FlightLogId", Model.FlightLogId)%>
        <p>
            <input type="submit" value="Add a squadron member" />
        </p>
    <% } %>
    <% using(Html.BeginForm(MVC.FlightLogs.BulkCreateSquadronLog(), FormMethod.Get)) { %>
        <%= Html.Hidden("FlightLogId", Model.FlightLogId)%>
        <p>
            <input type="submit" value="Add several squadron members" />
        </p>
    <% } %>
        
    <div class="header-sub">Reports</div>            
    <p>
        Click to download as a <%= Html.ActionLink("PDF", MVC.FlightLogs.DownloadPDF(Model.FlightLogId))%>
    </p>
</asp:Content>
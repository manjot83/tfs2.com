<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightLogs.FlightLogViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
Edit Flight Log
</asp:Content>

<asp:Content ContentPlaceHolderID="Javascript" runat="server">
    <%= Html.JavaScriptsFor(Tags.JS_JQUERY) %>
    <script type="text/javascript">
        $(function() {
            var deleteButton = $("#deleteFlightLog");
            if (deleteButton.length) {
                deleteButton.click(function() {
                    if (confirm("Are you sure you want to delete this flight log?")) {
                        _post('<%= Url.Action(MVC.FlightLogs.DeleteFlightLog()) %>', { id: '<%= Model.Id.ToString() %>' });
                    }
                    return false;
                });
            }
        });

        /* Quick and Dirty Form Posting */
        var _post = function(url, params) {
            var form = document.createElement("form");
            form.action = url;
            form.method = "POST";
            form.style.display = "none";
            for (var x in params) {
                var opt = document.createElement("textarea");
                opt.name = x;
                opt.value = params[x];
                form.appendChild(opt);
            }
            document.body.appendChild(form);
            form.submit();
            return form;
        }
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Back to flight log summary list...", MVC.FlightLogs.List()) %>
    </p>
    
    <div class="header-main">Edit flight time summary</div>
    
    <fieldset class="standard-form">
        <legend>Flight Log Header</legend>
        <% using (Html.BeginForm(MVC.FlightLogs.EditFlightLog(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("id", Model.Id.Value)%>
            <div class="field-group">
                <div class="field">
                    <label for="LogDate">Date (mm/dd/yyyy)</label>
                    <%= Html.TextBox("LogDate", Model.LogDate.ToShortDateOrEmptyString(), new { size = "15", maxlength = "10" })%>
                    <%= Html.ValidationMessage("LogDate")%>
                </div>
            </div>
            <div class="field-group">
                <div class="field">
                    <label for="AircraftMDS">Aircraft MDS</label>
                    <%= Html.DropDownList("AircraftMDS", Model.AllAircraft) %>
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
                    <label for="LocationId">Flight/Program Location</label>
                    <%= Html.DropDownList("LocationId", Model.ActiveLocations) %>
                    <%= Html.ValidationMessage("LocationId")%>
                </div>
            </div>
            <div class="button-group">
                <input type="submit" value="Save changes" />
                <input type="reset" value="Reset" />
                <% if (Model.IsFlightLogManager) { %>
                <input type="button" value="Delete" id="deleteFlightLog" />
                <% } %>
                <% if (Model.PreviouslySaved) { %>
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
            <td><%= Html.Encode(mission.TotalFlightTime.ToString("F2")) %> hrs</td>
        </tr>
        <% } %>
    </table>
    <% } else { %>
    <p><b>No missions entered.</b></p>
    <% } %>
    <% using(Html.BeginForm(MVC.FlightLogs.CreateMission(), FormMethod.Get)) { %>
        <%= Html.Hidden("FlightLogId", Model.Id.Value)%>
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
            <td><%= Html.ActionLink(squadronLog.PersonFileByName, MVC.FlightLogs.EditSquadronLog(squadronLog.Id.Value))%></td>
            <td><%= Html.Encode(squadronLog.DutyCode) %></td>
            <td><%= Html.Encode(squadronLog.TotalHours.ToString("F2"))%> hrs</td>
        </tr>
        <% } %>
    </table>
    <% } else { %>
    <p><b>No squadron members entered.</b></p>
    <% } %>    
    <% using(Html.BeginForm(MVC.FlightLogs.CreateSquadronLog(), FormMethod.Get)) { %>
        <%= Html.Hidden("FlightLogId", Model.Id.Value)%>
        <p>
            <input type="submit" value="Add a squadron member" />
        </p>
    <% } %>
    <% using(Html.BeginForm(MVC.FlightLogs.BulkCreateSquadronLog(), FormMethod.Get)) { %>
        <%= Html.Hidden("FlightLogId", Model.Id.Value)%>
        <p>
            <input type="submit" value="Add several squadron members" />
        </p>
    <% } %>
        
    <div class="header-sub">Reports</div>            
    <p>
        Click to download as a <%= Html.ActionLink("PDF", MVC.FlightLogs.DownloadPDF(Model.Id.Value))%>
    </p>
</asp:Content>
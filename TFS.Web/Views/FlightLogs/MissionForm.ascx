<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.MissionViewModel>" %>
<%= Html.Hidden("MissionLogId", Model.MissionLogId) %>
<div class="field-group">
    <div class="field">
        <label for="mission_Name">Mission No.</label>
        <%= Html.TextBox("mission.Name", Model.Mission.Name, new { size = "40", maxlength = "50" })%>
        <%= Html.ValidationMessage("mission.Name")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="mission_FromICAO">From (ICAO)</label>
        <%= Html.TextBox("mission.FromICAO", Model.Mission.FromICAO, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("mission.FromICAO")%>
    </div>
    <div class="field">
        <label for="mission_ToICAO">To (ICAO)</label>
        <%= Html.TextBox("mission.ToICAO", Model.Mission.ToICAO, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("mission.ToICAO")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="mission_TakeOffTime">Take Off Time</label>
        <%= Html.TextBox("mission.TakeOffTime", Model.Mission.TakeOffTime, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("mission.TakeOffTime")%>
    </div>
    <div class="field">
        <label for="mission_LandingTime">Land Time</label>
        <%= Html.TextBox("mission.LandingTime", Model.Mission.LandingTime, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("mission.LandingTime")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="mission_TouchAndGos">Touch/Go</label>
        <%= Html.TextBox("mission.TouchAndGos", Model.Mission.TouchAndGos, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("mission.TouchAndGos")%>
    </div>
    <div class="field">
        <label for="mission_FullStops">Full Stop</label>
        <%= Html.TextBox("mission.FullStops", Model.Mission.FullStops, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("mission.FullStops")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="mission_Sorties">Sorties</label>
        <%= Html.TextBox("mission.Sorties", Model.Mission.Sorties, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("mission.Sorties")%>
    </div>
    <div class="field">
        <label for="mission_Totals">Total</label>
        <%= Html.TextBox("mission.Totals", Model.Mission.Totals, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("mission.Totals")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="mission_AdditionalInfo">Special Use</label>
        <%= Html.TextBox("mission.AdditionalInfo", Model.Mission.AdditionalInfo, new { size = "60", maxlength = "100" })%>
        <%= Html.ValidationMessage("mission.AdditionalInfo")%>
    </div>
</div>
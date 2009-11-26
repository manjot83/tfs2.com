<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.FlightLogs.MissionViewModel>" %>
<%= Html.Hidden("FlightLogId", Model.FlightLogId)%>
<div class="field-group">
    <div class="field">
        <label for="Name">Mission No.</label>
        <%= Html.TextBox("Name", Model.Name, new { size = "40", maxlength = "50" })%>
        <%= Html.ValidationMessage("Name")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="FromICAO">From (ICAO)</label>
        <%= Html.TextBox("FromICAO", Model.FromICAO, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("FromICAO")%>
    </div>
    <div class="field">
        <label for="ToICAO">To (ICAO)</label>
        <%= Html.TextBox("ToICAO", Model.ToICAO, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("ToICAO")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="TakeOffTime">Take Off Time</label>
        <%= Html.TextBox("TakeOffTime", Model.TakeOffTime, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("TakeOffTime")%>
    </div>
    <div class="field">
        <label for="LandingTime">Land Time</label>
        <%= Html.TextBox("LandingTime", Model.LandingTime, new { size = "10", maxlength = "4" })%>
        <%= Html.ValidationMessage("LandingTime")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="TouchAndGos">Touch/Go</label>
        <%= Html.TextBox("TouchAndGos", Model.TouchAndGos, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("TouchAndGos")%>
    </div>
    <div class="field">
        <label for="FullStops">Full Stop</label>
        <%= Html.TextBox("FullStops", Model.FullStops, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("FullStops")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="Sorties">Sorties</label>
        <%= Html.TextBox("Sorties", Model.Sorties, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("Sorties")%>
    </div>
    <div class="field">
        <label for="Totals">Total</label>
        <%= Html.TextBox("Totals", Model.Totals, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("Totals")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="AdditionalInfo">Special Use</label>
        <%= Html.TextBox("AdditionalInfo", Model.AdditionalInfo, new { size = "60", maxlength = "100" })%>
        <%= Html.ValidationMessage("AdditionalInfo")%>
    </div>
</div>
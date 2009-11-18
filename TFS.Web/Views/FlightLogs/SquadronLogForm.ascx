<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.SquadronLogViewModel>" %>
<%= Html.Hidden("MissionLogId", Model.MissionLogId) %>
<div class="field-group">
    <div class="field">
        <label for="PersonUsername">Person</label>
        <%= Html.DropDownList("PersonUsername", Model.AvailablePersons.GenerateSelectListItems(Model.SquadronLog.Person))%>
        <%= Html.ValidationMessage("PersonUsername")%>
    </div>
    <div class="field">
        <label for="SquadronLog_DutyCode">Duty Code</label>
        <%= Html.DropDownList("SquadronLog.DutyCode", Model.SquadronLog.DutyCode.GenerateSelectListItems())%>
        <%= Html.ValidationMessage("SquadronLog.DutyCode")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="SquadronLog_PrimaryHours">Primary</label>
        <%= Html.TextBox("SquadronLog.PrimaryHours", Model.SquadronLog.PrimaryHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.PrimaryHours")%>
    </div>
    <div class="field">
        <label for="SquadronLog_SecondaryHours">Secondary</label>
        <%= Html.TextBox("SquadronLog.SecondaryHours", Model.SquadronLog.SecondaryHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.SecondaryHours")%>        
    </div>
    <div class="field">
        <label for="SquadronLog_OtherHours">Other</label>
        <%= Html.TextBox("SquadronLog.OtherHours", Model.SquadronLog.OtherHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.OtherHours")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="SquadronLog_InstructorHours">Instructor</label>
        <%= Html.TextBox("SquadronLog.InstructorHours", Model.SquadronLog.InstructorHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.InstructorHours")%>
    </div>
    <div class="field">
        <label for="SquadronLog_EvaluatorHours">Evaluator</label>
        <%= Html.TextBox("SquadronLog.EvaluatorHours", Model.SquadronLog.EvaluatorHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.EvaluatorHours")%>
    </div>
    <div class="field">
        <label for="SquadronLog_Sorties">Sorties</label>
        <%= Html.TextBox("SquadronLog.Sorties", Model.SquadronLog.Sorties, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("SquadronLog.Sorties")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="SquadronLog_PrimaryNightHours">Primary Night</label>
        <%= Html.TextBox("SquadronLog.PrimaryNightHours", Model.SquadronLog.PrimaryNightHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.PrimaryNightHours")%>
    </div>
    <div class="field">
        <label for="SquadronLog_PrimaryInstrumentHours">Primary Instrument</label>
        <%= Html.TextBox("SquadronLog.PrimaryInstrumentHours", Model.SquadronLog.PrimaryInstrumentHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.PrimaryInstrumentHours")%>
    </div>
    <div class="field">
        <label for="SquadronLog_SimulatedInstrumentHours">Simulated Instrument</label>
        <%= Html.TextBox("SquadronLog.SimulatedInstrumentHours", Model.SquadronLog.SimulatedInstrumentHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SquadronLog.SimulatedInstrumentHours")%>
    </div>
</div>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TFS.Web.ViewModels.FlightLogs.SquadronLogViewModel>" %>
<%= Html.Hidden("FlightLogId", Model.FlightLogId.Value)%>
<div class="field-group">
    <div class="field">
        <label for="PersonUsername">Person</label>
        <%= Html.DropDownList("PersonUsername", Model.AvailablePersons.GenerateSelectListItems(Model.PersonUsername))%>
        <%= Html.ValidationMessage("PersonUsername")%>
    </div>
    <div class="field">
        <label for="DutyCode">Duty Code</label>
        <%= Html.DropDownList("DutyCode", Model.DutyCode.GenerateSelectListItems())%>
        <%= Html.ValidationMessage("DutyCode")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="PrimaryHours">Primary</label>
        <%= Html.TextBox("PrimaryHours", Model.PrimaryHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("PrimaryHours")%>
    </div>
    <div class="field">
        <label for="SecondaryHours">Secondary</label>
        <%= Html.TextBox("SecondaryHours", Model.SecondaryHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SecondaryHours")%>        
    </div>
    <div class="field">
        <label for="OtherHours">Other</label>
        <%= Html.TextBox("OtherHours", Model.OtherHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("OtherHours")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="InstructorHours">Instructor</label>
        <%= Html.TextBox("InstructorHours", Model.InstructorHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("InstructorHours")%>
    </div>
    <div class="field">
        <label for="EvaluatorHours">Evaluator</label>
        <%= Html.TextBox("EvaluatorHours", Model.EvaluatorHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("EvaluatorHours")%>
    </div>
    <div class="field">
        <label for="Sorties">Sorties</label>
        <%= Html.TextBox("Sorties", Model.Sorties, new { size = "10", maxlength = "2" })%>
        <%= Html.ValidationMessage("Sorties")%>
    </div>
</div>
<div class="field-group">
    <div class="field">
        <label for="PrimaryNightHours">Primary Night</label>
        <%= Html.TextBox("PrimaryNightHours", Model.PrimaryNightHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("PrimaryNightHours")%>
    </div>
    <div class="field">
        <label for="PrimaryInstrumentHours">Primary Instrument</label>
        <%= Html.TextBox("PrimaryInstrumentHours", Model.PrimaryInstrumentHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("PrimaryInstrumentHours")%>
    </div>
    <div class="field">
        <label for="SimulatedInstrumentHours">Simulated Instrument</label>
        <%= Html.TextBox("SimulatedInstrumentHours", Model.SimulatedInstrumentHours, new { size = "10", maxlength = "5" })%>
        <%= Html.ValidationMessage("SimulatedInstrumentHours")%>
    </div>
</div>
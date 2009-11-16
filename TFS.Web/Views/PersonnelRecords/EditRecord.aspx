<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.PersonnelRecordViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit personnel record - <%= Html.Encode(Model.Record.User.Username) %></h1>
    <p>
        Use this form to edit personnel information, emergency contact information, and flight qualifications.
    </p>
    <h3 class="section-header underlined">Personal Information</h3>
    <% using (Html.BeginForm(MVC.PersonnelRecords.EditPersonalInfo(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Record.User.Username) %>
        <%= Html.Hidden("editingmyrecord", Model.EditingMyRecord)%>
        <div class="field-group">
            <div class="field">
                <label for="firstname">First name</label>
                <%= Html.TextBox("firstname", Model.Record.FirstName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("firstname") %>
            </div>
            <div class="field">
                <label for="lastname">Last name</label>
                <%= Html.TextBox("lastname", Model.Record.LastName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("lastname") %>
            </div>
            <div class="field">
                <label for="MiddleInitial">Middle Initial</label>
                <%= Html.TextBox("MiddleInitial", Model.Record.MiddleInitial, new { size = "10", maxlength = "5" })%>
                <%= Html.ValidationMessage("MiddleInitial")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="DateOfBirth">Date of Birth (mm/dd/yyyy)</label>
                <%= Html.TextBox("DateOfBirth", Model.Record.DateOfBirth.ToShortDateOrEmptyString(), new { size = "15", maxlength = "10" })%>
                <%= Html.ValidationMessage("DateOfBirth")%>
            </div>
            <div class="field">
                <label for="gender">Gender</label>
                <%= Html.DropDownList("gender", Model.Record.Gender.GenerateSelectListItems()) %>
                <%= Html.ValidationMessage("gender")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="SocialSecurityLastFour">Last four digits of social security number</label>
                <%= Html.TextBox("SocialSecurityLastFour", Model.Record.SocialSecurityLastFour, new { size = "10", maxlength = "4" })%>
                <%= Html.ValidationMessage("SocialSecurityLastFour")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
    <h3 class="section-header underlined">Contact Information</h3>
    <% using (Html.BeginForm(MVC.PersonnelRecords.EditContactInfo(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Record.User.Username) %>
        <%= Html.Hidden("editingmyrecord", Model.EditingMyRecord)%>
        <div class="field-group">
            <div class="field">
                <label for="PrimaryPhoneNumber">Phone Number</label>
                <%= Html.TextBox("PrimaryPhoneNumber", Model.Record.PrimaryPhoneNumber, new { size = "20", maxlength = "15" })%>
                <%= Html.ValidationMessage("PrimaryPhoneNumber")%>
            </div>
            <div class="field">
                <label for="AlternatePhoneNumber">Alt. Phone Number</label>
                <%= Html.TextBox("AlternatePhoneNumber", Model.Record.AlternatePhoneNumber, new { size = "20", maxlength = "15" })%>
                <%= Html.ValidationMessage("AlternatePhoneNumber")%>
            </div>
            <div class="field">
                <label for="AlternateEmail">Alt. E-mail</label>
                <%= Html.TextBox("AlternateEmail", Model.Record.AlternateEmail, new { size = "20", maxlength = "255" })%>
                <%= Html.ValidationMessage("AlternateEmail")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="EmergencyContactName">Emergency Contact Name</label>
                <%= Html.TextBox("EmergencyContactName", Model.Record.EmergencyContactName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("EmergencyContactName")%>
            </div>
            <div class="field">
                <label for="EmergencyContactPhoneNumber">Emergency Contact Phone</label>
                <%= Html.TextBox("EmergencyContactPhoneNumber", Model.Record.EmergencyContactPhoneNumber, new { size = "20", maxlength = "15" })%>
                <%= Html.ValidationMessage("EmergencyContactPhoneNumber")%>
            </div>
        </div>
        <h4>Address:</h4>
        <div class="field-group">
            <div class="field">
                <label for="streetaddress">Street Address</label>
                <%= Html.TextBox("streetaddress", Model.Record.Address != null ? Model.Record.Address.StreetAddress : string.Empty , new { size = "50", maxlength = "100" })%>
                <%= Html.ValidationMessage("streetaddress")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="city">City</label>
                <%= Html.TextBox("city", Model.Record.Address != null ? Model.Record.Address.City : string.Empty, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("city")%>
            </div>
            <div class="field">
                <label for="state">State</label>
                <%= Html.TextBox("state", Model.Record.Address != null && Model.Record.Address.State != null ? Model.Record.Address.State.Abbreviation : string.Empty, new { size = "5", maxlength = "2" })%>
                <%= Html.ValidationMessage("state")%>
            </div>
            <div class="field">
                <label for="ZipCode">Zip</label>
                <%= Html.TextBox("ZipCode", Model.Record.Address != null ? Model.Record.Address.ZipCode : string.Empty, new { size = "10", maxlength = "5" })%>
                <%= Html.ValidationMessage("ZipCode")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
    <h3 class="section-header underlined">TFS Company Information</h3>
    <% using (Html.BeginForm(MVC.PersonnelRecords.EditCompanyInfo(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Record.User.Username) %>
        <%= Html.Hidden("editingmyrecord", Model.EditingMyRecord)%>
        <div class="field-group">
            <div class="field">
                <label for="HirePositionId">Hired On Position</label>
                <%= Html.DropDownList("HirePositionId", Model.HirePositions)%>
                <%= Html.ValidationMessage("HirePositionId")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="ShirtSize">Shirt Size</label>
                <%= Html.DropDownList("ShirtSize", Model.Record.ShirtSize.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("ShirtSize")%>
            </div>
            <div class="field">
                <label for="FlightSuitSize">Flight Suit Size</label>
                <%= Html.DropDownList("FlightSuitSize", Model.Record.FlightSuitSize.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("FlightSuitSize")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
    <h3 class="section-header underlined">Military Background and Qualifications</h3>
    <% using (Html.BeginForm(MVC.PersonnelRecords.EditQualifications(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Record.User.Username) %>
        <%= Html.Hidden("editingmyrecord", Model.EditingMyRecord)%>
        <div class="field-group">
            <div class="field">
                <label for="BranchOfService">Branch of Service</label>
                <%= Html.DropDownList("BranchOfService", Model.Record.Qualifications.BranchOfService.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("BranchOfService")%>
            </div>
            <div class="field">
                <label for="MilitaryFCFQualification">FCF Qualification</label>
                <%= Html.DropDownList("MilitaryFCFQualification", Model.Record.Qualifications.MilitaryFCFQualification.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("MilitaryFCFQualification")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
</asp:Content>
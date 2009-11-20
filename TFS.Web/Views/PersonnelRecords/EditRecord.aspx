<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.PersonnelRecords.PersonnelRecordViewModel>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit personnel record - <%= Html.Encode(Model.Username) %></h1>
    <p>
        Use this form to edit personnel information, emergency contact information, and flight qualifications.
    </p>
    <h3 class="section-header underlined">Personal Information</h3>
    <% using (Html.BeginForm(MVC.PersonnelRecords.EditPersonalInfo(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Username) %>
        <%= Html.Hidden("editingmyrecord", Model.EditingMyRecord)%>
        <div class="field-group">
            <div class="field">
                <label for="firstname">First name</label>
                <%= Html.TextBox("firstname", Model.PersonalInfo.FirstName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("firstname") %>
            </div>
            <div class="field">
                <label for="lastname">Last name</label>
                <%= Html.TextBox("lastname", Model.PersonalInfo.LastName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("lastname") %>
            </div>
            <div class="field">
                <label for="MiddleInitial">Middle Initial</label>
                <%= Html.TextBox("MiddleInitial", Model.PersonalInfo.MiddleInitial, new { size = "10", maxlength = "5" })%>
                <%= Html.ValidationMessage("MiddleInitial")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="DateOfBirth">Date of Birth (mm/dd/yyyy)</label>
                <%= Html.TextBox("DateOfBirth", Model.PersonalInfo.DateOfBirth.ToShortDateOrEmptyString(), new { size = "15", maxlength = "10" })%>
                <%= Html.ValidationMessage("DateOfBirth")%>
            </div>
            <div class="field">
                <label for="gender">Gender</label>
                <%= Html.DropDownList("gender", Model.PersonalInfo.Gender.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("gender")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="SocialSecurityLastFour">Last four digits of social security number</label>
                <%= Html.TextBox("SocialSecurityLastFour", Model.PersonalInfo.SocialSecurityLastFour, new { size = "10", maxlength = "4" })%>
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
        <%= Html.Hidden("username", Model.Username) %>
        <%= Html.Hidden("editingmyrecord", Model.EditingMyRecord)%>
        <div class="field-group">
            <div class="field">
                <label for="PrimaryPhoneNumber">Phone Number</label>
                <%= Html.TextBox("PrimaryPhoneNumber", Model.ContactInfo.PrimaryPhoneNumber, new { size = "20", maxlength = "15" })%>
                <%= Html.ValidationMessage("PrimaryPhoneNumber")%>
            </div>
            <div class="field">
                <label for="AlternatePhoneNumber">Alt. Phone Number</label>
                <%= Html.TextBox("AlternatePhoneNumber", Model.ContactInfo.AlternatePhoneNumber, new { size = "20", maxlength = "15" })%>
                <%= Html.ValidationMessage("AlternatePhoneNumber")%>
            </div>
            <div class="field">
                <label for="AlternateEmail">Alt. E-mail</label>
                <%= Html.TextBox("AlternateEmail", Model.ContactInfo.AlternateEmail, new { size = "20", maxlength = "255" })%>
                <%= Html.ValidationMessage("AlternateEmail")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="EmergencyContactName">Emergency Contact Name</label>
                <%= Html.TextBox("EmergencyContactName", Model.ContactInfo.EmergencyContactName, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("EmergencyContactName")%>
            </div>
            <div class="field">
                <label for="EmergencyContactPhoneNumber">Emergency Contact Phone</label>
                <%= Html.TextBox("EmergencyContactPhoneNumber", Model.ContactInfo.EmergencyContactPhoneNumber, new { size = "20", maxlength = "15" })%>
                <%= Html.ValidationMessage("EmergencyContactPhoneNumber")%>
            </div>
        </div>
        <h4>Address:</h4>
        <div class="field-group">
            <div class="field">
                <label for="AddressStreetAddress">Street Address</label>
                <%= Html.TextBox("AddressStreetAddress", Model.ContactInfo.AddressStreetAddress, new { size = "50", maxlength = "100" })%>
                <%= Html.ValidationMessage("AddressStreetAddress")%>
            </div>
        </div>
        <div class="field-group">
            <div class="field">
                <label for="AddressCity">City</label>
                <%= Html.TextBox("AddressCity", Model.ContactInfo.AddressCity, new { size = "20", maxlength = "50" })%>
                <%= Html.ValidationMessage("AddressCity")%>
            </div>
            <div class="field">
                <label for="AddressState">State</label>
                <%= Html.TextBox("AddressState", Model.ContactInfo.AddressState, new { size = "5", maxlength = "2" })%>
                <%= Html.ValidationMessage("AddressState")%>
            </div>
            <div class="field">
                <label for="AddressZipCode">Zip</label>
                <%= Html.TextBox("AddressZipCode", Model.ContactInfo.AddressZipCode, new { size = "10", maxlength = "5" })%>
                <%= Html.ValidationMessage("AddressZipCode")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
    <h3 class="section-header underlined">TFS Company Information</h3>
    <% using (Html.BeginForm(MVC.PersonnelRecords.EditCompanyInfo(), FormMethod.Post, new { @class = "standard-form" })) { %>
        <%= Html.Hidden("username", Model.Username) %>
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
                <%= Html.DropDownList("ShirtSize", Model.CompanyInfo.ShirtSize.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("ShirtSize")%>
            </div>
            <div class="field">
                <label for="FlightSuitSize">Flight Suit Size</label>
                <%= Html.DropDownList("FlightSuitSize", Model.CompanyInfo.FlightSuitSize.GenerateSelectListItems())%>
                <%= Html.ValidationMessage("FlightSuitSize")%>
            </div>
        </div>
        <div class="button-group">
            <input type="submit" value="Save changes" />
            <input type="reset" value="Reset" />
        </div>
    <% } %>
    <h3 class="section-header underlined">Military Background and Qualifications</h3>
    <%--<% using (Html.BeginForm(MVC.PersonnelRe<cords.EditQualifications(), FormMethod.Post, new { @class = "standard-form" })) { %>
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
    <% } %>--%>
</asp:Content>
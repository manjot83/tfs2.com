<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.FlightProgramViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Edit Flight Program
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Edit Flight Program</div>
    <fieldset class="standard-form">
        <legend>Flight Program Information</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.EditFlightProgram(), FormMethod.Post, new { @class = "fieldset-content" })) { %>
            <%= Html.Hidden("id", Model.Id.Value) %>
            <% Html.RenderPartial(MVC.FlightPrograms.Views.FlightProgramInfo); %>
            <div class="field-group">
                <div class="field">                
                    <%= Html.CheckBox("Active", Model.Active)%>
                    <label for="Active" class="checkboxlabel">Flight Program is active</label>
                    <%= Html.ValidationMessage("Active")%>
                </div>
            </div>
            <div class="button-group">
                <input type="submit" value="Save changes" />
                <input type="reset" value="Reset" />
            </div>
        <% } %>
    </fieldset>
</asp:Content>
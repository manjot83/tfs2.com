<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.FlightPrograms.AircraftViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    Rename position
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Edit aircraft</div>
    <p>
        <span class="warning">Warning: Renaming an aircraft will also change existing references to that aircraft.</span>
    </p>
    <fieldset class="standard-form">
        <legend>Position</legend>
        <% using (Html.BeginForm(MVC.FlightPrograms.EditAircraft(), FormMethod.Post, new { @class = "fieldset-content" }))
           { %>
        <%= Html.Hidden("Id", Model.Id.Value) %>
        <% Html.RenderPartial(MVC.FlightPrograms.Views.AircraftName); %>
        <div class="field-group">
            <div class="field">
                <%= Html.CheckBox("Active", Model.Active)%>
                <label for="Active" class="checkboxlabel">Aircraft is active</label>
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

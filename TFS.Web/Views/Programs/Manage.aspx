<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<TFS.Web.ViewModels.ManageProgramsViewModel>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
	Manage
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-main">Manage TFS Programs and Positions</div>
    Active Positions
    <ul>
        <% foreach (var position in Model.ActivePositions) { %>
        <li><%= Html.Encode(position.Title) %></li>
        <% } %>
    </ul>
    <p>
    <% using(Html.BeginForm(MVC.Programs.AddNewPosition())) { %>
        <p><label for="title">Add a new position:</label> <%= Html.TextBox("title") %></p>
        <p><input type="submit" value="Create" /></p>
    <% } %>
    </p>
</asp:Content>

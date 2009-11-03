<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="sidenav">
    <h1>Operations</h1>
    <ul>            
        <li><%= Html.NavImageLink("Flight Logs", Links.Content.@internal.icons.flightlog_png, MVC.FlightLogs.Index()) %></li>
    </ul>
    <h1>Self Service</h1>
    <ul>
        <li><%= Html.NavImageLink("My Personnel File", Links.Content.@internal.icons.vcard_png, MVC.PersonnelRecords.EditMyRecord())%></li>
    </ul>
    <h1>Administration</h1>
    <ul>
        <li><%= Html.NavImageLink("Users", Links.Content.@internal.icons.group_png, MVC.Users.Index()) %></li>
        <%--<li><%= Html.NavImageLink("Personnel Files", Links.Content.@internal.icons.vcard_png, "#")%></li>--%>
        <%--<li><%= Html.NavImageLink("Programs", Links.Content.@internal.icons.book_png, MVC.Programs.Manage())%></li>
        <li><%= Html.NavImageLink("Website", Links.Content.@internal.icons.world_png, "#")%></li>--%>
    </ul>
</div>

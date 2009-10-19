<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Dashboard.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TFS.Models.User>>" %>

<asp:Content ContentPlaceHolderID="AdditionalStyleSheets" runat="server">
    <link type="text/css" rel="stylesheet" href="<%= Url.Content("~/Content/internal/list-table.css") %>" />
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <table class="list-table">
        <tr>
            <th>
                <a href="Users?sortType=fullname&amp;sortReverse=false">Name</a>
            </th>
            <th>
                <a href="Users?sortType=username&amp;sortReverse=true" class="selected">Username</a>
            </th>
            <th>
                <a href="Users?sortType=status&amp;sortReverse=false">Status</a>
            </th>
            <th>
                <a href="Users?sortType=emailQuota&amp;sortReverse=false">Email Quota</a>
            </th>
            <th>
                <a href="Users?sortType=lastLogin&amp;sortReverse=false">Last signed in</a>
            </th>
        </tr>
        <% foreach (var user in Model)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink(user.LastName + ", " +user.FirstName, MVC.Users.Edit(user.Username)) %>
            </td>
            <td>
                <%= Html.Encode(user.Username) %>
                b.ferguson
            </td>
            <td>
                Newly created
            </td>
            <td>
                <span class="bar1"><span style="width: 0%;"></span></span>0%
            </td>
            <td>
                Never logged in
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>

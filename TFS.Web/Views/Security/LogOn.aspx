<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TFS Login</title>
</head>
<body>
    <div style="font-family: Verdana; margin: 0 auto; width: 600px; margin-top: 100px;">
        <h3>TFS Intranet Web Application</h3>
        <p style="color: #8f0d0d;">You are not authorized to see this resource. You will need to sign in.</p>

        <form method="post" action="<%: Url.Action("Authenticate", "Security") %>">
            <h3>Login With Your TFS Credentials</h3>
            <label for="username">Callsign:</label><br />
            <input type="text" id="username" name="username" autofocus /><br />
            <br />
            <label for="password">Authenticate:</label><br />
            <input type="password" id="password" name="password" /><br />
            <br />
            <button type="submit">Submit</button>
            <% if (ViewData.ContainsKey("ErrorMessage")) { %>
            <h5 style="color: #8f0d0d;"><%= (string)ViewData["ErrorMessage"] %></h5>
            <% } %>
        </form>
        <hr />
        <p>
            Or <a href="<%= ViewData["google_url"] %>">Sign In With You TFS Google Apps Account</a>
        </p>
    </div>
</body>
</html>

﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TFS Login</title>
</head>
<body>
    <div style="font-family: Verdana; margin: 0 auto; width: 600px; margin-top: 100px;">
        <h3>TFS Intranet Web Application</h3>
        <p style="color: #8f0d0d;">You are not authorized to see this resource. You will need to sign in.</p>
        <p>
            <a href="<%= ViewData["google_url"] %>">Sign In With You Google Apps Account</a>
        </p>
    </div>
</body>
</html>

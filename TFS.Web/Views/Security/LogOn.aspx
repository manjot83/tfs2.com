<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TFS Login</title>
</head>
<body>
    <div>
        You are not authorized to see this resource. Please Login.        
        <a href="<%= ViewData["google_url"] %>">Sign In With You Google Apps Account</a>
    </div>
</body>
</html>

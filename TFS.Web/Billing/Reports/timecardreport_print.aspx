<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timecardreport_print.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Reports.timecardreport_print" %>

<%@ Register TagPrefix="report" TagName="timesheet" Src="~/Billing/Report Controls/timesheet_printable.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TFS Intranet : Timesheet</title>
    <!--link rel="stylesheet" type="text/css" href="../style/sinorca-tfs2.css" />-->
    <style type="text/css">
        body {
            font-size: smaller;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    
    <asp:HiddenField ID="post_username" runat="server" />
    <asp:HiddenField ID="post_periodid" runat="server" />
    <asp:HiddenField ID="post_billingaccountid" runat="server" />
    
    <report:timesheet ID="TimeSheet" runat="server" />
           

</form>

</body>

</html>
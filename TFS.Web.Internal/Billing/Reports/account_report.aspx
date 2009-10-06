<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account_report.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Reports.account_report" %>

<%@ Register TagPrefix="report" TagName="timesheet" Src="~/Billing/Report Controls/timesheet_printable.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
    
    <asp:ObjectDataSource ID="ReportTimesheetInfoData" runat="server" TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
        SelectMethod="GetTimesheets">
        <SelectParameters>
            <asp:QueryStringParameter Name="Billingaccountid" Type="int32" QueryStringField="accountid" />
            <asp:QueryStringParameter Name="PeriodID" QueryStringField="id" Type="int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:Repeater ID="ReportableTimesheets" runat="server" DataSourceID="ReportTimesheetInfoData">
        <ItemTemplate>
            <report:timesheet ID="TimesheetReport" runat="Server" TimesheetID='<%# Eval("timesheetid") %>' Username='<%# Eval("username") %>' />
            <div style="page-break-after: always">
            </div>
        </ItemTemplate>
    </asp:Repeater>
    
    <table id="Table1" width="100%" style="border: solid 2px black; font-family:Arial;" cellspacing="0">
        
         <tr style="background-color: #CCCCCC;">
            <td align="center" colspan="11">&nbsp;</td>
        </tr>
        <tr style="background-color: #CCCCCC; font-family:Arial;">
            <td align="center">Position</td>
            <td align="center">Total <asp:Label ID="report_ratename1" runat="server" /></td>
            <td align="center">Total <asp:Label ID="report_ratename2" runat="server" /></td>
            <td align="center">Total <asp:Label ID="report_ratename3" runat="server" /></td>
            <td align="center">Total <asp:Label ID="report_ratename4" runat="server" /></td>
            <td align="center">Total Time</td>
            <td align="center">Total Expenses</td>
            <td align="center">Total Per Diem</td>
            <td align="center">Total Mileage</td>
            <td align="center">Total Labor Billed</td>
            <td align="center">Total Invoice</td>
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Time</td>
            <td align="center"><b><asp:Label ID="report_Total1Hours" runat="server" /> Hours</b></td>
            <td align="center"><b><asp:Label ID="report_Total2Hours" runat="server" /> Hours</b></td>
            <td align="center"><b><asp:Label ID="report_Total3Hours" runat="server" /> Hours</b></td>
            <td align="center"><b><asp:Label ID="report_Total4Hours" runat="server" /> Hours</b></td>
            <td align="center"><b><asp:Label ID="report_TotalHours" runat="server" /> Hours</b></td>
            <td align="center"><b>$<asp:Label ID="report_TotalExpenses" runat="server" /></b></td>
            <td align="center"><b><asp:Label ID="report_TotalPerDiemCount" runat="server" /> Days</b></td>  
            <td align="center"><b><asp:Label ID="report_TotalMileage" runat="server" /> Miles</b></td>
            <td align="center"><b></b></td>      
            <td align="center"><b></b></td>                                    
        </tr>
        <tr style="background-color: #FFFFFF;">
            <td align="center" style="background-color: #CCCCCC;">&nbsp;</td>
            <td align="center" colspan="10">&nbsp;</td>
        </tr>
        <tr style="background-color: #FFFFFF;">
            <td align="center" style="background-color: #CCCCCC;">Billing Rate</td>
            <td align="center">$<asp:Label ID="report_1rate" runat="server" />/hr</td>
            <td align="center">$<asp:Label ID="report_2rate" runat="server" />/hr</td>
            <td align="center">$<asp:Label ID="report_3rate" runat="server" />/hr</td>
            <td align="center">$<asp:Label ID="report_4rate" runat="server" />/hr</td>
            <td align="center" colspan="2">&nbsp;</td>
            <td align="center">$<asp:Label ID="report_perdiemrate" runat="server" />/hr</td>
            <td align="center">$<asp:Label ID="report_mileagerate" runat="server" />/mile</td>
            <td align="center" colspan="2">&nbsp;</td>
        </tr>
        <tr style="background-color: #CCCCCC;">
            <td align="center">Billed Line Items</td>                                
            <td align="center"><b>$<asp:Label ID="report_line_1" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_2" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_3" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_4" runat="server" /></b></td>
            <td align="center">&nbsp;</td>                
            <td align="center"><b>$<asp:Label ID="report_line_expensetotal" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_perdiem" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_mileage" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_labor" runat="server" /></b></td>
            <td align="center"><b>$<asp:Label ID="report_line_invoice" runat="server" /></b></td>
        </tr>
        
    </table>   
    <table width="100%" cellspacing="0">
    <tr>
            <td align="center">Report Generated: <%= DateTime.Now.ToShortDateString() %></td>
    </tr>
    </table>
    <p>&nbsp;</p>
    
    </form>
</body>
</html>

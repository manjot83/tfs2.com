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
   
    <table id="Table1" width="550px" style="border: solid 2px black; font-family:Arial;" cellspacing="0">
        <tr style="background-color: #CCCCCC;">
            <td align="center" colspan="4">&nbsp;</td>
        </tr>
        <tr style="background-color: #CCCCCC; font-family:Arial;">
            <td align="center">&nbsp;</td>
            <td align="center" style="background-color: #CCCCCC;">Time</td>
            <td align="center" style="background-color: #CCCCCC;">Billing Rate</td>
            <td align="center">Billed Line Items</td>       
        </tr>
        <asp:Repeater ID="BillingGroupRepeater" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center" style="background-color: #CCCCCC;">Total <%# Eval("RateGroupName") %></td>
                    <td align="center"><b><%# Eval("TotalHours") %> Hours</b></td>
                    <td align="center">$<%# Eval("Rate") %>/hr</td>
                    <td align="center"><b>$<%# Double.Parse(Eval("TotalHours").ToString()) * Double.Parse(Eval("Rate").ToString()) %></b></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">&nbsp;</td>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Total Time</td>
            <td align="center"><b><%= GetTotalHours().ToString() %></b></td>
            <td align="center" colspan="2">&nbsp;</td>            
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Total Expenses</td>
            <td align="center"><b>$<%= summaryinfo.Rows[0]["ExpenseTotal"].ToString() %></b></td>
            <td align="center">&nbsp;</td>            
            <td align="center"><b>$<%= summaryinfo.Rows[0]["ExpenseTotal"].ToString() %></b></td>
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Total Per Diem</td>
            <td align="center"><b><%= summaryinfo.Rows[0]["PerDiemTotal"].ToString()%> Days</b></td>
            <td align="center">$<%= string.Format("{0:#.00}", Convert.ToDouble(summaryinfo.Rows[0]["PerDiemRate"]))%>/day</td>    
            <td align="center"><b>$<%= GetTotalPerDiem().ToString() %></b></td>
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Total Mileage</td>
            <td align="center"><b><%= summaryinfo.Rows[0]["MileageTotal"].ToString() %> Days</b></td>
            <td align="center"><%= summaryinfo.Rows[0]["MileageRate"].ToString()%>/hr</td>    
            <td align="center"><b>$<%= GetTotalMileage().ToString() %></b></td>
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Total Labor Billed</td>
            <td align="center" colspan="2">&nbsp;</td>            
            <td align="center"><b>$<%= GetTotalLabor().ToString() %></b></td>
        </tr>
        <tr>
            <td align="center" style="background-color: #CCCCCC;">Total Invoice</td>
            <td align="center" colspan="2">&nbsp;</td>            
            <td align="center"><b>$<%= GetTotalBilled().ToString() %></b></td>
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

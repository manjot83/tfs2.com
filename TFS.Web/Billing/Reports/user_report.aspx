<%@ Page Language="C#" AutoEventWireup="true" Codebehind="user_report.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Reports.user_report" %>

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
    
        <asp:ObjectDataSource ID="UserDataSource" runat="server" TypeName="TFS.Intranet.Data.Billing.UserController"
            SelectMethod="SelectUser">
            <SelectParameters>
                <asp:QueryStringParameter Name="Username" Type="string" QueryStringField="username" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="ReportTimesheetInfoData" runat="server" TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
            SelectMethod="GetTimesheets">
            <SelectParameters>
                <asp:QueryStringParameter Name="Username" Type="string" QueryStringField="username" />
                <asp:QueryStringParameter Name="PeriodID" QueryStringField="id" Type="int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="SummaryDataSource" runat="server" TypeName="TFS.Intranet.Data.Billing.EmployeeSummaryController"
            SelectMethod="FetchByPeriodAndUsername">
            <SelectParameters>
                <asp:QueryStringParameter Name="Username" Type="string" QueryStringField="username" />
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
        
        <table id="Table1" width="100%" style="border: solid 2px black; font-family: Arial;"
            cellspacing="0">
            <tr style="background-color: #CCCCCC;">
                <td align="center" colspan="13">
                    &nbsp;</td>
            </tr>
            <tr style="background-color: #CCCCCC; font-family: Arial;">
                <th align="center">
                    Account Name</th>
                <th align="center">
                    Billing Hours</th>
                <th align="center">
                    Rate</th>
                <th align="center">
                    Total</th>
                <th align="center">
                    &nbsp;</th>
                <th align="center">
                    Expenses Total</th>   
                <th align="center">
                    &nbsp;</th>
                <th align="center">
                    Per Diem Count</th>
                <th align="center">
                    Rate</th>
                <th align="center">
                    Total</th>
                <th align="center">
                    Mileage Claimed</th>
                <th align="center">
                    Rate</th>
                <th align="center">
                    Total</th>
            </tr>
            <tr style="background-color: #CCCCCC;">
                <td align="center" colspan="13">
                    &nbsp;</td>
            </tr>
            <asp:Repeater ID="SummaryRepeater" runat="server" DataSourceID="SummaryDataSource">
                <ItemTemplate>
                <tr style="background-color: #FFFFFF;">
                    <td align="center" style="border-right: solid 1px black;">
                        <%# Eval("accountname") %></td>
                    <td align="center">
                        <asp:Label ID="TotalHours" runat="server" Text='<%# GetTotalTime((int)Eval("timesheetid")) %>'></asp:Label></td>
                    <td align="center">
                        <%# Eval("rate") %></td>
                    <td align="center">
                        $<asp:Label ID="TotalBillingHours" runat="server" Text='<%# GetTotalHoursCost((double)Eval("rate"),(int)Eval("timesheetid")) %>'></asp:Label></td>
                    <td align="center" style="border-right: solid 1px black;">
                        &nbsp;</td>
                    <td align="center">
                        $<asp:Label ID="TotalExpenses" runat="server" Text='<%# GetTotalExpenses((int)Eval("timesheetid")) %>'></asp:Label></td>
                    <td align="center" style="border-right: solid 1px black;">
                        &nbsp;</td>
                    <td align="center">
                       <asp:Label ID="PerDiemCount" runat="server" Text='<%# GetPerDiemCount((int)Eval("perdiemcount"),(int)Eval("timesheetid")) %>'></asp:Label></td>
                    <td align="center">
                        $<asp:Label ID="PerDiemRate" runat="server" Text='<%# GetPerDiemRate((double)Eval("perdiemrate"), (int)Eval("timesheetid")) %>'></asp:Label></td>
                    <td align="center" style="border-right: solid 1px black;">
                        $<asp:Label ID="PerDiemTotal" runat="server" Text='<%# GetPerDiemGrandTotal((int)Eval("perdiemcount"),(double)Eval("perdiemrate"), (int)Eval("timesheetid")) %>'></asp:Label>
                    </td>                   
                    <td align="center">
                        <asp:Label ID="MileageCount" runat="server" Text='<%# Eval("mileageclaimed") %>'></asp:Label></td>
                    <td align="center">
                        <asp:Label ID="MileageRate" runat="server" Text='<%# Eval("mileagerate") %>'></asp:Label></td>
                    <td align="center">
                        $<asp:Label ID="MileageTotal" runat="server" Text='<%# GetRateTotal((double)Eval("mileageclaimed"),(double)Eval("mileagerate")) %>'></asp:Label></td>
                </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr style="background-color: #CCCCCC;">
                <td align="center" style="border-right: solid 1px black;">
                    &nbsp;</td>
                <th align="center">
                    Grand Total</th>
                <th align="center">
                    &nbsp;</th>
                <th align="center">
                    Grand Total</th>
                <td align="center" style="border-right: solid 1px black;">
                    &nbsp;</td>
                <th align="center">
                    Grand Total</th>
                <td align="center" style="border-right: solid 1px black;">
                    &nbsp;</td>
                <th align="center">
                    Grand Total</th>
                <th align="center">
                    &nbsp;</th>
                <th align="center" style="border-right: solid 1px black;">
                    Grand Total</th>
                <th align="center">
                    Grand Total</th>
                <th align="center">
                    &nbsp;</th>
                <th align="center">
                    Grand Total</th>
            </tr>
            <tr style="background-color: #FFFFFF;">
                <td align="center" style="background-color: #CCCCCC;">
                    &nbsp;</td>
                <td align="center">
                    <%= SumTotalHours() %></td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    $<%= SumTotalBillingHours() %></td>
                <td align="center" style="border-right: solid 1px black;">
                    &nbsp;</td>
                <td align="center">
                    $<%= SumTotalExpenses() %></td>
                <td align="center" style="border-right: solid 1px black;">
                    &nbsp;</td>
                <td align="center">
                    <%= SumTotalPerDiemCount() %></td>
                <td align="center">
                    &nbsp;</td>
                <td align="center" style="border-right: solid 1px black;">
                    $<%= SumTotalPerDiemTotal() %></td>
                <td align="center">
                    <%= SumTotalMileageCount() %>
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    $<%= SumTotalMileageTotal() %></td>
            </tr>
            <tr style="background-color: #CCCCCC;">
                <td align="center" colspan="13">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="100%" cellspacing="0">
            <tr>
                <td align="center">
                    Report Generated:
                    <%= DateTime.Now.ToShortDateString() %>
                </td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>

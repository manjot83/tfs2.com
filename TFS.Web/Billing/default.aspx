<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" Inherits="billing_default" Codebehind="Default.aspx.cs" Title="Personal Timecards" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="field_username" runat="Server" />
    

    <asp:ObjectDataSource ID="ReportTimesheetInfoData" runat="server" TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
    SelectMethod="GetTimesheets">
        <SelectParameters>
            <asp:ControlParameter Name="Username" ControlID="field_username" PropertyName="value" Type="string" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="OpenTimesheetInfoData" runat="server" TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
    SelectMethod="GetOpenTimesheets">
        <SelectParameters>
            <asp:ControlParameter Name="Username" ControlID="field_username" PropertyName="value" Type="string" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="PendingTimesheetInfoData" runat="server" TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
    SelectMethod="GetPendingTimesheets">
    </asp:ObjectDataSource>
  

    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_3">My Pending Timesheets</h1>
    
    <table>
    <tr>
        <td style="width:150px"><span style="font-weight:bold;">Start Timecard</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Timesheet Month</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Billing Account</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Timesheet Closed Date</span></td>
    </tr>
    <asp:Repeater ID="PendingTimesheets" runat="server" DataSourceID="PendingTimesheetInfoData">
        <ItemTemplate>
            <tr>
                <td><asp:LinkButton ID="StartButton" runat="Server" Text="Start" CommandArgument='<%# Eval("id") %>' OnClick="Start_Period"></asp:LinkButton></td>
                <td><%# Eval("month")%>, <%# Eval("year")%></td>
                <td><%# Eval("accountname") %></td>
                <td><%# ((DateTime)Eval("openuntil")).ToString("d") %></td>                    
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
    

    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_1">My Active Timesheets</h1>            
    
    <table>
    <tr>
        <td style="width:150px"><span style="font-weight:bold;">Edit</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Timesheet Month</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Billing Account</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Timesheet Closed Date</span></td>
    </tr>
    <asp:Repeater ID="OpenTimesheets" runat="server" DataSourceID="OpenTimesheetInfoData">
        <ItemTemplate>
            <tr>
                <td><a href='<%# "timecard.aspx?username="+Eval("username").ToString()+"&id="+Eval("timesheetid").ToString()+"&month="+Eval("month").ToString()+"&year="+Eval("year").ToString() %>'>Edit</a></td>
                <td><%# Eval("month")%>, <%# Eval("year")%></td>
                <td><%# Eval("accountname") %></td>
                <td><%# ((DateTime) Eval("openuntil") ).ToString("d") %></td>     
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
               
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_2">My Timesheet Reports</h1>    
    
    <table>
    <tr>
        <td style="width:150px"><span style="font-weight:bold;">View Report</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Timesheet Month</span></td>
        <td style="width:150px"><span style="font-weight:bold;">Billing Account</span></td>
    </tr>
    <asp:Repeater ID="ReportableTimesheets" runat="server" DataSourceID="ReportTimesheetInfoData">
        <ItemTemplate>        
            <tr>
                <td><a href='<%# "Reports/timecardreport.aspx?username="+Eval("username").ToString()+"&id="+Eval("timesheetid").ToString() %>'>My Report</a></td>
                <td><%# Eval("month") %>, <%# Eval("year") %></td>
                <td><%# Eval("accountname") %></td>                 
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>        

</asp:Content>
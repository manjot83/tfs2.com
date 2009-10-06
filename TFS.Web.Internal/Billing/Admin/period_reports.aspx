<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="period_reports.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Admin.period_reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:ObjectDataSource ID="BillingPeriodDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodController"
SelectMethod="FetchById" UpdateMethod="Update">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="TimesheetDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
SelectMethod="FetchByBillingPeriodID">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="UsersDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
SelectMethod="GetUsernamesByBillingPeriodID">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="AccountsDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
SelectMethod="GetBillingAccountsByBillingPeriodID">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<p><a href="default.aspx">Go Back</a></p>

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_1">All Timesheets</h1>
<p>All Reportable Timesheets for this period</p>  
<asp:UpdatePanel ID="AllTimeSheetsUpdate" runat="server"><ContentTemplate>
<asp:Repeater ID="AllTimeSheets" runat="server" DataSourceID="TimesheetDataSource">
    <HeaderTemplate>
        <table>
            <tr>
                <th style="width: 150px;">
                    Username</th>
                <th style="width: 250px;">
                    Billing Account Name</th>
            </tr>
        </table>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
            <div style="border: 1px outset white; padding: 5px;">
                <div>
                    <a href='<%# "../Reports/timecardreport.aspx?username="+Eval("username")+"&id="+Eval("timesheetid")+"&month="+Eval("month")+"&year="+Eval("year") %>'>
                        View Report</a>
                </div>
                <div>
                    <a href='<%# "../timecard.aspx?id="+Eval("timesheetid").ToString()+"&username="+Eval("username").ToString()+"&month="+Eval("month")+"&year="+Eval("year") %>'>
                        Edit Timesheet Data</a>
                </div>
                <div>
                    <a href='<%# "timecard_modify.aspx?id="+Eval("timesheetid").ToString()+"&username="+Eval("username").ToString()+"&month="+Eval("month")+"&year="+Eval("year")+"&periodid="+Request.Params["id"] %>'>
                        Merge Timesheet Data</a>
                </div>
                <div>
                    <asp:LinkButton ID="DeleteTimesheetButton" runat="server" CausesValidation="False" OnClick="Delete_Timesheet"
                                    CommandArgument='<%# Eval("timesheetid") %>' Text="Delete Timesheet"></asp:LinkButton>
                    <ajax:ConfirmButtonExtender ID="ComfirmDelete" runat="server" TargetControlID="DeleteTimesheetButton" 
                                                ConfirmText="Are you sure you want to delete this timesheet?"></ajax:ConfirmButtonExtender>
                </div>                        
            </div>
        </asp:Panel>
        <asp:Panel ID="ReportPanel" runat="server">
            <table>
                <tr>
                    <td style="width: 150px;">
                        <asp:Label Font-Bold="true" ID="Label1" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Username"))) %>' /></td>
                    <td style="width: 250px;">
                        <asp:Label ID="Label2" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("AccountName"))) %>' /></td>
                </tr>
            </table>
        </asp:Panel>
        <ajax:HoverMenuExtender ID="hme2" runat="Server" PopupControlID="PopupMenu" HoverCssClass="popupHover"
            PopupPosition="Left" TargetControlID="ReportPanel" PopDelay="25" OffsetY="-15" />
    </ItemTemplate>
</asp:Repeater>
</ContentTemplate></asp:UpdatePanel>


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_2">User Reports</h1>
<p>All Users with Timesheets for this period</p>    

<asp:Repeater ID="AllUsers" runat="server" DataSourceID="UsersDataSource">
    <HeaderTemplate>
        <table>
            <tr>
                <th style="width: 150px;">
                    Username</th>
                <th style="width: 150px;">
                    &nbsp;</th>
            </tr>
        </table>
    </HeaderTemplate>
    <ItemTemplate>        
        <asp:Panel ID="ReportPanel" runat="server">
            <table>
                <tr>
                    <td style="width: 150px;">
                        <asp:Label Font-Bold="true" ID="Label1" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Username"))) %>' /></td>
                    <td style="width: 150px;">
                        <asp:HyperLink ID="UserReportLink" runat="Server" Text="User Report" Target="_blank"
                                       NavigateUrl='<%# "../reports/user_report.aspx?username="+Eval("Username")+"&id="+Request.Params["id"] %>'></asp:HyperLink>
                </tr>
            </table>
        </asp:Panel>        
    </ItemTemplate>
</asp:Repeater>
    
    
<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_3">Billing Account Reports</h1>
<p>All Billing Accounts for this period</p> 

<asp:Repeater ID="AccountsRepeater" runat="server" DataSourceID="AccountsDataSource">
    <HeaderTemplate>
        <table>
            <tr>
                <th style="width: 150px;">
                    Account Name</th>
                <th style="width: 150px;">
                    &nbsp;</th>
            </tr>
        </table>
    </HeaderTemplate>
    <ItemTemplate>        
        <asp:Panel ID="ReportPanel" runat="server">
            <table>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label Font-Bold="true" ID="Label1" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("AccountName"))) %>' /></td>
                    <td style="width: 150px;">
                        <asp:HyperLink ID="ReportLink" runat="Server" Text="Account Report" Target="_blank" NavigateUrl='<%# "../reports/account_report.aspx?accountid="+Eval("AccountID")+"&id="+Request.Params["id"] %>'></asp:HyperLink>
                </tr>
            </table>
        </asp:Panel>        
    </ItemTemplate>
</asp:Repeater>

</asp:Content>
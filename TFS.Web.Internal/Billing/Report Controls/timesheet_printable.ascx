<%@ Control Language="C#" AutoEventWireup="True" Inherits="billing_timesheet_printable" Codebehind="timesheet_printable.ascx.cs" %>

<asp:ObjectDataSource ID="UserDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.UserController"
SelectMethod="SelectUser">
    <SelectParameters>
        <asp:ControlParameter Name="Username" Type="string" ControlID="username_value" PropertyName="value" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="TimesheetDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
SelectMethod="FetchByID">
    <SelectParameters>
        <asp:ControlParameter Name="id" Type="int32" ControlID="timesheetid_value" PropertyName="value" />      
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="TimeEntryDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.TimeEntryController"
SelectMethod="FetchByTimesheetID">
    <SelectParameters>
        <asp:ControlParameter Name="timesheetid" Type="int32" ControlID="timesheetid_value" PropertyName="value" />      
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ExpenseEntryDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.ExpenseEntryController"
SelectMethod="FetchByTimesheetID">
    <SelectParameters>
        <asp:ControlParameter Name="timesheetid" Type="int32" ControlID="timesheetid_value" PropertyName="value" />      
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField runat="server" ID="timesheetid_value" />
<asp:HiddenField runat="server" ID="username_value" />
<asp:HiddenField runat="server" ID="month" />
<asp:HiddenField runat="server" ID="year" />


<!-- ##### Main Copy ##### -->
    

<table width="100%" style="border: solid 2px black; font-family:Arial;" cellspacing="0">


    <tr>
        <td colspan="4" ><asp:Image ID="imag1" runat="server" ImageUrl="~/style/template/tfs2logo_smaller.png" /></td>
        
        <td colspan="1"><h2>PAY AND EXPENSE REPORT</h2></td>
    </tr>
    <tr style="background-color: #CCCCCC;">
        <td align="left">LAST NAME:</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td align="right">JOB TITLE:</td>
    </tr>
    <!-- #### Using the repeater to grab user info here ##### -->
   <asp:Repeater ID="UserInfoRepeater" runat="server" DataSourceID="UserDataSource">
    <ItemTemplate>
        <tr style="background-color: #CCCCCC;">
            <td align="left" style="background-color: #FFFFFF; border: solid 1px black;"><b><%# Eval("LastName") %></b></td>
            <td align="center" colspan="3"><b>HOURS LOG</b></td>
            <td align="right" style="background-color: #FFFFFF; border: solid 1px black;"><b><%# Eval("Title") %></b></td>
        </tr>
    </ItemTemplate>
    </asp:Repeater>
    <tr style="background-color: #CCCCCC;">
        <td align="center">DATE</td>
        <td align="center">TIME IN (L)</td>
        <td align="center">TIME OUT (L)</td>
        <td align="center">HOURS</td>
        <td align="center">WORK DESCRIPTION</td>
    </tr>
    <!-- #### Using the repeater to grab payroll day info here ##### -->
    <asp:Repeater ID="TimeEntryRepeater" runat="server" DataSourceID="TimeEntryDataSource">
    <ItemTemplate>
        <tr >
            <td align="center" style="border: solid 1px black; border-bottom: none; border-right: none;"><b><%# month.Value+"/"+ Eval("Day")+"/"+year.Value %></b></td>
            <td align="center" style="border: solid 1px black; border-bottom: none; border-right: none;"><b><%# Eval("timein") %></b></td>
            <td align="center" style="border: solid 1px black; border-bottom: none; border-right: none;"><b><%# Eval("timeout") %></b></td>
            <td align="center" style="border: solid 1px black; border-bottom: none; border-right: none;"><b><asp:Label runat="Server" ID="TotalTimeLabel" Text='<%# getTimeDifference(Eval("timein").ToString(), Eval("timeout").ToString()) %>'></asp:Label></b></td>
            <td align="center" style="border: solid 1px black; border-bottom: none; border-right: none;"><b><%# Eval("notes") %>&nbsp;</b></td>
        </tr>
    </ItemTemplate>
    </asp:Repeater>
    <!-- #### Using the repeater to grab user info here ##### -->
    <asp:Repeater ID="PerDiemRepeater" runat="server" DataSourceID="TimesheetDataSource">
    <ItemTemplate>
        <tr style="background-color: #CCCCCC;">
            <td align="right" style="background-color: #FFFFFF; border: solid 1px black;"><b><%# Eval("PerDiemCount")%></b></td>
            <td align="left" style="border-top: solid 1px black;">TOTAL DAYS PER DIEM</td>
            <td align="right" style="border-top: solid 1px black;">TOTAL HOURS</td>
            <td align="center" style="background-color: #FFFFFF; border: solid 1px black;"><b><%= getTotalTime() %></b></td>
            <td align="center" style="background-color: #CCCCCC; border-top: solid 1px black;">&nbsp;</td>
        </tr>
        <tr style="background-color: #CCCCCC;">
            <td align="right" style="background-color: #FFFFFF; border: solid 1px black; border-top:none;"><b>$<%# CalcTotalPerDiem((int)Eval("PerDiemCount")) %></b></td>
            <td align="left">TOTAL PER DIEM DUE</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
        </tr>
        <tr style="background-color: #CCCCCC;">
            <td align="right" style="background-color: #FFFFFF; border: solid 1px black; border-top:none;"><b><%# Eval("MileageClaimed") %></b> Miles</td>
            <td align="left">TOTAL MILEAGE CLAIMED</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
        </tr>
        <tr style="background-color: #CCCCCC;">
            <td align="right" style="background-color: #FFFFFF; border: solid 1px black; border-bottom: none; border-top:none;"><b>$<%# CalcTotalMileage((double)Eval("MileageClaimed")) %></b></td>
            <td align="left">TOTAL MILEAGE DUE</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
        </tr> 
    </ItemTemplate>
    </asp:Repeater> 
    <tr style="background-color: #CCCCCC;">
        <td align="center" style="border-top: solid 2px black;">&nbsp;</td>
        <td align="center" style="border-top: solid 2px black;"><b>EXPENSE LOG</b></td>
        <td align="center" style="border-top: solid 2px black;">(Attach Receipts)</td>
        <td align="center" style="border-top: solid 2px black;">&nbsp;</td>
        <td align="center" style="border-top: solid 2px black;">&nbsp;</td>
    </tr>
    <tr style="background-color: #CCCCCC;">
        <td align="center">Date</td>
        <td align="center" colspan="3">Description</td>
        <td align="center">Cost</td>
    </tr>
    <!-- #### Using the repeater to grab payroll expense info here ##### -->
    <asp:Repeater ID="ExpenseRepeater" runat="server" DataSourceID="ExpenseEntryDataSource">
    <ItemTemplate>
        <tr>
            <td align="center" style="border: solid 1px black; border-bottom: none; border-right: none;"><b> <asp:Label ID="Label2" runat="server" Text='<%# DateTime.Parse(Eval("ExpenseDate").ToString()).ToString("d") %>' /></b></td>
            <td align="left" colspan="3" style="border: solid 1px black; border-bottom: none; border-right: none;"><b><%# Eval("ExpenseDesc")%></b></td>            
            <td align="right" style="border: solid 1px black; border-bottom: none; border-right: none;"><b>$<asp:Label ID="CostLabel" runat="server" Text='<%# Eval("Cost") %>'></asp:Label></b></td>
        </tr>
    </ItemTemplate>
    </asp:Repeater>
    <tr style="background-color: #CCCCCC;">
        <td align="left" style="border-top: solid 1px black;">Account</td>
        <asp:Repeater ID="AccountDataSource" runat="server" DataSourceID="TimesheetDataSource">
            <ItemTemplate>
                <td colspan="2" align="center" style="background-color: #FFFFFF; border: solid 1px black;"><b><%# Eval("AccountName") %></b></td>
            </ItemTemplate>
        </asp:Repeater>
        <td align="right" style="border-top: solid 1px black;">TOTAL COST</td>
        <td align="right" style="background-color: #FFFFFF; border: solid 1px black; border-right: none;"><b>$<%= getTotalCost() %></b></td>
    </tr>
    <tr style="background-color: #CCCCCC;">
        <td align="left">Ops Supervisor Signature</td>
        <td align="center" style="background-color: #FFFFFF; border: solid 1px black; border-bottom: none; border-top: none;"><i><b>MBO</b></i></td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
    </tr>
    <tr style="background-color: #CCCCCC;">
        <td align="left">Program Manager Signature</td>
        <td align="center" style="background-color: #FFFFFF; border: solid 1px black; border-bottom: none;"><i><b>WWP</b></i></td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
    </tr>   
</table>

<table width="100%" cellspacing="0">
<tr>
        <td align="left">TFS FORM 36-5</td>
        <td align="center">Report Generated: <%= DateTime.Now.ToShortDateString() %></td>
        <td align="right">20-Jun-06</td>
</tr>
</table>
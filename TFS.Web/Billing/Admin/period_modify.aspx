<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="period_modify.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Admin.period_modify" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<asp:ScriptManager ID="ScriptManager1" runat="server" />


<asp:ObjectDataSource ID="BillingPeriodDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodController"
SelectMethod="FetchById" UpdateMethod="Update">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="OpenUntil" Type="datetime" />
    </UpdateParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="DisabledBillingPeriodAccountDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodAccountController"
SelectMethod="FetchAccountsNotActive">
    <SelectParameters>
        <asp:QueryStringParameter Name="periodid" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="BillingPeriodAccountDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodAccountsJoinController"
SelectMethod="FetchByPeriodID">
    <SelectParameters>
        <asp:QueryStringParameter Name="periodid" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="BillingRateDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingRatesJoinController"
SelectMethod="FetchByPeriodID">
    <SelectParameters>
        <asp:QueryStringParameter Name="periodid" QueryStringField="id" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<p><a href="default.aspx">Go Back</a></p>

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">Period Information</h1>    

<asp:UpdatePanel ID="BillingInfoUpdatePanel" runat="Server">
<ContentTemplate>
    <asp:FormView ID="BillingPeriodUpdateForm" runat="server" DefaultMode="Edit" DataSourceID="BillingPeriodDataSource" DataKeyNames="id" OnItemUpdated="Period_Updated">
    <EditItemTemplate>
        <p>
            Period Date: <b><asp:Label ID="month" runat="server" Text='<%# Eval("Month") %>'></asp:Label>, 
            <asp:Label ID="year" runat="server" Text='<%# Eval("Year") %>'></asp:Label></b>
            <br /><br />
            You can select a new <b>close date</b> for the period here, and then press <b>update</b>.
            <br /><br />
            
            <asp:TextBox ID="OpenUntilDate" runat="server" Text='<%# Bind("OpenUntil", "{0:d}") %>'></asp:TextBox>
            <asp:ImageButton runat="Server" ID="CalImage1" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
            <ajax:CalendarExtender ID="OpenUntilDateExtender" runat="Server" TargetControlID="OpenUntilDate" PopupButtonID="CalImage1" Format="d"></ajax:CalendarExtender>
            
            <br />
            <br />
            <asp:LinkButton ID="UpdateButton" CommandName="Update" runat="Server" Text="Update"></asp:LinkButton><br />
            <asp:LinkButton ID="CancelButton" CommandName="Cancel" runat="server" Text="Cancel Update"></asp:LinkButton>
            
         </p>
    </EditItemTemplate>
    </asp:FormView>
    <p>
    <asp:Label ID="UpdateStatus" runat="Server" ForeColor="red"></asp:Label>
    </p>
</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="RateUpdatePanel" runat="server">
<ContentTemplate>
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_1">Billing Account Information</h1>
    <p>
    The <b>first list</b> contains accounts that are not enabled for this billing period. Accounts need to be enabled for timesheets to be created. You cannot disable an account once it has been enabled.<br /><br />
    The <b>second list</b> allows you to alter rates from the account defaults. These changes ONLY affect this billing month.<br /><br />
    <b>If rate groups are missing for a particular Billing Account</b> then you can click <asp:LinkButton ID="FixButton" runat="Server" OnClick="Fix_BillingRates">Here</asp:LinkButton> to fix them.</p>
    <hr />
    <p><b>Accounts NOT Enabled for this Period</b></p>
    <asp:Repeater ID="DisabledAccountsRepeater" runat="server" DataSourceID="DisabledBillingPeriodAccountDataSource">
    <HeaderTemplate><p></HeaderTemplate>
    <ItemTemplate>
        <b>Account:</b> <asp:Label ID="AccountName" runat="Server" Text='<%# Eval("name") %>'></asp:Label>&nbsp;&nbsp;
        <asp:LinkButton ID="EnableButton" runat="Server" Text="Enable" OnClick="Enable_BillingAccount" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
        <br />
    </ItemTemplate>
    <FooterTemplate></p></FooterTemplate>
    </asp:Repeater>
    <hr />
    <p><b>Accounts Enabled for this Period</b></p>
    <table>
        <tr>
            <th style="width: 150px;">Account</th>
            <th style="width: 150px;">Rate Group</th>
            <th style="width: 100px;">Rate</th>
            <th style="width: 100px;">Command</th>
            <th style="width: 100px;">Status</th>
        </tr>
        <asp:Repeater ID="AccountsPerDiemRepeater" runat="server" DataSourceID="BillingPeriodAccountDataSource" OnItemCommand="PerDiemRate_Command">
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="Label1" runat="Server" Text='<%# Eval("accountname") %>'></asp:Label></td>
                <td>Per Diem</td>
                <td>$<asp:TextBox ID="rate" runat="Server" Text='<%# Eval("perdiemrate") %>' Width="50"></asp:TextBox></td>
                <td><asp:LinkButton ID="PerDiemSet" runat="server" CommandName="SetRate" CommandArgument='<%# Eval("id") %>'>Set Rate</asp:LinkButton></td>
                <td><asp:Label ID="status" runat="server" ForeColor="red"></asp:Label></td>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
        <asp:Repeater ID="AccountsMileageRepeater" runat="server" DataSourceID="BillingPeriodAccountDataSource" OnItemCommand="MileageRate_Command">
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="Label1" runat="Server" Text='<%# Eval("accountname") %>'></asp:Label></td>
                <td>Mileage</td>
                <td>$<asp:TextBox ID="rate" runat="Server" Text='<%# Eval("mileagerate") %>' Width="50"></asp:TextBox></td>
                <td><asp:LinkButton ID="MileageSet" runat="server" CommandName="SetRate" CommandArgument='<%# Eval("id") %>'>Set Rate</asp:LinkButton></td>
                <td><asp:Label ID="status" runat="server" ForeColor="red"></asp:Label></td>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
        <asp:Repeater ID="AccountsBillingRatesRepeater" runat="server" DataSourceID="BillingRateDataSource" OnItemCommand="BillingRate_Command">
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="Label1" runat="Server" Text='<%# Eval("accountname") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="Server" Text='<%# Eval("rategroupname") %>'></asp:Label></td>
                <td>$<asp:TextBox ID="rate" runat="Server" Text='<%# Eval("rate") %>' Width="50"></asp:TextBox></td>
                <td><asp:LinkButton ID="PerDiemSet" runat="server" CommandName="SetRate" CommandArgument='<%# Eval("id") %>'>Set Rate</asp:LinkButton></td>
                <td><asp:Label ID="status" runat="server" ForeColor="red"></asp:Label></td>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
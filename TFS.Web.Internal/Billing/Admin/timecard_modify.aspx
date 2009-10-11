<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="timecard_modify.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Admin.timecard_modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />


<asp:ObjectDataSource ID="UserDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.UserController"
SelectMethod="SelectUser">
    <SelectParameters>
        <asp:QueryStringParameter Name="Username" Type="string" QueryStringField="username" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="TimesheetDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.EmployeeTimesheetInfoController"
SelectMethod="FetchByID">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" Type="int32" QueryStringField="id" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="TimeEntryDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.TimeEntryController"
SelectMethod="FetchByTimesheetID">
    <SelectParameters>
        <asp:QueryStringParameter Name="timesheetid" Type="int32" QueryStringField="id" />        
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ExpenseEntryDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.ExpenseEntryController"
SelectMethod="FetchByTimesheetID">
    <SelectParameters>
        <asp:QueryStringParameter Name="timesheetid" Type="int32" QueryStringField="id" />        
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="BillingPeriodAccountDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodAccountsJoinController"
SelectMethod="FetchByPeriodID">
    <SelectParameters>
        <asp:QueryStringParameter Name="periodid" QueryStringField="periodid" Type="int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField runat="server" ID="month" />
<asp:HiddenField runat="server" ID="year" />

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_1">
    Time and Expense Sheet</h1>

<p>
    Editing Payroll for User:
    <asp:Repeater ID="UserDetailsView" runat="Server" DataSourceID="UserDataSource">
        <ItemTemplate><b><asp:Label ID="Lastname" runat="server" Text='<%# Eval("lastname") %>' />,
            <asp:Label ID="Firstname" runat="server" Text='<%# Eval("firstname") %>' /></b><%-- - 
            <b><asp:Label ID="title" runat="server" Text='<%# Eval("title") %>'></asp:Label></b>--%>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <asp:Repeater ID="TimesheetInfoDetails" runat="server" DataSourceID="TimesheetDataSource">
        <ItemTemplate>
        Month: <b><asp:Label ID="month" runat="server" Text='<%# Eval("month") %>'></asp:Label>,
        <asp:Label ID="year" runat="server" Text='<%# Eval("year") %>'></asp:Label></b>&nbsp;
        Account: <b><asp:Label ID="accountname" runat="server" Text='<%# Eval("accountname") %>'></asp:Label></b>
        </ItemTemplate>
    </asp:Repeater>
</p>


<h1>Pay Rate Group</h1>
<p>
    Rate Group: <b><asp:Label ID="PayRateGroup" runat="Server"></asp:Label></b>
</p>

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_4">
    Per Diem Worksheet</h1>
<p>
Days<br />
<b><asp:Label ID="DaysPerDiem" runat="Server"></asp:Label></b>
</p>


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_5">
    Mileage Worksheet</h1>
<p><b><asp:Label ID="Mileage" runat="server"></asp:Label></b> Miles</p>


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_2">
    Hours Timesheet</h1>
<br />
<asp:UpdatePanel ID="TimeEntryUpdatePanel" runat="Server"><ContentTemplate>
<asp:GridView ID="TimeEntryGridView" runat="server" AutoGenerateColumns="False"
    CellPadding="3" DataSourceID="TimeEntryDataSource" GridLines="None" BackColor="White"
    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1"
    DataKeyNames="id">
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                    <div style="border: 1px outset white; padding: 5px;">
                        <div>
                            <asp:HiddenField ID="TimeEntryID" runat="server" Value='<%# Eval("id") %>' />
                            <asp:Repeater ID="BillingPeriodRepeater" runat="Server" DataSourceID="BillingPeriodAccountDataSource" OnItemCommand="TimeEntry_Repeater_Command" >
                            <ItemTemplate>
                                <asp:LinkButton ID="ChangeButton" runat="server" CommandName="Select" CommandArgument='<%# Eval("id") %>' Text='<%# Eval("accountname") %>'></asp:LinkButton><br />
                                <ajax:ConfirmButtonExtender ID="COmfirmChange" runat="server" TargetControlID="ChangeButton" ConfirmText="Are you sure?"></ajax:ConfirmButtonExtender>
                            </ItemTemplate>
                            </asp:Repeater>
                        </div>                                   
                    </div>
                </asp:Panel>
                <asp:Label ID="MergeLabel" runat="server" Text="Move To:" Font-Underline="true" ForeColor="#2A5400" Font-Bold="true"></asp:Label>
                <ajax:HoverMenuExtender ID="hme2" runat="Server" PopupControlID="PopupMenu" HoverCssClass="popupHover"
                    PopupPosition="Right" TargetControlID="MergeLabel" PopDelay="25" OffsetY="-15" />
            </ItemTemplate>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Day" SortExpression="day" ItemStyle-Width="100">
            <ItemTemplate>
                <asp:Label ID="DayLabel" runat="server" Text='<%# month.Value+"/"+ Eval("Day")+"/"+year.Value %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Time In" SortExpression="timein" ItemStyle-Width="100">
            <ItemTemplate>
                <asp:Label ID="TimeInLabel" runat="server" Text='<%# Eval("timein") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Time Out" SortExpression="timeout" ItemStyle-Width="100">
            <ItemTemplate>
                <asp:Label ID="TimeOutLabel" runat="server" Text='<%# Eval("timeout") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Time" ItemStyle-Width="100">
            <ItemTemplate>
                <asp:Label ID="TotalTimeLabel" runat="server" Text='<%# getTimeDifference(Eval("timein").ToString(), Eval("timeout").ToString()) %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="notes" HeaderText="Notes" SortExpression="notes" ItemStyle-Width="250" />        
    </Columns>
    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
    <EmptyDataTemplate>
    No Entries Entered Yet
    </EmptyDataTemplate>
</asp:GridView>
<p>
    Total Hours Worked: <b>
    <%= getTotalTime() %>
    </b>
</p>
</ContentTemplate></asp:UpdatePanel>



<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">
    Expense Worksheet</h1>
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="Server"><ContentTemplate>
<asp:GridView ID="ExpenseGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
    GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
    CellSpacing="1" DataKeyNames="id" DataSourceID="ExpenseEntryDataSource">
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
    <Columns>
     <asp:TemplateField>
            <ItemTemplate>
                <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                    <div style="border: 1px outset white; padding: 5px;">
                        <div>
                            <asp:HiddenField ID="ExpenseEntryID" runat="server" Value='<%# Eval("id") %>' />
                            <asp:Repeater ID="ExpenseRepeater" runat="Server" DataSourceID="BillingPeriodAccountDataSource" OnItemCommand="Expense_Repeater_Command" >
                            <ItemTemplate>
                                <asp:LinkButton ID="ChangeButton" runat="server" CommandName="Select" CommandArgument='<%# Eval("id") %>' Text='<%# Eval("accountname") %>'></asp:LinkButton><br />
                                <ajax:ConfirmButtonExtender ID="ComfirmChange" runat="server" TargetControlID="ChangeButton" ConfirmText="Are you sure?"></ajax:ConfirmButtonExtender>
                            </ItemTemplate>
                            </asp:Repeater>
                        </div>                                   
                    </div>
                </asp:Panel>
                <asp:Label ID="MergeLabel" runat="server" Text="Move To:" Font-Underline="true" ForeColor="#2A5400" Font-Bold="true"></asp:Label>
                <ajax:HoverMenuExtender ID="hme2" runat="Server" PopupControlID="PopupMenu" HoverCssClass="popupHover"
                    PopupPosition="Right" TargetControlID="MergeLabel" PopDelay="25" OffsetY="-15" />
            </ItemTemplate>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Expense Date" SortExpression="Expense Date" ItemStyle-Width="100">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# DateTime.Parse(Eval("expensedate").ToString()).ToString("d") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="expensedesc" HeaderText="Expense Description" SortExpression="expensedesc" ItemStyle-Width="350" />
        <asp:TemplateField HeaderText="Cost" SortExpression="cost" ItemStyle-Width="100">
            <ItemTemplate>
                $<asp:Label ID="Cost" runat="server" Text='<%# Eval("cost") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>No Entries Entered</EmptyDataTemplate>
</asp:GridView>
<p>
    Total Expenses: <b>$<%= getTotalCost() %></b></p>
</ContentTemplate></asp:UpdatePanel>





</asp:Content>
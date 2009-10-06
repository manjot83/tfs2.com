<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="timecard.aspx.cs" Inherits="TFS.Intranet.Web.Billing.timecard" Title="Timecard" %>


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
SelectMethod="FetchByTimesheetID"
DeleteMethod="Delete"
UpdateMethod="Update">
    <SelectParameters>
        <asp:QueryStringParameter Name="timesheetid" Type="int32" QueryStringField="id" />        
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="ExpenseEntryDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.ExpenseEntryController"
SelectMethod="FetchByTimesheetID"
DeleteMethod="Delete"
UpdateMethod="Update">
    <SelectParameters>
        <asp:QueryStringParameter Name="timesheetid" Type="int32" QueryStringField="id" />        
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="TimeValuesDataSource" runat="server" SelectMethod="getTimeOfDay"
    TypeName="TFS.Intranet.Web.Calendar">
    <SelectParameters>
        <asp:Parameter Name="TimeType" Type="String" DefaultValue="All" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="HourValuesDataSource" runat="server" SelectMethod="getTimeOfDay"
    TypeName="TFS.Intranet.Web.Calendar">
    <SelectParameters>
        <asp:Parameter Name="TimeType" Type="String" DefaultValue="Hour" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="MinuteValuesDataSource" runat="server" SelectMethod="getTimeOfDay"
    TypeName="TFS.Intranet.Web.Calendar">
    <SelectParameters>
        <asp:Parameter Name="TimeType" Type="String" DefaultValue="Minute" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="DayValuesDataSource" runat="server" SelectMethod="getDaysOfMonth"
    TypeName="TFS.Intranet.Web.Calendar">
    <SelectParameters>
        <asp:QueryStringParameter Name="Month" Type="int32" QueryStringField="month" />
        <asp:QueryStringParameter Name="Year" Type="int32" QueryStringField="year" />
    </SelectParameters>
</asp:ObjectDataSource>



<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_1">
    Time and Expense Sheet</h1>
<p>
    <b>Instructions:</b><br />
    This is your basic timesheet information for this month. Ensure it is correct, if
    it is not please let someone know. Be sure to fill in your days Per Diem.</p>
<p>
    Editing Payroll for User:
    <asp:Repeater ID="UserDetailsView" runat="Server" DataSourceID="UserDataSource">
        <ItemTemplate><b><asp:Label ID="Lastname" runat="server" Text='<%# Eval("lastname") %>' />,
            <asp:Label ID="Firstname" runat="server" Text='<%# Eval("firstname") %>' /></b> - 
            <b><asp:Label ID="title" runat="server" Text='<%# Eval("title") %>'></asp:Label></b>
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


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_4">
    Per Diem Worksheet</h1>
<p>
    <b>Instructions</b><br />
    Use this worksheet to fill out Per Diem Counts for this month for this account.</p>

Change Number<br />
<asp:UpdatePanel ID="PerDiemUpdatePanel" runat="Server">
    <ContentTemplate>
        <p>
        <asp:DropDownList ID="PerDiemCountDropDown" runat="server" DataSourceID="DayValuesDataSource"
            DataTextField="Day" DataValueField="Day" AppendDataBoundItems="true" Width="60px"
            OnSelectedIndexChanged="Change_PerDiem" AutoPostBack="true">
            <asp:ListItem Text="0" Value="0" />
        </asp:DropDownList>
        <asp:Label ID="PerDiemChangeStatus" runat="server" ForeColor="red"></asp:Label>
        </p>
    </ContentTemplate>    
</asp:UpdatePanel>


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_5">
    Mileage Worksheet</h1>
<p>
    <b>Instructions</b><br />
    Use this worksheet to fill out claimed mileage for the month. <b>Only fill out if you are allowed to claim mileage under this account.</b></p>

Change Mileage<br />
<asp:UpdatePanel ID="MileageUpdatePanel" runat="Server">
    <ContentTemplate>
        <p>
        <asp:TextBox ID="Mileage_Textbox" runat="server">0</asp:TextBox>
        <asp:LinkButton ID="Mileage_Set" runat="server" Text="Set Mileage" ValidationGroup="Mileage" OnClick="Change_Mileage"></asp:LinkButton>
        <asp:Label ID="Mileage_Status" runat="server" ForeColor="red"></asp:Label>
        <asp:RequiredFieldValidator ID="Mileage_Required" runat="server" ControlToValidate="Mileage_Textbox" ErrorMessage="Do not leave blank" ValidationGroup="Mileage"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="Mileage_Regex" runat="server" ControlToValidate="Mileage_Textbox" ErrorMessage="Only Numbers" ValidationExpression="^([0-9]+[.]?[0-9]*)$" ValidationGroup="Mileage"></asp:RegularExpressionValidator>        
        </p>
    </ContentTemplate>    
</asp:UpdatePanel>


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_2">
    Hours Timesheet</h1>
<p>
    <b>Instructions:</b><br />
    This is your timesheet. Ensure the information listed above is correct before filling
    it out. Insert days with the form below by selected the day of the month, and the
    time-in/time-out times rounded to the nearest quarter hour. Please include notes
    indicating work done. Once a date has been entered, you can edit the details by
    pressing <b><i>Edit</i></b> or delete the entry by pressing <b><i>Delete</i></b>.</p>
<br />
<asp:UpdatePanel ID="TimeEntryUpdatePanel" runat="server">
<ContentTemplate>
    <asp:GridView ID="TimeEntryGridView" runat="server" AutoGenerateColumns="False"
        CellPadding="3" DataSourceID="TimeEntryDataSource" GridLines="None" BackColor="White"
        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1"
        DataKeyNames="id">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <Columns>
            <asp:TemplateField ShowHeader="False" ItemStyle-Width="100">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel"></asp:LinkButton>
                    <asp:HiddenField ID="timesheetid" runat="Server" Value='<%# Bind("timesheetid") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Edit"></asp:LinkButton>
                    <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Delete"></asp:LinkButton>
                    <ajax:ConfirmButtonExtender ID="DeleteConfirmExtender" runat="server" TargetControlID="DeleteButton"
                        ConfirmText="Are you sure you want to delete this entry?"></ajax:ConfirmButtonExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Day" SortExpression="day" ItemStyle-Width="30">
                <ItemTemplate>
                    <asp:Label ID="DayLabel" runat="server" Text='<%# Eval("Day") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="DayLabel" runat="server" Text='<%# Eval("day") %>' />
                    <asp:HiddenField ID="DayBinding" runat="server" Value='<%# Bind("day") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Time In" SortExpression="timein" ItemStyle-Width="90">
                <ItemTemplate>
                    <asp:Label ID="TimeInLabel" runat="server" Text='<%# Eval("timein") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="TimeInDropDown" runat="server" DataSourceID="TimeValuesDataSource"
                        DataTextField="Time" DataValueField="Time" SelectedValue='<%# Bind("timein") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Time Out" SortExpression="timeout" ItemStyle-Width="90">
                <ItemTemplate>
                    <asp:Label ID="TimeOutLabel" runat="server" Text='<%# Eval("timeout") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="TimeOutDropDown" runat="server" DataSourceID="TimeValuesDataSource"
                        DataTextField="Time" DataValueField="Time" SelectedValue='<%# Bind("timeout") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Time" ItemStyle-Width="90">
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
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="HoursSubmit" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
<p>
    <b>Insert New Day</b>
</p>
<table style="border: solid 2px black;">
    <tr>
        <td style="width:75px;">
            <b>Day</b></td>
        <td style="width:150px;">
            <b>Time In</b></td>
        <td style="width:150px;">
            <b>Time Out</b></td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="Day" runat="server" DataSourceID="DayValuesDataSource" DataTextField="Day"
                DataValueField="Day" /></td>
        <td>
            <asp:DropDownList ID="TimeInHours" runat="server" DataSourceID="HourValuesDataSource"
                DataTextField="Time" DataValueField="Time" />
            :
            <asp:DropDownList ID="TimeInMinutes" runat="server" DataSourceID="MinuteValuesDataSource"
                DataTextField="Time" DataValueField="Time" />
        </td>
        <td>
            <asp:DropDownList ID="TimeOutHours" runat="server" DataSourceID="HourValuesDataSource"
                DataTextField="Time" DataValueField="Time" />
            :
            <asp:DropDownList ID="TimeOutMinutes" runat="server" DataSourceID="MinuteValuesDataSource"
                DataTextField="Time" DataValueField="Time" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <b>Notes:</b>
            <asp:TextBox ID="Notes" Width="90%" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="InsertHours" ControlToValidate="Notes"
                Text="Notes Are Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="HoursSubmit" OnClick="inserting_timeentry" Text="Add" runat="Server" ValidationGroup="InsertHours" /></td>
    </tr>
</table>


<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">
    Expense Worksheet</h1>
<p>
    <b>Instructions:</b><br />
    Please remember to select a <b>Date</b>. Be sure to also include a <b>Description</b>.
    For mileage, please pre-calculate with approved rate and enter for <b>cost</b>.</p>
<br />
<asp:UpdatePanel ID="ExpenseUpdatePanel" runat="server">
<ContentTemplate>

    <asp:GridView ID="ExpenseGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
        GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
        CellSpacing="1" DataKeyNames="id" DataSourceID="ExpenseEntryDataSource">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <Columns>
            <asp:TemplateField ShowHeader="False" ItemStyle-Width="100">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel"></asp:LinkButton>
                    <asp:HiddenField ID="timesheetid" runat="Server" Value='<%# Bind("timesheetid") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Edit"></asp:LinkButton>
                    <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Delete"></asp:LinkButton>
                    <ajax:ConfirmButtonExtender ID="DeleteConfirmExtender" runat="server" TargetControlID="DeleteButton"
                        ConfirmText="Are you sure you want to delete this entry?"></ajax:ConfirmButtonExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expense Date" SortExpression="Expense Date" ItemStyle-Width="200">
                <EditItemTemplate>
                    <asp:TextBox ID="EditExpenseDate" runat="server" Text='<%# Bind("expensedate", "{0:d}") %>'></asp:TextBox>
                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
                    <ajax:CalendarExtender ID="EditExpenseDateExtender" runat="server" TargetControlID="EditExpenseDate" PopupButtonID="Image1" Format="d"></ajax:CalendarExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# DateTime.Parse(Eval("expensedate").ToString()).ToString("d") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="expensedesc" HeaderText="Expense Description" SortExpression="expensedesc" ItemStyle-Width="350" />
            <asp:TemplateField HeaderText="Cost" SortExpression="cost" ItemStyle-Width="100">
                <EditItemTemplate>
                    $<asp:TextBox ID="Cost" runat="server" Text='<%# Bind("cost") %>' Width="75px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    $<asp:Label ID="Cost" runat="server" Text='<%# Eval("cost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>No Entries Entered</EmptyDataTemplate>
    </asp:GridView>


    <p>
        Total Expenses: <b>$<%= getTotalCost() %></b></p>
    <p>

</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="ExpenseInsertSubmit" EventName="Click" />
</Triggers>
</asp:UpdatePanel>

<p><b>Insert New Expense</b></p>
<table cellspacing="10" style="border: solid 2px black;">
    <tr>
        <td align="center" style="width:160px;">
            <b>Expense Date</b></td>
        <td align="center" style="width:350px;">
            <b>Expense Description</b></td>
        <td align="center" style="width:150px;">
            <b>Cost $</b></td>
    </tr>
    <tr align="center">
        <td>
            <asp:TextBox ID="ExpenseDate" runat="server"></asp:TextBox>
            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
            <ajax:CalendarExtender ID="ExpenseDateExtender" runat="server" TargetControlID="ExpenseDate" PopupButtonID="Image1"></ajax:CalendarExtender>            
        </td>
        <td>
            <asp:TextBox ID="ExpenseDesc" runat="server" Width="345px" /></td>
        <td>
            <asp:TextBox ID="ExpenseCost" runat="server" MaxLength="8" Width="60" /></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="ExpenseInsertSubmit" CommandName="Insert" Text="Add" runat="Server"
                ValidationGroup="InsertExpense" OnClick="inserting_expense_entry" /></td>
    </tr>
    <tr>
        <td colspan="3">
            Please remember to select a valid date<br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="InsertExpense"
                runat="server" ControlToValidate="ExpenseDate" Text="Date Required"></asp:RequiredFieldValidator>&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator0" ValidationGroup="InsertExpense"
                runat="server" ControlToValidate="ExpenseDesc" Text="Description Required"></asp:RequiredFieldValidator>&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="InsertExpense"
                runat="server" ControlToValidate="ExpenseCost" Text="Cost Required"></asp:RequiredFieldValidator>&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="InsertExpense"
                ControlToValidate="ExpenseCost" ValidationExpression="[0-9]*\.?[0-9]*" Text="Please only enter numbers for cost"></asp:RegularExpressionValidator>
        </td>
    </tr>
</table>


</asp:Content>
<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="period_new.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Admin.period_new" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<asp:ObjectDataSource ID="BillingPeriodDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodController"
InsertMethod="Insert"
SelectMethod="FetchAll">
</asp:ObjectDataSource>

<p><a href="default.aspx">Go Back</a></p>

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">New Billing Period</h1>    
<br />

<p>Existing Periods</p>
<asp:GridView ID="OpenPeriodGridView" runat="server" DataSourceID="BillingPeriodDataSource"
AutoGenerateColumns="false"  Width="50%" BorderStyle="none" BorderWidth="0" >

    <Columns>        
        <asp:TemplateField HeaderText="Billing Period Month">
            <ItemTemplate>
                <%# Eval("Month") %>, <%# Eval("Year") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Billing Period Close Date">                    
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# DateTime.Parse(Eval("openuntil").ToString()).ToString("d") %>'></asp:Label>                        
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


<br />
<hr />

<asp:FormView ID="InsertBillingPeriodForm" BorderStyle="Groove" DataSourceID="BillingPeriodDataSource"
                BorderColor="black" BorderWidth="0" runat="server" DefaultMode="Insert" 
                 Width="90%" OnItemInserted="BillingPeriod_Inserted">
<InsertItemTemplate>   
        Select <b>Month</b> and <b>Year</b>
        <br />
        DO NOT ENTER A MONTH/YEAR THAT EXISTS ABOVE
        <br />
        <asp:DropDownList ID="Month" runat="server" SelectedValue='<%# Bind("Month") %>'>
            <asp:ListItem Text="1" Value="1" />
            <asp:ListItem Text="2" Value="2" />
            <asp:ListItem Text="3" Value="3" />
            <asp:ListItem Text="4" Value="4" />
            <asp:ListItem Text="5" Value="5" />
            <asp:ListItem Text="6" Value="6" />
            <asp:ListItem Text="7" Value="7" />
            <asp:ListItem Text="8" Value="8" />
            <asp:ListItem Text="9" Value="9" />
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="11" Value="11" />
            <asp:ListItem Text="12" Value="12" />
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="Year" runat="server" SelectedValue='<%# Bind("Year") %>'>
            <asp:ListItem Text="2006" Value="2006" />
            <asp:ListItem Text="2007" Value="2007" />
            <asp:ListItem Text="2008" Value="2008" />
            <asp:ListItem Selected="True" Text="2009" Value="2009" />
            <asp:ListItem Text="2010" Value="2010" />
            <asp:ListItem Text="2011" Value="2011" />
            <asp:ListItem Text="2012" Value="2012" />
        </asp:DropDownList>               
    </p>
    <p>
        Select Date <b>Billing Period is Closed</b><br />
        <asp:TextBox ID="OpenUntilDate" runat="server" Text='<%# Bind("OpenUntil") %>'></asp:TextBox>
        <asp:ImageButton runat="Server" ID="CalImage1" ImageUrl="~/Images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
        <ajax:CalendarExtender ID="OpenUntilDateExtender" runat="Server" TargetControlID="OpenUntilDate" PopupButtonID="CalImage1"></ajax:CalendarExtender>
    </p>
        After the billing period as been created, you will be able to <b>Modify</b> this new billing period and
        insert/edit <b>Billing Accounts</b> and set the rates.
    <p>
        <b>Please make sure all information is correct</b><br />
        <asp:Button ID="Submit" CommandName="Insert" Text="Start Billing Period" runat="Server" />
    </p>
</InsertItemTemplate>
</asp:FormView>           


</asp:Content>
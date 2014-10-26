<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TFS.Intranet.Web.Billing.Admin._default" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<asp:ObjectDataSource ID="BillingPeriodDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.BillingPeriodController"
SelectMethod="FetchOrdered">
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="UserDataSource" runat="server"
TypeName="TFS.Intranet.Data.Billing.UserController"
SelectMethod="FetchAll">
</asp:ObjectDataSource>


<!-- START OF THE BILLING ACCOUNTS SECTION -->   

<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_3">Billing Accounts</h1>    
<br />
<p>
Click <a href="billingaccount_manage.aspx">Here</a> to manage billing accounts.
</p>


<!-- START OF PAYROLL PERIODS SECTION -->
    
<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_1">Billing Periods</h1>               
<br />
<p>
   Select <b>Edit</b> to bring up the edit page
   or press <b>Reports</b> to view reports for that billing period.<br />
   To view/edit Billing Account rates, select <b>Edit</b>
</p>
<asp:GridView ID="OpenPeriodGridView" runat="server" DataSourceID="BillingPeriodDataSource"
AutoGenerateColumns="false" BorderStyle="none" BorderWidth="0" BorderColor="white" >
    
    <Columns>
        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="100" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
            <ItemTemplate>
                <a href='<%# "period_modify.aspx?id="+Eval("id").ToString() %>'>Modify</a>                                    
            </ItemTemplate>                   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="120" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
            <ItemTemplate>
                <a href='<%# "period_reports.aspx?id="+Eval("id").ToString() %>'>Timecards & Reports</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Billing Period Month" HeaderStyle-Width="200" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
            <ItemTemplate>
                <%# Eval("Month") %>, <%# Eval("Year") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Billing Period Close Date" HeaderStyle-Width="200" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">                    
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# DateTime.Parse(Eval("openuntil").ToString()).ToString("d") %>'></asp:Label>                        
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


<br />
<p>
<a href="period_new.aspx">Create New Billing Period</a>
</p>


<!-- START OF THE User ACCOUNTS SECTION -->
           
<a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
<h1 id="H1_2">Payroll User Roster</h1>    
<br />
<p><b>If someone is not listed</b> it probably means one or more pieces of information are missing for their account. See editing the roster.</p>
<p><b>Editing Roster: </b>Editing is done from <i>User Administration</i>, linked on the left. For a user to be listed in the payroll roster (this able to fill out timecards) 1) All profile information must be filled out 2) they must have explicit access 3) they must be assigned a payroll group.</p>


<asp:GridView ID="UsersGridView" runat="server" DataSourceID="UserDataSource"
    AutoGenerateColumns="false" BorderStyle="none" BorderWidth="0" BorderColor="white">
    <Columns>
        <asp:BoundField DataField="Username" ReadOnly="true" HeaderText="Username" SortExpression="Username" HeaderStyle-Width="150" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
        <asp:BoundField DataField="FirstName" ReadOnly="true" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-Width="150" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
        <asp:BoundField DataField="LastName" ReadOnly="true" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-Width="150" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
        <asp:BoundField DataField="Title" ReadOnly="true" HeaderText="Title" SortExpression="Title" HeaderStyle-Width="150" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />
        <asp:BoundField DataField="RateGroupName" ReadOnly="true" HeaderText="Billing Rate Group" SortExpression="RateGroupName" HeaderStyle-Width="150" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" />            
    </Columns>
</asp:GridView>
<br />



</asp:Content>
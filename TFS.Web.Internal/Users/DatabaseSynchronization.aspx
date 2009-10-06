<%@ Page MasterPageFile="~/default.master" MaintainScrollPositionOnPostback="true" Language="C#" AutoEventWireup="true" CodeBehind="DatabaseSynchronization.aspx.cs" Inherits="TFS.Web.Users.DatabaseSynchronization" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
         
    <h1>Current Staff</h1> 
    
    <p>All users should have accurate information entered for all fields. This is very important.</p>
    
    <p>
        <asp:Button ID="SyncAllButton" runat="server" Text="Sync All Users" OnClick="HandleSyncAllButtonClick" />
    </p>
    
    <asp:GridView ID="PersonsGridView" runat="server" 
       BackColor="White" 
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" 
        AutoGenerateColumns="False"
        DataKeyNames="Username" AllowSorting="false" OnRowCommand="HandleRowCommand"
        >
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <Columns>            
            <asp:BoundField HeaderText="Username" DataField="Username" SortExpression="Username" />
            <asp:BoundField HeaderText="Last Name" DataField="LastName" SortExpression="LastName" />
            <asp:BoundField HeaderText="First Name" DataField="FirstName" SortExpression="FirstName" />
            <asp:BoundField HeaderText="Title" DataField="Title" SortExpression="Title" />
            <asp:BoundField HeaderText="E-mail" DataField="Email" SortExpression="Email" />    
            <asp:CheckBoxField HeaderText="Synced" DataField="HasDatabaseEntity" SortExpression="HasDatabaseEntity" />
            <asp:TemplateField HeaderText="Username" SortExpression="Username">
                <ItemTemplate>
                    <asp:LinkButton ID="SyncButton" runat="server" 
                                    Text="Sync to Database" 
                                    CommandName="Sync"
                                    CommandArgument='<%# Eval("Username") %>'
                                    Enabled='<%# !(bool)Eval("HasDatabaseEntity") %>'>
                                    </asp:LinkButton>                                       
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>        
    </asp:GridView>                 

</asp:Content>
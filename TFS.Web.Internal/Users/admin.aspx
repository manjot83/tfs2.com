<%@ Page MasterPageFile="~/default.master" MaintainScrollPositionOnPostback="true" Language="C#" AutoEventWireup="true" Inherits="_Default" Codebehind="admin.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
         
    <h1>Current Staff</h1> 
      
    
    <p>    
        <b>IT AdminLinks...</b><br />
        <a href="../Forms/PersonnelFileAdmin.aspx">Manage Personnel Files</a><br />        
        <a href="DatabaseSynchronization.aspx">User Database Synchronization</a>
    </p>
    
    <asp:ListView ID="PersonsListView" runat="server" OnItemCommand="HandleOnPersonListViewItemCommand">
        <LayoutTemplate>
            <table class="list-table" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th>username</th>
                        <th>name</th>
                        <th>e-mail</th>
                        <th>actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr runat="server" id="itemPlaceholder" />
                </tbody>            
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="username" runat="server" text='<%# Eval("Username") %>'></asp:Literal></td>
                <td><%# Eval("Displayname") %></td>
                <td><a href='mailto:<%# Eval("Email") %>'><%# Eval("Email") %></a></td>
                <td class="options">                
                    <asp:HyperLink ID="ImageButton1" runat="server" NavigateUrl='<%# "~/Forms/PersonnelFile.aspx?name="+Eval("Username").ToString() %>' ImageUrl="~/icons/user-comment-red.gif" AlternateText="Edit User Information" ToolTip="Edit User Information" />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Forms/PersonnelFileReport.aspx?name="+Eval("Username").ToString() %>' ImageUrl="~/icons/report_go.png" AlternateText="View User Report" ToolTip="View User Report" />
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Forms/PersonnelFilePrintReport.aspx?name="+Eval("Username").ToString() %>' ImageUrl="~/icons/printer-red.gif" AlternateText="Printable User Report" ToolTip="Printable User Report" Target="_blank" />
                    <asp:ImageButton ID="deleteuser" runat="server" CommandName="Cmd1" ImageUrl="~/icons/remove-user-red.gif" AlternateText="Remove User" OnClientClick="return confirm('Are you sure you want to delete this user?')" ToolTip="Remove User" Visible="false" />                    
                    <asp:HyperLink ID="resetpasswordlink" ImageUrl="~/icons/check-user-red.gif" runat="server" NavigateUrl='<%# "~/users/ResetPassword.aspx?username="+Eval("Username").ToString() %>' ToolTip="Reset Password" Visible="false"></asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>                       

</asp:Content>
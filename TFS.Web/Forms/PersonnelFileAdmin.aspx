<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" CodeBehind="PersonnelFileAdmin.aspx.cs" Inherits="TFS.Web.Forms.PersonnelFileAdmin"
Title="TFS - Personnel File"
 %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<asp:ListView ID="FileListView" runat="server">
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
                <asp:ImageButton ID="deleteuser" runat="server" CommandName="Cmd1" ImageUrl="~/images/remove-user-red.gif" AlternateText="Remove User" OnClientClick="return confirm('Are you sure you want to delete this user?')" ToolTip="Remove User" />
                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Cmd2" ImageUrl="~/images/user-comment-red.gif" AlternateText="Modify User Information" ToolTip="Modify User Information" />
                <asp:HyperLink ID="resetpasswordlink" ImageUrl="~/images/check-user-red.gif" runat="server" NavigateUrl='<%# "~/users/ResetPassword.aspx?username="+Eval("Username").ToString() %>' Visible="true" ToolTip="Reset Password"></asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>         

</asp:Content>
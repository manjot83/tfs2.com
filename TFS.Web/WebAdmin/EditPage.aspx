<%@ Page MasterPageFile="~/default.master" Title="Edit Static Web Page" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="admin_EditStaticContent" Codebehind="EditPage.aspx.cs" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        
            <p><span style="font-weight:bold;">Page Editing Instructions</span></p>
            <ul>
                <li>The URI for the page needs to be a unique word. This is used to identify the page.</li>
                <li>The Title is what is displayed in the address bar for the webpage.</li>
                <li>You can enter text or HTML for the banner.</li>
                <li>You can select images for the optional image strip along the left hand side.</li>
                <li>The body text is written using Markdown. Write the text as if you were writing an E-Mail.   </li>
            </ul>
        
            <h1>Edit A Page</h1>
            
            <table>
            
            <tr>
                <td style="width:10%;">
                    <asp:Label ID="Label4" CssClass="property_label" runat="server" Text="Page URL"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="uri" CssClass="property_input" Width="100px" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td>
                    <asp:CheckBox ID="active" runat="server" Text="Active Page" Checked="true" ToolTip="This Link Will Render When Accessed" /><br />
                    <asp:CheckBox ID="isLink" runat="server" Text="Has A Link" Checked="true" ToolTip="A Link Appears In The Nav Menu For This Page" />
                    
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label7" CssClass="property_label" runat="server" Text="Page Header"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="pageHeader" CssClass="property_input" Width="150px" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="property_label" runat="server" Text="Link Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="linktitle" CssClass="property_input" Width="150px" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="property_label" runat="server" Text="Page Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="title" CssClass="property_input" Width="450px" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="property_label" runat="server" Text="Page Banner"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="banner" CssClass="property_input" Width="450px" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
                <tr>
                <td valign="top">
                    <asp:Label ID="Label6" CssClass="property_label" runat="server" Text="Image Strip"></asp:Label>       
                </td>
                <td>
                    <asp:TextBox ID="imagestrip" CssClass="property_input" runat="server" Height="50px" Width="450px" TextMode="MultiLine"></asp:TextBox>
                </td>               
            </tr>
            
            <tr>
                <td valign="top">
                    <asp:Label ID="Label3" CssClass="property_label" runat="server" Text="Page Body"></asp:Label>       
                </td>
                <td>
                    <asp:TextBox ID="markdown" CssClass="property_input" runat="server" Height="300px" Width="95%" TextMode="MultiLine"></asp:TextBox>
                </td>               
            </tr>

            
            <tr>
            <td></td>
            <td>
                <asp:Button ID="UpdateButton" runat="server"  Text="Update" OnClick="UpdateButton_Click" />
                <asp:Button ID="ResetButton" runat="server"  Text="Reset" OnClick="ResetButton_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
            </td>
            </tr>
            
            </table>
    </asp:Content>
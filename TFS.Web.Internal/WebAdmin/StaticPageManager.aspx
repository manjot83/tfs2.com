<%@ Page MasterPageFile="~/default.master" Title="Manage Static Web Pages" Language="C#"
    AutoEventWireup="true" Inherits="StaticPageManager" CodeBehind="StaticPageManager.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="PagesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:WebsiteConnString %>"
        SelectCommand="select StaticContent.[uri], [title], [isLink], [active], [AttributeValue] as LinkPosition from StaticContent inner join StaticContentAttributes ON [StaticContent].uri = StaticContentAttributes.uri WHERE StaticContentAttributes.attributetype = 'linkposition' ORDER BY ( CONVERT ( char, StaticContentAttributes.AttributeValue))">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ImagesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:WebsiteConnString %>"
        SelectCommand="SELECT [ID], [ContentType], [Description] FROM Images"></asp:SqlDataSource>
    <!-- some hidden params (hacks) -->
    <asp:HiddenField ID="image_id_to_delete" runat="server" />
    <div>
        <p>
            You can use this interface to edit the static content displayed on the public website.
            <br />
            <br />
            Things to Remember:</p>
        <ul>
            <li>The pages are displayed in the order which they would appear in the Navigation Link
                bar on the website.</li>
            <li>Disabled Links are highlighted as such and do not appear on the Navigation Link
                bar on the website.</li>
        </ul>
        <h1>
            Static Pages</h1>
        <table width="90%">
            <tr>
                <td>
                    <span style="font-weight: bold;">Title</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Page URI</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Move Up</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Move Down</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Edit Page</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Delete Page</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Active Page</span>
                </td>
            </tr>
            <asp:Repeater ID="PagesRepeater" runat="server" DataSourceID="PagesDataSource">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("title") %>
                        </td>
                        <td>
                            <asp:Label ID="urilabel" runat="server" Text='<%# Eval("uri") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton Enabled="false" ID="moveUpButton" runat="server" CommandArgument='<%# Eval("uri") + " " + Eval("LinkPosition") %>'
                                Text="Up" OnClick="upbutton_Click" />
                        </td>
                        <td>
                            <asp:LinkButton Enabled="False" ID="moveDownButton" runat="server" CommandArgument='<%# Eval("uri") + " " + Eval("LinkPosition")  %>'
                                Text="Down" OnClick="downbutton_Click" />
                        </td>
                        <td>
                            <asp:HyperLink ID="editImageLink" runat="server" Text="Edit" NavigateUrl='<%# "~/WebAdmin/EditPage.aspx?id="+Eval("uri") %>'></asp:HyperLink>
                        </td>
                        <td>
                            <asp:LinkButton Enabled="False" ID="PagesDeleteButton" runat="server" Text="Delete"
                                OnClick="deletepage_Click" CommandArgument='<%# Eval("uri") %>' OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:CheckBox Enabled="false" ID="ActiveCheckbox" runat="server" Checked='<%# Eval("active") %>'
                                ToolTip="Toggle the page active or 'hidden'" AutoPostBack="true" OnCheckedChanged="ActiveCheck_Toggle" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <asp:Button ID="addapage" runat="server" Text="Add New Page" OnClick="addapage_Click"
            Enabled="false" />
        <asp:Button ID="homebutton" runat="server" Text="Public Website Home" OnClick="homebutton_Click" />
        <h1>
            Files</h1>
        <asp:Button ID="uploadFileButton" runat="server" Text="Upload A File" OnClick="addapage_Click"
            Enabled="false" />
        <h1>
            Images</h1>
        <table width="90%">
            <tr>
                <td>
                    <span style="font-weight: bold;">Image ID</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Image Desc</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Thumbnail</span>
                </td>
                <td>
                    <span style="font-weight: bold;">Delete</span>
                </td>
                <td>
                    <span style="font-weight: bold;">View Normal</span>
                </td>
                <td>
                    <span style="font-weight: bold;">View Medium</span>
                </td>
                <td>
                    <span style="font-weight: bold;">View Small</span>
                </td>
            </tr>
            <asp:Repeater ID="ImagesRepeater" runat="server" DataSourceID="ImagesDataSource">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("Description") %>
                        </td>
                        <td>
                            <asp:Image ID="thumbnailimage" ImageUrl='<%# "~/images/imageview.aspx?id="+Eval("ID")+"&size=1" %>'
                                runat="server" />
                        </td>
                        <td>
                            <asp:LinkButton ID="ImageDeleteButton" runat="server" Text="Delete" OnClick="deleteimage_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure you want to delete?');"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:HyperLink ID="BigImageLink" runat="server" Text="Normal Size" NavigateUrl='<%# "~/images/imageview.aspx?id="+Eval("ID")+"&size=3" %>'></asp:HyperLink>
                        </td>
                        <td>
                            <asp:HyperLink ID="MediumImageLink" runat="server" Text="Medium Size" NavigateUrl='<%# "~/images/imageview.aspx?id="+Eval("ID")+"&size=2" %>'></asp:HyperLink>
                        </td>
                        <td>
                            <asp:HyperLink ID="SmallImageLink" runat="server" Text="Small Size" NavigateUrl='<%# "~/images/imageview.aspx?id="+Eval("ID")+"&size=1" %>'></asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Button ID="uploadImageButton" runat="server" Text="Upload An Image" OnClick="addimage_Click" />
    </div>
</asp:Content>

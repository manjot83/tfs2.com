<%@ Page MasterPageFile="~/default.master" Title="New Post" ValidateRequest="false" Language="C#" AutoEventWireup="true" Inherits="news_admin_newpost" Codebehind="newpost.aspx.cs" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource
        ID="NewsDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.NewspostController"
        InsertMethod="Insert"
        OnInserted="ObjDS_OnInserted">
        <InsertParameters>
            <asp:ControlParameter ControlID="createdby" Name="personName" PropertyName="value" Type="String" /> 
            <asp:Parameter Name="isurgent" DefaultValue="false" Type="Boolean" />
        </InsertParameters>
    </asp:ObjectDataSource>  
    
    <asp:ObjectDataSource
        ID="CategoryDataSource" 
        runat="server" 
        TypeName="TFS.OpCenter.Data.ArticlecategoryController"
        SelectMethod="FetchAll">
    </asp:ObjectDataSource>
    
    <asp:HiddenField ID="createdby" runat="server" />
        
    <asp:FormView ID="NewPostForm" runat="server" DataSourceID="NewsDataSource" DefaultMode="Insert" Width="600px" OnItemInserted="Item_Inserted" OnItemInserting="Item_Inserting">
        <InsertItemTemplate>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label1" Text="Date" /></div>
                <div class="right"><asp:TextBox ID="postdate" runat="server" Text='<%# Bind("createdon", "{0}") %>' Width="300" /></div>
            <p>
            </p>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label2" Text="Category" /></div>
                <div class="right">
                    <asp:DropDownList ID="CategorySelectBox" runat="server" Width="306"
                        DataSourceID="CategoryDataSource" 
                        DataTextField="name" 
                        DataValueField="id" 
                        SelectedValue='<%# Bind("categoryid") %>'>
                    </asp:DropDownList>                        
                </div>
            <p>
            </p>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label3" Text="Subject" /></div>
                <div class="right"><asp:TextBox ID="subject" runat="server" Text='<%# Bind("subject", "{0}") %>' Width="300" /></div>
            <p>
            </p>
            <p>
            </p>
                <div class="left"><asp:Label runat="server" ID="label4" Text="Content (Markdown)" /></div>
                <div class="right"><asp:TextBox ID="content" runat="server" Text='<%# Bind("content", "{0}") %>' TextMode="MultiLine" Width="500" Height="300" /></div>
            <p>
            </p>
            <asp:Button CommandName="Insert" ID="AddPostButton" runat="server" Text="Add Post" />
            <asp:Button OnClick="Reset" ID="ResetButton" runat="server" Text="Reset" />
        </InsertItemTemplate>
    </asp:FormView>
        
  </asp:Content>
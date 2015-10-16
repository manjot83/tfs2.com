<%@ Control Language="C#" AutoEventWireup="true" Inherits="User_Controls_Sidebar" CodeBehind="Sidebar.ascx.cs" EnableViewState="false" %>
<%@ Import Namespace="System.Activities.Statements" %>

<div id="side-bar">
    <div>
        <p class="sideBarTitle">Internal Links</p>
        <ul>
            <li>
                <asp:HyperLink ID="Link1" runat="server" NavigateUrl="~">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/icons/house_go.png" ImageAlign="Middle" />
                    &nbsp;
                Intranet Home
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="https://mail.google.com" Target="_blank">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/icons/email_go.png" ImageAlign="Middle" />
                    &nbsp;
                Email
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink runat="server" NavigateUrl="~/FlightLogs">
                <asp:Image  runat="server" ImageUrl="~/icons/transmit_go.png" ImageAlign="Middle" />
                &nbsp;
                Flight logs
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Forms/SRFListing.aspx">
                    <asp:Image ID="Image17" runat="server" ImageUrl="~/icons/shield_go.png" ImageAlign="Middle" />
                    &nbsp;
                SRF
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Forms/FCIFListing.aspx">
                    <asp:Image ID="Image18" runat="server" ImageUrl="~/icons/cog_go.png" ImageAlign="Middle" />
                    &nbsp;
                FCIF
                </asp:HyperLink>
            </li>
            <li>
                <% if (HttpContext.Current.User.IsInRole("UserManager"))
                   { %>
                <a href="https://us3.hostedftp.com/files/path/" target="_blank">
                    <img src="/icons/folder_go.png" alt="TFS Publications" />
                    TFS Publications
                </a>
                <% }
                   else
                   { %>
                <a href="ftp://tfs:SilverTire15@tfs.hostedftp.com" target="_blank">
                    <img src="/icons/folder_go.png" alt="TFS Publications" />
                    TFS Publications
                </a>
                <% } %>
            </li>
            <%--     <li>
             <a href="/DocumentManager/CorporateDocs.aspx">
                 <img src="/icons/folder_go.png" alt="TFS Publications"/>
                 TFS Publications
             </a>
        </li>--%>
        </ul>
    </div>
    <div>
        <p class="sideBarTitle">Self Service</p>
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Security/ChangePassword">
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/icons/lock_go.png" ImageAlign="Middle" />
                    &nbsp;
                Change My Password
                </asp:HyperLink>
            </li>

            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PersonnelRecords/EditMyRecord">
                    <asp:Image ID="Image16" runat="server" ImageUrl="~/icons/table_go.png" ImageAlign="Middle" />
                    &nbsp;
                My Personnel File
                </asp:HyperLink>
            </li>

            <li>
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Billing/default.aspx">
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/icons/time_go.png" ImageAlign="Middle" />
                    &nbsp;
                My Timecards
                </asp:HyperLink>
            </li>
            <li style="display: none;">
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Scheduling/Availability.aspx">
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/icons/date_go.png" ImageAlign="Middle" />
                    &nbsp;
                My Availability
                </asp:HyperLink>
            </li>
        </ul>
    </div>
    <div>
        <p class="sideBarTitle">Management Links</p>
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Users">
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/icons/user_go.png" ImageAlign="Middle" />
                    &nbsp;
                Users and Security
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Billing/Admin/default.aspx">
                    <asp:Image ID="Image12" runat="server" ImageUrl="~/icons/book_go.png" ImageAlign="Middle" />
                    &nbsp;
                Payroll Admin
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink runat="server" NavigateUrl="~/PersonnelRecords/List">
                <asp:Image  runat="server" ImageUrl="~/icons/user_go.png" ImageAlign="Middle" />
                &nbsp;
                Personnel Files
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink runat="server" NavigateUrl="~/FlightPrograms/Manage">
                <asp:Image  runat="server" ImageUrl="~/Static/images/icons/flightprograms.png" ImageAlign="Middle" />
                &nbsp;
                Flight Programs
                </asp:HyperLink>
            </li>
            <li style="display: none;">
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Scheduling/AvailabilityReport.aspx">
                    <asp:Image ID="Image14" runat="server" ImageUrl="~/icons/world_go.png" ImageAlign="Middle" />
                    &nbsp;
                Master Availability
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Forms/admin.aspx">
                    <asp:Image ID="Image19" runat="server" ImageUrl="~/icons/application_go.png" ImageAlign="Middle" />
                    &nbsp;
                Forms Admin
                </asp:HyperLink>
            </li>
        </ul>
    </div>
    <div class="lighterBackground">
        <p class="sideBarTitle">External Links</p>
        <span class="sideBarText">
            <asp:HyperLink ID="ManageLinksLink" runat="server" NavigateUrl="~/LinkAdmin/Default.aspx" Text="Manage Links" />
        </span>
        <span class="sideBarText">
            <asp:Repeater ID="LinkRepeater" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <a href='<%# Eval("navurl") %>' title='<%# Eval("name") %>' target="_blank">&rsaquo; 
            <%# Eval("name") %></a><br />
                </ItemTemplate>
            </asp:Repeater>
        </span>
    </div>



</div>

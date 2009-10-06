<%@ Page MasterPageFile="~/default.master" Language="C#" AutoEventWireup="true" Codebehind="AvailabilityReport.aspx.cs"
    Inherits="TFS.Intranet.Web.Scheduling.AvailabilityReport" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="manager1" runat="server">
    </asp:ScriptManager>
    
    <div style="text-align: center;">
        <h3>
            Select Month</h3>
        <p>
            <asp:DropDownList ID="MonthDropDown" runat="server">
                <asp:ListItem Text="January" Value="1" Selected="true"></asp:ListItem>
                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                <asp:ListItem Text="December" Value="12"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="YearDropDown" runat="Server">
                <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                <asp:ListItem Text="2008" Value="2008" Selected="true"></asp:ListItem>
                <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="SelectMonthButton" runat="server" Text="Select Month"></asp:LinkButton>
        </p>
    </div>
    
    <a class="topOfPage" href="#top" title="Go to the top of this page">^ TOP</a>
    <h1 id="H1_2">
        User Availability
        <asp:Label ID="CurrentUserLabel" runat="server"></asp:Label></h1>
    
    <asp:UpdatePanel ID="CalendarUpdatePanel" runat="server">
        <ContentTemplate>
            <center>
                <h2>
                    <asp:Label ID="MonthLabel" runat="server"></asp:Label></h2>
            </center>
            <p>
                <tfs:AvailabilityReport ID="AvailCalendar" runat="server" Width="100%" />
            </p>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="SelectMonthButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>

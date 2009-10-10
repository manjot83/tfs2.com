<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    SitePage
</asp:Content>

<asp:Content ContentPlaceHolderID="AdditionalStyleSheets" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="AdditionalJavascript" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
     <img src="../../Content/public/template/header03.jpg" alt="" />  
</asp:Content>

<asp:Content ContentPlaceHolderID="NavContent" runat="server">
    <a href="home.page" class="rollover_1"></a>
    <a href="services.page" class="rollover_2"></a>
    <a href="programs.page" class="rollover_3"></a>
    <a href="experience.page" class="rollover_4"></a>
    <a href="login.html" class="rollover_5"></a>
    <a href="contact.page" class="rollover_6"></a>
</asp:Content>

<asp:Content ContentPlaceHolderID="BannerContent" runat="server">
    <img src="../../Content/public/banners/Welcome.gif" alt="Banner" /> 
</asp:Content>

<asp:Content ContentPlaceHolderID="ImageStripContent" runat="server">
    <asp:Literal ID="ImageStrip" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="BodyContent" runat="server">
    <h3>Global Aircrew and Training Solutions</h3>
    <p>
        Tactical Flight Services, Inc. is a global provider of specialized aircrew and training
        services. Founded in 2002, TFS was borne out of many years of military and aerospace
        industry experience.
    </p>
    <p>
        The Objective: Provide the highest qualified aircrew and engineers to meet mission
        critical customer flight test and training needs. Top priority is placed on safety,
        short notice schedule flexibility, and excellence in mission execution.</p>
    <p>
        TFS is headquartered at McCollum Airport in Kennesaw, Georgia just north of Dobbins
        Air Reserve Base.
    </p>
    <h3>Tactical News</h3>
    <ul>
        <li>
            <p>
                TFS will be at the 2009 Hercules Operators Conference October 19-22. Please stop
                by our booth for more information on how we can provide your team with solutions.</p>
        </li>
        <li>
            <p>
                TFS is proud to have completed avionics and functional flight test on the first
                Polish C-130E. The aircraft was delivered to Powdiz Air Base in Poland on 24 March
                2009. This is the first of five total aircraft to be flight tested by TFS.
            </p>
        </li>
    </ul>
    <p>
        <a href="http://www.aviationweek.com/aw/blogs/defense/index.jsp?plckController=Blog&amp;plckScript=blogScript&amp;plckElementId=blogDest&amp;plckBlogPage=BlogViewPost&amp;plckPostId=Blog%3a27ec4a53-dcc8-42d0-bd3a-01329aef79a7Post%3ab414c21c-c998-4560-9c24-119f56160373&amp;plckCommentSortOrder=TimeStampAscending">
            Aviation Week Article</a></p>
    <p>
        <a href="http://www.TFS2.com/Brochure/Brochure_TFS_II.pdf">Download TFS Brochure</a></p>
</asp:Content>

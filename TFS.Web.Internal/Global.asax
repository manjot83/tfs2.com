<%@ Application Language="C#" %>

<script runat="server">

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        /// Dispatch this code to our membership provider who will process the roles for the current user
        (Membership.Provider as TFS.Security.TFSMembershipProvider).ProcessRoles(HttpContext.Current.User);
    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
#if !DEBUG
        Server.Transfer("~/error.aspx");
#endif        
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

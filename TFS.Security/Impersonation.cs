using System;
using System.Data;
using System.Configuration;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace TFS.Security
{
    public class Impersonation
    {

        WindowsImpersonationContext ctx;

        public Boolean Impersonated { get; private set; }

        public Boolean ImpersonateWithToken(IntPtr token)
        {
            if (Impersonated)
                return true; ;
            WindowsIdentity newId = new WindowsIdentity(token);
            ctx = newId.Impersonate();
            Impersonated = true;
            return true;
        }

        public Boolean ImpersonateWithProtocolTransition(String username)
        {
            if (Impersonated)
                return true; ;
            WindowsIdentity newID = new WindowsIdentity(username);
            ctx = newID.Impersonate();
            Impersonated = true;
            return true;
        }


        public Boolean UnImpersonate()
        {
            if (!Impersonated)
                return true;
            ctx.Undo();
            ctx.Dispose();
            Impersonated = false;
            return true;
        }


    }
}

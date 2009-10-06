using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class NavLink
{

    protected String url;

    protected String name;

    protected String cssclass;

    protected int position;

    public String URL
    {
        get
        {
            return url;
        }
        set
        {
            url = value;
        }
    }

    public String CssClass
    {
        get
        {
            return cssclass;
        }
        set
        {
            cssclass = value;
        }
    }

    public String Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

   public int Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }


	public NavLink(String url, String name, int position)
	{
        this.name = name;
        this.url = url;
        this.position = position;
	}

    public NavLink(String url, String name, int position, String cssclass)
    {
        this.name = name;
        this.url = url;
        this.cssclass = cssclass;
        this.position = position;
    }
}

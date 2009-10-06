using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using anrControls;
using System.Collections;

namespace TFS.CMS
{

    public class StaticContent
    {
        private Hashtable attributes;

        public enum AttributeType
        {
            markdown, linktitle, banner, imagestrip, linkposition, pageheader
        }

        protected Markdown markdown;

        protected String uri;

        public String URI
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }

        protected String title;

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                this.title = value;
            }
        }


        public String LinkTitle
        {
            get
            {
                return getAttribute(AttributeType.linktitle);
            }
            set
            {
                setAttribute(AttributeType.linktitle, value);
            }
        }

        public String Banner
        {
            get
            {
                return getAttribute(AttributeType.banner);
            }
            set
            {
                setAttribute(AttributeType.banner, value);
            }
        }

        public String ImageStrip
        {
            get
            {
                return getAttribute(AttributeType.imagestrip);
            }
            set
            {
                setAttribute(AttributeType.imagestrip, value);
            }

        }

        public String Markdown
        {
            get
            {
                return getAttribute(AttributeType.markdown);
            }
            set
            {
                setAttribute(AttributeType.markdown, value);
            }
        }

        public String Body
        {
            get
            {
                if (markdown == null)
                    markdown = new Markdown();
                return markdown.Transform(Markdown);
            }
        }

        public String PageHeader
        {
            get { return getAttribute(AttributeType.pageheader); }
            set { setAttribute(AttributeType.pageheader, value); }
        }
	

        //management

        protected Boolean isLink = true;

        public Boolean IsLink
        {
            get
            {
                return isLink;
            }
            set
            {
                isLink = value;
            }
        }

        protected Boolean active = true;

        public Boolean Active
        {
            get
            {
                return active;
            }
            set
            {
                this.active = value;
            }
        }


        public int Position
        {
            get
            {
                return Int32.Parse(getAttribute(AttributeType.linkposition));
            }
            set
            {
                setAttribute(AttributeType.linktitle, value.ToString());
            }
        }

        public StaticContent()
        {
            if (markdown == null)
                markdown = new Markdown();

            attributes = new Hashtable();
        }

        public StaticContent(String uri, String title, Boolean isLink, Boolean isActive, DataTable attributeTable)
        {

        }


        public String getAttribute(AttributeType type)
        {
            return getAttribute(type.ToString());
        }

        public String getAttribute(String type)
        {
            if (attributes.Contains(type))
                return attributes[type].ToString();
            else
                return "";
        }

        public void setAttribute(AttributeType type, String value)
        {
            setAttribute(type.ToString(), value);
        }

        public void setAttribute(String type, String value)
        {
            if (attributes.Contains(type))
            {
                attributes.Remove(type);
                attributes.Add(type, value);
            }
            else
                attributes.Add(type, value);
        }
    }
}
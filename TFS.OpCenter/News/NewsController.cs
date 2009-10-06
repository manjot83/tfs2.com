using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.News
{
    public class NewsController
    {

        public Newspost SelectedNewsPost { get; private set; }

        public void SelectNewsPost(int id)
        {
            this.SelectedNewsPost = Newspost.FetchByID(id);
        }

        public void UpdateIsUrgent(bool isUrgent)
        {
            if (this.SelectedNewsPost != null)
            {
                this.SelectedNewsPost.Isurgent = isUrgent;
                this.SelectedNewsPost.Save();
            }
        }

        
    }
}

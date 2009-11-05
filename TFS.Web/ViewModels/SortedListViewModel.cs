using System.Collections.Generic;
using System.Web.UI.WebControls;
using Centro.Extensions;

namespace TFS.Web.ViewModels
{
    public class SortedListViewModel<TItemType>
    {
        public IEnumerable<TItemType> Items { get; set; }

        public string SortType { get; set; }
        public SortDirection SortDirection { get; set; }

        public bool PagingEnabled { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ViewableItems { get; set; }
        public int TotalItems { get; set; }

        public SortDirection GetReverseSortDirection()
        {
            switch (SortDirection)
            {
                case SortDirection.Ascending:
                    return SortDirection.Descending;
                default:
                    return SortDirection.Ascending;
            }
        }

        public bool IsCurrentSortType(string sortType)
        {
            return SortType.Matches(sortType);
        }

        public bool IsSortedAscending()
        {
            return SortDirection == SortDirection.Ascending;
        }

        public string SortDirectionClass(string ascendingClass, string descendingClass)
        {
            return IsSortedAscending() ? ascendingClass : descendingClass;
        }
    }
}

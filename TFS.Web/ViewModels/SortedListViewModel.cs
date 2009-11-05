using System.Collections.Generic;
using System.Web.UI.WebControls;
using Centro.Extensions;

namespace TFS.Web.ViewModels
{
    public class SortedListViewModel<TItemType>
    {
        public const int DefaultItemsPerPage = 20;

        public IEnumerable<TItemType> Items { get; set; }

        public string SortType { get; set; }
        public SortDirection SortDirection { get; set; }

        public bool PagingEnabled { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                if (TotalItems <= 0 || ItemsPerPage <= 0)
                    return 1;
                return (TotalItems / ItemsPerPage) + 1;
            }
        }
        public int ItemsPerPage { get; set; }
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

        public bool HasPreviousPage()
        {
            return PagingEnabled && CurrentPage > 1;
        }

        public bool HasNextPage()
        {
            return PagingEnabled && CurrentPage < TotalPages;
        }

        public int PreviousPage()
        {
            return CurrentPage - 1;
        }

        public int NextPage()
        {
            return CurrentPage + 1;
        }
    }
}

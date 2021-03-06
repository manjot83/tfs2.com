﻿using System.Collections.Generic;
using System.Web.UI.WebControls;
using TFS.Extensions;
using System.Linq;

namespace TFS.Web.ViewModels
{
    public class SortedListViewModel<TItemType>
    {
        public const int DefaultItemsPerPage = 20;

        public IEnumerable<TItemType> Items { get; set; }

        public bool ShowAll { get; set; }

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
                if (TotalItems % ItemsPerPage == 0)
                    return TotalItems / ItemsPerPage;
                else
                    return (TotalItems / ItemsPerPage) + 1;
            }
        }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public void SetItems(IEnumerable<TItemType> items)
        {
            TotalItems = items.Count();
            if (ItemsPerPage == 0)
                ItemsPerPage = TotalItems;
            Items = items.Skip(ItemsPerPage * (CurrentPage - 1)).Take(ItemsPerPage).ToList();            
        }

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

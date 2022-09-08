using System;
using System.Collections.Generic;

namespace Products.Application.Common
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        private PagedList(IList<T> items, int totalItems, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)(pageSize));
            AddRange(items);
        }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public static PagedList<T> Create(IList<T> pagedItems, int unpagedItemCount, int pageNumber, int pageSize)
        {
            if (pagedItems == null)
                return null;

            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), $"{nameof(pageNumber)} must be greater than 0");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), $"{nameof(pageSize)} must be greater than 0");

            return new PagedList<T>(pagedItems, unpagedItemCount, pageNumber, pageSize);
        }
    }
}

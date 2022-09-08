using System.Collections.Generic;

namespace Products.Application.Common
{
    public interface IPagedList<T> : IEnumerable<T>
    {
        int CurrentPage { get; }
        int TotalPages { get; }
        int TotalItems { get; }
        int PageSize { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}

using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.Models.PagedViewModel
{
    public class Converter<T> : ITypeConverter<IPagedList<T>, PagedViewModel<T>>
    {
        public PagedViewModel<T> Convert(IPagedList<T> source, PagedViewModel<T> destination, ResolutionContext context)
        {
            return new PagedViewModel<T>()
            {
                FirstItemOnPage = source.FirstItemOnPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                IsFirstPage = source.IsFirstPage,
                IsLastPage = source.IsLastPage,
                LastItemOnPage = source.LastItemOnPage,
                PageCount = source.PageCount,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalItemCount = source.TotalItemCount,
                rows = source
            };
        }
    }
}
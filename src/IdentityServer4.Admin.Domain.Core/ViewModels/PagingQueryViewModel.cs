using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Domain.Core.ViewModels
{
    public class PagingQueryViewModel
    {
        public PagingQueryViewModel(int pageIndex, int pageSize, string search)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Search = search;
        }

        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; } = 1;
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
        public string Search { get; set; }

        public int Skip => (PageIndex - 1) * PageSize;
    }
}

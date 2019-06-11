using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Core.ViewModels
{
    public class PagingDataViewModel<T>
    {
        public long Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}

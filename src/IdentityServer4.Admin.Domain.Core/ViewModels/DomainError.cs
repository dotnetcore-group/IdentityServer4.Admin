using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Core.ViewModels
{
    public class DomainError
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class DomainErrorEqualityComparer : IEqualityComparer<DomainError>
    {
        public bool Equals(DomainError x, DomainError y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x?.Code == y?.Code;
        }

        public int GetHashCode(DomainError obj)
        {
            return obj?.ToString().GetHashCode() ?? 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityServer4.Admin.Domain.Models
{
    public class HashType : Enumeration
    {
        public static HashType Sha256 => new HashType(0, nameof(Sha256));
        public static HashType Sha512 => new HashType(1, nameof(Sha512));

        public static List<HashType> List() => new List<HashType> { Sha256, Sha512 };

        public HashType(int id, string name) : base(id, name)
        {
        }

        public static HashType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for OrderStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

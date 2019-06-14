using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Domain.Entities
{
    public class Startup
    {
        [Key]
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool Initialized { get; set; }
        public DateTime? InitializedDate { get; set; }
    }
}

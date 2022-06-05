using System;
using System.Collections.Generic;

namespace myproject.Models
{
    public partial class Country
    {
        public Country()
        {
            Populations = new HashSet<Population>();
        }

        public string Country1 { get; set; } = null!;
        public string Ccode { get; set; } = null!;
        public string Iso3 { get; set; } = null!;

        public virtual ICollection<Population> Populations { get; set; }
    }
}

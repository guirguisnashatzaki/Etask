using System;
using System.Collections.Generic;

namespace myproject.Models
{
    public partial class Population
    {
        public int Myyear { get; set; }
        public long Myvalue { get; set; }
        public string Country { get; set; } = null!;

        public virtual Country CountryNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class State
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public int? IdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? IdCountryNavigation { get; set; }
}

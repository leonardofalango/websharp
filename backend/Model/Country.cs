using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Country
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<State> States { get; set; } = new List<State>();
}

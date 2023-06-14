using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class City
{
    public int Id { get; set; }

    public string CityName { get; set; } = null!;

    public int? IdState { get; set; }

    public virtual State? IdStateNavigation { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}

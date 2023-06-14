using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? IdCity { get; set; }
    public DateTime? NewsDate { get; set; } = null!; 

    public virtual City? IdCityNavigation { get; set; }

    public virtual ICollection<TopicsXnews> TopicsXnews { get; set; } = new List<TopicsXnews>();
}

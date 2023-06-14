using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Topic
{
    public int Id { get; set; }

    public string TopicName { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual ICollection<TopicsXnews> TopicsXnews { get; set; } = new List<TopicsXnews>();
}

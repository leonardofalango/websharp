using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class TopicsXnews
{
    public int Id { get; set; }

    public int? IdTopic { get; set; }

    public int? IdNews { get; set; }

    public virtual News? IdNewsNavigation { get; set; }

    public virtual Topic? IdTopicNavigation { get; set; }
}

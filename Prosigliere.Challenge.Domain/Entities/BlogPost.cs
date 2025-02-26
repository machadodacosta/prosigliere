﻿using System.Xml.Linq;

namespace Prosigliere.Challenge.Domain.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

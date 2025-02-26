﻿namespace Prosigliere.Challenge.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
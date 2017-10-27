﻿using System;

namespace VTube.Core.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
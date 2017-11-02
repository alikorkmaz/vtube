using System;

namespace VTube.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Video Video { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int VideoId { get; set; }
        public string UserId { get; set; }
    }
}
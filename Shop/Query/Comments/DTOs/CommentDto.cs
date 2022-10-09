using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Domain.CommentAgg.Enums;

namespace Query.Comments.DTOs
{
    public class CommentDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

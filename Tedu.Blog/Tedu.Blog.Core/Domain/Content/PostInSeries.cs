using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tedu.Blog.Core.Domain;

[Table("PostInSeries")]
[PrimaryKey(nameof(PostId), nameof(SeriesId))]
public class PostInSeries
{
    public Guid PostId { get; set; }
    public Guid SeriesId { get; set; }
    public int DisplayOrder { get; set; }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Enums;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Content;

[Table("Slides")]
public class Slide : DomainEntity<Guid>, ISwitchable, ISortable
{
    public Slide()
    {
    }

    public Slide(Guid id, string name, string description,
        string image, string url, int sortOrder, Status status,
        string content, SlideGroup group)
    {
        Id = id;
        Name = name;
        Description = description;
        Image = image;
        Url = url;
        SortOrder = sortOrder;
        Status = status;
        Content = content;
        GroupAlias = group;
    }

    [StringLength(250)]
    [Required]
    public string Name { set; get; }

    [StringLength(250)]
    public string Description { set; get; }

    [StringLength(250)]
    [Required]
    public string Image { set; get; }

    [StringLength(250)]
    public string Url { set; get; }

    public int? DisplayOrder { set; get; }

    public string Content { set; get; }

    [Required]
    public SlideGroup GroupAlias { get; set; }

    public int SortOrder { set; get; }
    public Status Status { set; get; }
}
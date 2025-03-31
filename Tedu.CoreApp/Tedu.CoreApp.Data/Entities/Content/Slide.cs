using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

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
    public string? Description { set; get; }

    [StringLength(250)]
    [Required]
    public string Image { set; get; }

    [StringLength(250)]
    public string Url { set; get; }

    public int? DisplayOrder { set; get; }

    public string? Content { set; get; }

    [Required]
    public SlideGroup GroupAlias { get; set; }

    public int SortOrder { set; get; }
    public Status Status { set; get; }
}
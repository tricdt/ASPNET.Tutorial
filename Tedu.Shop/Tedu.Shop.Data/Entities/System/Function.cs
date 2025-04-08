using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.Enums;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;
[Table("Functions")]
public class Function : DomainEntity<Guid>, ISwitchable, ISortable, IHasUniqueCode
{
    public Function()
    {
    }

    public Function(string name, string url, Guid? parentId,
        string cssClass, int sortOrder)
    {
        Name = name;
        Url = url;
        ParentId = parentId;
        CssClass = cssClass;
        SortOrder = sortOrder;
        Status = Status.Actived;
    }

    [Required]
    [StringLength(128)]
    public string Name { set; get; }

    [Required]
    [StringLength(250)]
    public string Url { set; get; }

    public Guid? ParentId { set; get; }

    public string ParentList { set; get; }

    public string CssClass { get; set; }
    public int SortOrder { set; get; }
    public Status Status { set; get; }
    public string UniqueCode { set; get; }
}
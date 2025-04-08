using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;

[Table("Menus")]
public class Menu : DomainEntity<Guid>
{
    public Menu()
    {
    }

    public Menu(Guid id, string name, string url, int? displayOrder, Guid groupId, string target, bool status)
    {
        Id = id;
        Name = name;
        URL = url;
        DisplayOrder = displayOrder;
        GroupID = groupId;
        Target = target;
        Status = status;
    }


    [Required]
    [MaxLength(50)]
    public string Name { set; get; }

    [Required]
    [MaxLength(256)]
    public string URL { set; get; }

    public int? DisplayOrder { set; get; }

    [Required]
    public Guid GroupID { set; get; }

    [ForeignKey("GroupID")]
    public virtual MenuGroup MenuGroup { set; get; }

    [MaxLength(10)]
    public string Target { set; get; }

    public bool Status { set; get; }
}
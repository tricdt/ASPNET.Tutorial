using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.System;

[Table("MenuGroups")]
public class MenuGroup : DomainEntity<Guid>
{
    public MenuGroup()
    {
    }

    public MenuGroup(Guid id, string name)
    {
        Id = id;
        Name = name;
    }


    [Required]
    [MaxLength(50)]
    public string Name { set; get; }

    public virtual IEnumerable<Menu> Menus { set; get; }
}
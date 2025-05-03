using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tedu.KnowledgeSpace.BackendServer.Data.Entities;

[Table("Commands")]
public class Command
{
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    [Key]
    public string Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
}

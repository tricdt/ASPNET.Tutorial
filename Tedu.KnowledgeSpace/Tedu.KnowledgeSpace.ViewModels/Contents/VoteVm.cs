using System;

namespace Tedu.KnowledgeSpace.ViewModels.Contents;

public class VoteVm
{
    public int KnowledgeBaseId { get; set; }
    public string UserId { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}

using System;

namespace Tedu.KnowledgeSpace.ViewModels.Contents;

public class CommentCreateRequest
{
    public string Content { get; set; }

    public int KnowledgeBaseId { get; set; }
}

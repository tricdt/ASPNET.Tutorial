using System;
using FluentValidation;

namespace Tedu.KnowledgeSpace.ViewModels.Contents;

public class KnowledgeBaseCreateRequestValidator : AbstractValidator<KnowledgeBaseCreateRequest>
{
    public KnowledgeBaseCreateRequestValidator()
    {
    }
}
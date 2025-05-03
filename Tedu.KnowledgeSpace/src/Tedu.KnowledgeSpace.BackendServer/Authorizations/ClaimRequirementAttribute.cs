using System;
using Microsoft.AspNetCore.Mvc;
using Tedu.KnowledgeSpace.BackendServer.Constants;

namespace Tedu.KnowledgeSpace.BackendServer.Authorizations;

public class ClaimRequirementAttribute : TypeFilterAttribute
{
    public ClaimRequirementAttribute(FunctionCode functionId, CommandCode commandId)
        : base(typeof(ClaimRequirementFilter))
    {
        Arguments = new object[] { functionId, commandId };
    }
}

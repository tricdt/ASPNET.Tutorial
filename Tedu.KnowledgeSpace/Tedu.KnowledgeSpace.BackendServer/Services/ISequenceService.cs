using System;

namespace Tedu.KnowledgeSpace.BackendServer.Services;

public interface ISequenceService
{
    Task<int> GetKnowledgeBaseNewId();
}

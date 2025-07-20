using System;
using Examination.Shared.ExamResults;
using Examination.Shared.SeedWork;
using MediatR;

namespace Examination.Application.Commands.V1.ExamResults.StartExam;

public class StartExamCommandHandler : IRequestHandler<StartExamCommand, ApiResult<ExamResultDto>>
{
    public Task<ApiResult<ExamResultDto>> Handle(StartExamCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

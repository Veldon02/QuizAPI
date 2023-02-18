using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.MarkAggregate;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetPasserMark
{
    public class GetPasserMarkQueryHandler : IRequestHandler<GetPasserMarkQuery, OneOf<Mark, IError>>
    {
        private readonly IMarkRepository _markRepository;
        public GetPasserMarkQueryHandler(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        public async Task<OneOf<Mark, IError>> Handle(GetPasserMarkQuery request, CancellationToken cancellationToken)
        {
            var mark = await _markRepository.GetAsync(request.QuizId, request.PasserId);

            if (mark == null) return new MarkNotFoundError();

            return mark;
        }
    }
}

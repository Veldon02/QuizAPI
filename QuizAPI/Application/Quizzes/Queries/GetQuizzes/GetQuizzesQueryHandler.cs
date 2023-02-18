using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.QuizAggregate;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetQuizzes
{
    public class GetQuizzesQueryHandler : IRequestHandler<GetQuizzesQuery, OneOf<List<Quiz>, IError>>
    {
        private readonly IQuizRepository _quizRepository;
        public GetQuizzesQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<OneOf<List<Quiz>, IError>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
        {
            return await _quizRepository.GetQuizzesAsync(request.specification);
        }
    }
}

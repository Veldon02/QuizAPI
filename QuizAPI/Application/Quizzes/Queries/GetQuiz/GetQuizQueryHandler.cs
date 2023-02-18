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

namespace Application.Quizzes.Queries.GetQuiz
{
    public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, OneOf<Quiz, IError>>
    {
        private readonly IQuizRepository _quizRepository;
        public GetQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<OneOf<Quiz, IError>> Handle(GetQuizQuery request, CancellationToken cancellationToken)
        {
            var result = await _quizRepository.GetQuizAsync(request.QuizId);
            if (result == null) return new QuizNotFoundError();

            return result;
        }
    }
}

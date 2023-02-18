using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.QuizAggregate.Entities;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetQuizQuestion
{
    public class GetQuizQuestionQueryHandler : IRequestHandler<GetQuizQuestionQuery, OneOf<Question, IError>>
    {
        private readonly IQuizRepository _quizRepository;
        public GetQuizQuestionQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<OneOf<Question, IError>> Handle(GetQuizQuestionQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizAsync(request.QuizId);
            if (quiz == null)
                return new QuizNotFoundError();

            var question = quiz.Questions.FirstOrDefault(q => q.Id == request.QuestionId);
            if (question == null)
                return new QuestionNotFoundError();

            return question;
        }
    }
}

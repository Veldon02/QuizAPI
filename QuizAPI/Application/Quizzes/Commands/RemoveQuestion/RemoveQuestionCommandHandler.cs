using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.RemoveQuestion
{
    public class RemoveQuestionCommandHandler : IRequestHandler<RemoveQuestionCommand, OneOf<Unit, IError>>
    {
        private readonly IQuizRepository _quizRepository;

        public RemoveQuestionCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<OneOf<Unit, IError>> Handle(RemoveQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizAsync(request.QuizId);
            if (quiz == null) return new QuizNotFoundError();

            quiz.RemoveQuestion(request.QuestionId);

            await _quizRepository.UpdateQuizAsync(quiz);

            return Unit.Value;
        }
    }
}

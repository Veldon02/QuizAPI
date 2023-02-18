using Application.Common.Interfaces.Persistence;
using Application.Quizzes.Commands.AddQuestion;
using Domain.Common.Errors;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.UpdateQuizInfo
{
    public class UppdateQuizInfoCommandHandler : IRequestHandler<UpdateQuizInfoCommand, OneOf<Unit, IError>>
    {
        private readonly IQuizRepository _quizRepository;

        public UppdateQuizInfoCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<OneOf<Unit, IError>> Handle(UpdateQuizInfoCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizAsync(request.QuizId);
            if (quiz == null) return new QuizNotFoundError();

            quiz.Update(request.Name, request.Description, request.Difficulty);

            await _quizRepository.UpdateQuizAsync(quiz);

            return Unit.Value;
        }
    }
}


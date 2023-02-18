using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, OneOf<Unit,IError>>
    {
        private readonly IQuizRepository _quizRepository;

        public DeleteQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<OneOf<Unit, IError>> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizAsync(request.QuizId);
            if (quiz == null) return new QuizNotFoundError();

            await _quizRepository.UpdateQuizAsync(quiz);

            return Unit.Value;
        }
    }
}

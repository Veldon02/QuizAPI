using Application.Common.Interfaces.Persistence;
using Application.Quizzes.Commands.CreateQuiz;
using Domain.Common.Errors;
using Domain.QuizAggregate.Entities;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.AddQuestion
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, OneOf<Unit, IError>>
    {
        private readonly IQuizRepository _quizRepository;

        public AddQuestionCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<OneOf<Unit, IError>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizAsync(request.QuizId);
            if (quiz == null) return new QuizNotFoundError();

            var question = Question.Create(
                request.Title,
                request.CorrectAnswer, 
                request.Answers
                    .ConvertAll(x => Answer.Create(x.Title)));

            quiz.AddQuestion(question);

            await _quizRepository.UpdateQuizAsync(quiz);

            return Unit.Value;
        }
    }
}

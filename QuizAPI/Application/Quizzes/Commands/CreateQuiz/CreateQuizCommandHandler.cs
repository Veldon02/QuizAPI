using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.QuizAggregate;
using Domain.QuizAggregate.Entities;
using MediatR;
using OneOf;

namespace Application.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, OneOf<Quiz, IError>>
{
    private readonly IQuizRepository _quizRepository;
    public CreateQuizCommandHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    public async Task<OneOf<Quiz, IError>> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = Quiz.Create(
            request.Name,
            request.Description,
            request.Difficulty,
            request.AuthorId,
            request.Questions
                   .ConvertAll(x => Question.Create(
                                    x.Title,
                                    x.CorrectAnswer,
                                    x.Answers
                                    .ConvertAll(y => Answer.Create(y.Title)))
            )
        );
        return await _quizRepository.AddQuizAsync(quiz);
    }
}

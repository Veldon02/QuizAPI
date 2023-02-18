using Domain.Common.Errors;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.AddQuestion
{
    public record AddQuestionCommand(
        QuizId QuizId,
        string Title,
        byte CorrectAnswer,
        List<AnswerCommand> Answers) : IRequest<OneOf<Unit,IError>>;

    public record AnswerCommand(
        string Title);
}

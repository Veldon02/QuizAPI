using Domain.Common.Errors;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.UpdateQuizInfo
{
    public record UpdateQuizInfoCommand(
        QuizId QuizId,
        string Name,
        string Description,
        byte Difficulty) : IRequest<OneOf<Unit, IError>>;
}

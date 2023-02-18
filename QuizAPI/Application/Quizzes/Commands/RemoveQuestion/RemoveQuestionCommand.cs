using Domain.Common.Errors;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.RemoveQuestion
{
    public record RemoveQuestionCommand(QuizId QuizId, QuestionId QuestionId) : IRequest<OneOf<Unit, IError>>;
}

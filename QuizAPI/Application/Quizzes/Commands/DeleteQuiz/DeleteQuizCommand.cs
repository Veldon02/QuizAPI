using Domain.Common.Errors;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.DeleteQuiz
{
    public record DeleteQuizCommand (QuizId QuizId) : IRequest<OneOf<Unit,IError>>;
}

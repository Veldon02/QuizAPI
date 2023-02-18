using Domain.Common.Errors;
using Domain.QuizAggregate;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetQuiz
{
    public record GetQuizQuery( QuizId QuizId) : IRequest<OneOf<Quiz, IError>>;
}

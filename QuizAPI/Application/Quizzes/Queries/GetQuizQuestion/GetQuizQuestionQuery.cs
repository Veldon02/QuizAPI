using Domain.Common.Errors;
using Domain.QuizAggregate.Entities;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetQuizQuestion
{
    public record GetQuizQuestionQuery(QuizId QuizId, QuestionId QuestionId) : IRequest<OneOf<Question, IError>>;
}

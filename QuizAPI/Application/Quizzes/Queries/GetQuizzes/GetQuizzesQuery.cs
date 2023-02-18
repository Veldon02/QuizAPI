using Application.Common.Specifications;
using Domain.Common.Errors;
using Domain.QuizAggregate;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetQuizzes
{
    public record GetQuizzesQuery(
        Specification specification) : IRequest<OneOf<List<Quiz>,IError>>;
}

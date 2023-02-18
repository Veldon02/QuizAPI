using Domain.Common.Errors;
using Domain.MarkAggregate;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate.ValueObjects;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Queries.GetPasserMark
{
    public record GetPasserMarkQuery (QuizId QuizId, PasserId PasserId) : IRequest<OneOf<Mark,IError>>;
}

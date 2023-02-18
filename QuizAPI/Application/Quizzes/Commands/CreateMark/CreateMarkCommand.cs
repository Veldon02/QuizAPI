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

namespace Application.Quizzes.Commands.CreateMark
{
    public record CreateMarkCommand(QuizId QuizId, PasserId PasserId, int Mark) : IRequest<OneOf<Mark,IError>>;

}

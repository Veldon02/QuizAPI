using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.MarkAggregate;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.CreateMark
{
    public class CreateMarkCommandHandler : IRequestHandler<CreateMarkCommand, OneOf<Mark, IError>>
    {
        private readonly IMarkRepository _markRepository;

        public CreateMarkCommandHandler(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        public async Task<OneOf<Mark, IError>> Handle(CreateMarkCommand request, CancellationToken cancellationToken)
        {
            var mark = Mark.Create(request.Mark, request.QuizId, request.PasserId);

            mark = await _markRepository.AddAsync(mark);

            return mark;
        }
    }
}

using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.CreateQuiz
{
    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => (int)x.Difficulty)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(10);
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleForEach(x => x.Questions)
                .ChildRules( child => { 
                    child.RuleFor(x => x.Title).NotEmpty();
                    child.RuleFor(x => (int)x.CorrectAnswer)
                        .GreaterThanOrEqualTo(0)
                        .LessThanOrEqualTo(3);
                    child.RuleFor(x => x.Answers.Count).Equal(4);
                    child.RuleForEach(x => x.Answers)
                        .ChildRules(child => child.RuleFor(x => x.Title).NotEmpty());
                });
        }
    }
}

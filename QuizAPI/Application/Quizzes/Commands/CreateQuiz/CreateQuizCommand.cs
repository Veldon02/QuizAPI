using Domain.AuthorAggregate.ValueObjects;
using Domain.Common.Errors;
using Domain.QuizAggregate;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quizzes.Commands.CreateQuiz;

public record CreateQuizCommand(
    string Name,
    string Description,
    byte Difficulty,
    AuthorId AuthorId,
    List<QuestionCommand> Questions
    ) : IRequest<OneOf<Quiz, IError>>;

public record QuestionCommand(
    string Title,
    List<AnswerCommand> Answers,
    byte CorrectAnswer);

public record AnswerCommand(
    string Title);

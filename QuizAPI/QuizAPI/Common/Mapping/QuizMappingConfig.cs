using Application.Quizzes.Commands.AddQuestion;
using Application.Quizzes.Commands.CreateMark;
using Application.Quizzes.Commands.CreateQuiz;
using Application.Quizzes.Commands.RemoveQuestion;
using Application.Quizzes.Commands.UpdateQuizInfo;
using Application.Quizzes.Queries.GetPasserMark;
using Application.Quizzes.Queries.GetQuiz;
using Application.Quizzes.Queries.GetQuizQuestion;
using Domain.AuthorAggregate.ValueObjects;
using Domain.MarkAggregate;
using Domain.PasserAggregate.ValueObjects;
using Domain.QuizAggregate;
using Domain.QuizAggregate.Entities;
using Domain.QuizAggregate.ValueObjects;
using Mapster;
using Presentation.Api.Contracts.Quizzes;

namespace QuizAPI.Mapping
{
    public class QuizMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<(CreateQuizRequest request, string authorId), CreateQuizCommand>()
                .Map(dest => dest.AuthorId, src => AuthorId.Create(src.authorId))
                .Map(dest => dest, src => src.request);

            config.NewConfig<Quiz, QuizResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.AuthorId, src => src.AuthorId.Value)
                .Map(dest => dest.QuestionIds, src => src.Questions)
                .Map(dest => dest, src => src);

            config.NewConfig<Question, Guid>()
               .MapWith(src => src.Id.Value);

            config.NewConfig<GetPasserMarkRequest, GetPasserMarkQuery>()
                .Map(dest => dest.QuizId, src => QuizId.Create(src.quizId))
                .Map(dest => dest.PasserId, src => PasserId.Create(src.passerId));

            config.NewConfig<Mark, MarkResponse>()
                .Map(dest => dest.ReceiptDate, src => src.CreatedTime)
                .Map(dest => dest.PasserId, src => src.PasserId.Value)
                .Map(dest => dest.QuizId, src => src.QuizId.Value)
                .Map(dest => dest.Mark, src => src.PasserMark)
                .Map(dest => dest, src => src);

            config.NewConfig<GetQuizQuestionRequest, GetQuizQuestionQuery>()
                .Map(dest => dest.QuizId, src => QuizId.Create(src.QuizId))
                .Map(dest => dest.QuestionId, src => QuestionId.Create(src.QuestionId));

            config.NewConfig<Question, QuestionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Answers, src => src.Answers)
                .Map(dest => dest.CorrectAnswer, src => src.Answers[src.CorrectAnswer].Id.Value);

            config.NewConfig<Answer, AnswerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest, src => src);

            config.NewConfig<CreateMarkRequest, CreateMarkCommand>()
                .Map(dest => dest.QuizId, src => QuizId.Create(src.QuizId))
                .Map(dest => dest.PasserId, src => PasserId.Create(src.PasserId))
                .Map(dest => dest.Mark, src => src.Mark);

            config.NewConfig<(string quizId, AddQuestionRequest request), AddQuestionCommand>()
                .Map(dest => dest.QuizId, src => QuizId.Create(src.quizId))
                .Map(dest => dest, src => src.request);

            config.NewConfig<(string quizId, Guid questionId), RemoveQuestionCommand>()
                .Map(dest => dest.QuizId, src => QuizId.Create(src.quizId))
                .Map(dest => dest.QuestionId, src => QuestionId.Create(src.questionId));

            config.NewConfig<(string quizId, UpdateQuizInfoRequest request), UpdateQuizInfoCommand>()
                .Map(dest => dest.QuizId, src => QuizId.Create(src.quizId))
                .Map(dest => dest, src => src.request);
        }
    }
}
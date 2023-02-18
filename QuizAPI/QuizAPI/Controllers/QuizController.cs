using Application.Common.Interfaces.Persistence;
using Application.Common.Specifications;
using Application.Quizzes.Commands.AddQuestion;
using Application.Quizzes.Commands.CreateMark;
using Application.Quizzes.Commands.CreateQuiz;
using Application.Quizzes.Commands.DeleteQuiz;
using Application.Quizzes.Commands.RemoveQuestion;
using Application.Quizzes.Commands.UpdateQuizInfo;
using Application.Quizzes.Queries.GetPasserMark;
using Application.Quizzes.Queries.GetQuiz;
using Application.Quizzes.Queries.GetQuizQuestion;
using Application.Quizzes.Queries.GetQuizzes;
using Domain.Common.Errors;
using Domain.MarkAggregate;
using Domain.QuizAggregate;
using Domain.QuizAggregate.Entities;
using Domain.QuizAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Presentation.Api.Contracts.Quizzes;
using System.Reflection.Metadata.Ecma335;

namespace Presentation.Api.Controllers
{
    [Route("api/")]
    public class QuizController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _madiator;
        public QuizController(IMapper mapper, ISender madiator)
        {
            _mapper = mapper;
            _madiator = madiator;
        }

        #region GET

        [HttpGet("quizzes")]
        public async Task<ActionResult<List<QuizResponse>>> GetQuizzes([FromQuery] Specification specification)
        {
            var query = new GetQuizzesQuery(specification);
            var result = await _madiator.Send(query);
            return result.Match(
                quizzes => Ok(_mapper.Map<List<QuizResponse>>(quizzes)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        [HttpGet("quiz/{quizId}")]
        public async Task<ActionResult<QuizResponse>> GetQuiz(string quizId)
        {
            var query = new GetQuizQuery(QuizId.Create(quizId));
            var result = await _madiator.Send(query);
            return result.Match(
                quiz => Ok(_mapper.Map<QuizResponse>(quiz)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        [HttpGet("quiz/mark")]
        public async Task<ActionResult<MarkResponse>> GetQuizMark([FromQuery] GetPasserMarkRequest request)
        {
            var query = _mapper.Map<GetPasserMarkQuery>(request);
            var result = await _madiator.Send(query);
            return result.Match(
                mark => Ok(_mapper.Map<MarkResponse>(mark)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        [HttpGet ("quiz/question")]
        public async Task<ActionResult<Question>> GetQuizQuestion([FromQuery] GetQuizQuestionRequest request)
        {
            var query = _mapper.Map<GetQuizQuestionQuery>(request);
            var result = await _madiator.Send(query);
            return result.Match(
                question => Ok(_mapper.Map<QuestionResponse>(question)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }   

        #endregion

        #region POST

        [HttpPost("authors/{authorId}/quiz")]
        public async Task<ActionResult<Quiz>> PostQuiz(string authorId, CreateQuizRequest quizRequest)
        {
            var createQuizCommand = _mapper.Map<CreateQuizCommand>((quizRequest, authorId));

            var result = await _madiator.Send(createQuizCommand);

            return result.Match(
                quiz => Ok(_mapper.Map<QuizResponse>(quiz)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        [HttpPost("quiz/mark")]
        public async Task<ActionResult<Quiz>> PostMark(CreateMarkRequest request)
        {
            var command = _mapper.Map<CreateMarkCommand>(request);

            var result = await _madiator.Send(command);

            return result.Match(
                mark => Ok(_mapper.Map<MarkResponse>(mark)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        #endregion

        #region PUT

        [HttpPut("quiz/{quizId}")]
        public async Task<ActionResult> PutQuiz(string quizId, UpdateQuizInfoRequest request)
        {
            var command = _mapper.Map<UpdateQuizInfoCommand>((quizId,request));

            var result = await _madiator.Send(command);

            return result.Match(
                _ => (dynamic)NoContent(),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        [HttpPut("quiz/{quizId}/add-question")]
        public async Task<ActionResult> AddQuestion(string quizId, AddQuestionRequest request)
        {
            var command = _mapper.Map<AddQuestionCommand>((quizId,request));

            var result = await _madiator.Send(command);

            return result.Match(
                _ => (dynamic)NoContent(),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        [HttpPut("quiz/{quizId}/question/{questionId:guid}/remove")]
        public async Task<ActionResult> RemoveQuestion(string quizId, Guid questionId)
        {
            var command = _mapper.Map<RemoveQuestionCommand>((quizId, questionId));

            var result = await _madiator.Send(command);

            return result.Match(
                _ => (dynamic)NoContent(),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        #endregion

        #region DELETE

        [HttpDelete("quiz/{quizId}")]
        public async Task<ActionResult> DeleteQuiz(string quizId)
        {
            var command = new DeleteQuizCommand(QuizId.Create(quizId));
            var result = await _madiator.Send(command);
            return result.Match(
                _ => (dynamic)NoContent(),
                error => Problem(statusCode: (int)error.StatusCode, title: error.Title));
        }

        #endregion




    }
}

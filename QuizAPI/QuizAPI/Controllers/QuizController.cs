using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using QuizAPI.Models.Request;
using QuizAPI.Models.Response;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMarkRepository _markRepository;
        private readonly IQuestionRepository _questionRepository;

        public QuizController(IQuizRepository quizRepository,
            IUserRepository userRepository, 
            IMarkRepository markRepository,
            IQuestionRepository questionRepository)
        {
            _quizRepository = quizRepository;
            _userRepository = userRepository;
            _markRepository = markRepository;
            _questionRepository = questionRepository;
        }

        #region GET

        [HttpGet("quiz/{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int id)
        {
            var quiz = await _quizRepository.GetQuizAsync(id);
            if (quiz == null) return NotFound();

            var quizResponse = await CreateQuizResponseFromQuizAsync(quiz);

            return Ok(quizResponse);
        }

        [HttpGet("quizzes")]
        public async Task<ActionResult<IEnumerable<QuizResponse>>> GetQuizzes([FromQuery] QuerySpecification querySpecification)
        {
            var quizzes = await _quizRepository.GetQuizzesAsync(querySpecification);

            var quizResponses = new List<QuizResponse>();
            foreach(var quiz in quizzes)
            {
                quizResponses.Add(await CreateQuizResponseFromQuizAsync(quiz));
            }

            return Ok(quizResponses);
        }

        [HttpGet("question/{id}")]
        public async Task<ActionResult<QuestionResponse>> GetQuestion(int id)
        {
            var question = await _questionRepository.GetQuestionAsync(id);
            if (question == null) return NotFound();

            var questionResponse = await CreateQuestionResponseFromQuestionAsync(question); 

            return Ok(questionResponse);
        }

        [HttpGet("mark/{email}/{quizId}")]
        public async Task<ActionResult<IEnumerable<MarkResponse>>> GetMark(string email, int quizId)
        {
            var marks = await _markRepository.GetMarkAsync(quizId, email);

            if (marks.Count() == 0) return NotFound();

            var markResponses = new List<MarkResponse>();

            foreach(var mark in marks)
            {
                var markResponse = await CreateMarkResponseFromMarkAsync(mark);
                markResponses.Add(markResponse);
            }

            return markResponses;
        }

        [HttpGet("questionAnswer/{questionId}")]
        public async Task<ActionResult<AnswerResponse>> GetQuestionAnswer(int questionId)
        {
            var questionAnswer = await _questionRepository.GetQuestionAnswerAsync(questionId);
            if (questionAnswer == null) return NotFound();

            var answer = await _questionRepository.GetAnswerAsync(questionAnswer.AnswerId);

            var answerresponse = new AnswerResponse()
            {
                Id = answer.Id,
                Text = answer.Title
            };
            return answerresponse;
        }

        #endregion

        #region POST

        [HttpPost("quiz")]
        public async Task<ActionResult<QuizResponse>> CreateQuiz([FromBody] QuizRequest quizRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Provide all required fields");

            if (quizRequest.Difficulty > 10 && quizRequest.Difficulty <= 0) return BadRequest("Difficulty must be in [1,10]");

            var user = await _userRepository.GetUserByEmailAsync(quizRequest.AuthorEmail);
            if (user == null) return BadRequest("Invalid author email");

            var questionCount = quizRequest.Questions.Count();
            if (questionCount == 0 || questionCount > byte.MaxValue) return BadRequest("Quiz must have at least 1 question");

            var subject = await _quizRepository.GetSubjectAsync(quizRequest.Subject);
            if (subject == null) return BadRequest("Invalid subject name");

            var quizResponse = await CreateQuizFromRequestAsync(quizRequest);

            return Ok(quizResponse);
        }

        [HttpPost("mark")]
        public async Task<ActionResult<MarkResponse>> PostMark([FromBody] MarkRequest markRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Provide all required fields");

            var user = await _userRepository.GetUserByEmailAsync(markRequest.UserEmail);
            if (user == null) return BadRequest("invalid user email");

            var quiz = await _quizRepository.GetQuizAsync(markRequest.QuizId);
            if (markRequest.Mark > quiz.QuestionCount) return BadRequest("invalid mark");

            var mark = new Mark()
            {
                QuizId = markRequest.QuizId,
                UserId = user.Id,
                QuizMark = markRequest.Mark
            };

            mark = await _markRepository.CreateMarkAsync(mark);

            var markResponse = new MarkResponse()
            {
                QuizId = mark.Id,
                UserEmail = user.Email,
                Mark = mark.QuizMark,
                MaxMark = quiz.QuestionCount
            };

            return markResponse;
        }

        #endregion


        #region Private methods
        private async Task<QuizResponse> CreateQuizFromRequestAsync(QuizRequest quizRequest)
        {
            var user = await _userRepository.GetUserByEmailAsync(quizRequest.AuthorEmail);
            var questionCount = quizRequest.Questions.Count();
            var subject = await _quizRepository.GetSubjectAsync(quizRequest.Subject);

            var quiz = new Quiz()
            {
                Name = quizRequest.Name,
                Description = quizRequest.Description,
                Difficulty = quizRequest.Difficulty,
                AuthorId = user.Id,
                SubjectId = subject.Id,
                QuestionCount = (byte)questionCount
            };

            quiz =  await _quizRepository.CreateQuizAsync(quiz);

            var quizResponse = new QuizResponse()
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                QuestionCount = (byte)questionCount,
                Difficulty = quiz.Difficulty,
                Author = new UserResponse()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName
                },
                Subject = subject.Name,
            };

            var questionResponses = new List<int>();

            foreach(var questionRequest in quizRequest.Questions)
            {
                var questionResponse = await CreateQuestionFromRequestAsync(questionRequest, quiz);

                questionResponses.Add(questionResponse.Id);
            }

            quizResponse.Questions = questionResponses;

            return quizResponse;
        }

        private async Task<QuestionResponse> CreateQuestionFromRequestAsync(QuestionRequest questionRequest, Quiz quiz)
        {
            var question = new Question()
            {
                Title = questionRequest.Title,
                QuizId = quiz.Id
            };

            question = await _questionRepository.CreateQuastionAsync(question);

            var questionResponse = new QuestionResponse()
            {
                Id = question.Id,
                Title = question.Title
            };


            var answerResponses = new List<AnswerResponse>();
            foreach (var answerRequest in questionRequest.Answers)
            {
                var answerResponse = await CreateAnswerFromRequestAsync(answerRequest, question);

                answerResponses.Add(answerResponse);
            }

            await _questionRepository.CreateQuastionAnswerAsync(question.Id, answerResponses[questionRequest.CorrectAnswer].Id);

            questionResponse.Answers = answerResponses;
            return questionResponse;
        }

        private async Task<AnswerResponse> CreateAnswerFromRequestAsync(AnswerRequest answerRequest, Question question)
        {
            var answer = new Answer()
            {
                Title = answerRequest.Text,
                QuestionId = question.Id
            };

            answer = await _questionRepository.CreateAnswerAsync(answer);

            var answerResponse = new AnswerResponse()
            {
                Id = answer.Id,
                Text = answer.Title
            };

            return answerResponse;
        }

        private async Task<QuizResponse> CreateQuizResponseFromQuizAsync(Quiz quiz)
        {
            var author = await _userRepository.GetUserByIdAsync(quiz.AuthorId);
            var subject = await _quizRepository.GetSubjectAsync(quiz.SubjectId);

            var quizResponse = new QuizResponse()
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Author = new UserResponse()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    UserName = author.UserName
                },
                Difficulty = quiz.Difficulty,
                Subject = subject.Name,
                QuestionCount = quiz.QuestionCount,
            };

            var questionReponses = new List<int>();

            var questions = await _questionRepository.GetQuestionsAsync(quiz.Id);

            foreach (var question in questions)
            {
                var questionResponse = await CreateQuestionResponseFromQuestionAsync(question);
                questionReponses.Add(questionResponse.Id);
            }

            quizResponse.Questions = questionReponses;

            return quizResponse;
        }

        private async Task<QuestionResponse> CreateQuestionResponseFromQuestionAsync(Question question)
        {
            var questionResponse = new QuestionResponse()
            {
                Id = question.Id,
                Title = question.Title
            };

            var answerResponses = new List<AnswerResponse>();

            var answers = await _questionRepository.GetAnswersAsync(question.Id);

            foreach(var answer in answers)
            {
                var answerresponse = CreateAnswerResponseFromAnswer(answer);
                answerResponses.Add(answerresponse);
            }

            questionResponse.Answers = answerResponses;

            return questionResponse;
        }

        private AnswerResponse CreateAnswerResponseFromAnswer(Answer answer)
        {
            var answerResponse = new AnswerResponse()
            {
                Id = answer.Id,
                Text = answer.Title
            };

            return answerResponse;
        }

        private async Task<MarkResponse> CreateMarkResponseFromMarkAsync(Mark mark)
        {
            var user = await _userRepository.GetUserByIdAsync(mark.UserId);
            var quiz = await _quizRepository.GetQuizAsync(mark.QuizId);

            var markResponse = new MarkResponse()
            {
                QuizId = mark.QuizId,
                UserEmail = user.Email,
                Mark = mark.QuizMark,
                MaxMark = quiz.QuestionCount
            };

            return markResponse;
        }

        #endregion
    }
}

using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Api.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            ArgumentNullException.ThrowIfNull(quizService);
            _quizService = quizService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Quize))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> PostQuiz([FromBody] QuizToCreateDTO quiz, CancellationToken cToken)
        {
            Quize result;
            try
            {
                result = await _quizService.CreateAsync(quiz, cToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(PostQuiz), result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Quize))]
        public async Task<IActionResult> GetQuizzes(CancellationToken cToken)
        {
            return Ok(await _quizService.FindAllAsync(cToken));
        }

        [HttpPost("f")]
        public async Task<IActionResult> PostMultipleChoiceQuestionAsync([FromBody] MultipleChoiceQuestionDTO question)
        {
            await Task.Delay(100);
            return Ok();
        }
    }
}

        /*[HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Quize>), 200)]
        public async Task<ActionResult<IEnumerable<QuizToCreateDTO>>> GetQuizzes(CancellationToken cancellationToken)
        {
            return Ok(await _quizService.RetrieveQuizzes(cancellationToken));
        }

        [HttpGet("{id}", Name = _GetQuizByIdEndpointName)]
        [ProducesResponseType(typeof(QuizForDisplay), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<QuizForDisplay>> GetQuiz(
            int id, CancellationToken cancellationToken)
        {
            var result = await _quizService.RetrieveQuiz(id, cancellationToken);

            if (result.IsT0)
            {
                return Ok(result.AsT0);
            }

            return result.HandleError(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<QuizForDisplay>> DeleteQuiz(
            int id, CancellationToken cancellationToken)
        {
            var result = await _quizService.DeleteQuiz(id, cancellationToken);

            if (result.IsT0)
            {
                return NoContent();
            }

            return result.HandleError(this);
        }

        [HttpPost()]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<QuizToCreateDTO>> PostQuiz(
            [FromBody] QuizToCreateDTO quiz, CancellationToken cancellationToken)
        {
            var result = await _quizHandler
                .CreateQuiz(quiz, cancellationToken);

            if (result.IsT1)
            {
                return result.HandleError(this);
            }

            var resourceUrl = Url.Action(
                    _GetQuizByIdEndpointName,
                    "Quizzes",
                    new { result.AsT0.Id, cancellationToken }, Request.Scheme);
            var responseQuiz = _Mapper.Map<QuizToCreateDTO>(result.AsT0);
            return Created(resourceUrl!, responseQuiz);
        }

        [HttpGet("{id}/questions")]
        [ProducesResponseType(typeof(IEnumerable<QuestionDTO>), 200)]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions(
            int id, CancellationToken cancellationToken)
        {
            var result = await _questionHandler.RetrieveQuestions(id, cancellationToken);
            if (result.IsT0)
            {
                return Ok(result.AsT0);
            }

            return result.HandleError(this);
        }

        [HttpGet("{quizId}/questions/{questionId}")]
        [ProducesResponseType(typeof(QuestionDTO), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<QuestionDTO>> GetQuestionById(
            int quizId, int questionId, CancellationToken cancellationToken)
        {
            var result = await _questionHandler.RetrieveQuestion(quizId, questionId, cancellationToken);

            if (result.IsT0)
            {
                return Ok(result.AsT0);
            }

            return result.HandleError(this);
        }

        [HttpPost("{quizId}/multipleOptionQuestions")]
        [ProducesResponseType(typeof(MultipleOptionQuestionDTO), 201)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<MultipleOptionQuestionDTO>> PostQuestion(
            int quizId, [FromBody] MultipleOptionQuestionDTO question, CancellationToken cancellationToken)
        {
            return await CreateMultipleOptionQuestion(quizId, question, cancellationToken);
        }

        [HttpPost("{quizId}/fillInBlankQuestions")]
        [ProducesResponseType(typeof(FillInBlankQuestionDTO), 201)]
        [ProducesResponseType(422)]
        public async Task<ActionResult<FillInBlankQuestionDTO>> PostQuestion(
            int quizId, [FromBody] FillInBlankQuestionDTO question, CancellationToken cancellationToken)
        {
            return await CreateFillInBlankOptionQuestion(quizId, question, cancellationToken);
        }

        private async Task<ActionResult<MultipleOptionQuestionDTO>> CreateMultipleOptionQuestion(
            int quizId, MultipleOptionQuestionDTO question, CancellationToken cancellationToken)
        {
            var result = await _multipleQuestionHandler
                .CreateQuestion(quizId, question, cancellationToken);

            if (result.IsT0)
            {
                var resourceUrl = Url.Action(
                    _GetQuizByIdEndpointName,
                    ControllerContext.ActionDescriptor.ControllerName,
                    new { result.AsT0.Id, cancellationToken }, Request.Scheme);
                return Created(resourceUrl!, result.AsT0);
            }

            return result.HandleError(this);
        }

        private async Task<ActionResult<FillInBlankQuestionDTO>> CreateFillInBlankOptionQuestion(
            int quizId, FillInBlankQuestionDTO question, CancellationToken cancellationToken)
        {
            var result = await _fillInBlankQuestionHandler
                .CreateQuestion(quizId, question, cancellationToken);

            if (result.IsT0)
            {
                var resourceUrl = Url.Action(
                    _GetQuizByIdEndpointName,
                    ControllerContext.ActionDescriptor.ControllerName,
                    new { result.AsT0.Id, cancellationToken }, Request.Scheme);
                return Created(resourceUrl!, result.AsT0);
            }

            return result.HandleError(this);
        } 
        */
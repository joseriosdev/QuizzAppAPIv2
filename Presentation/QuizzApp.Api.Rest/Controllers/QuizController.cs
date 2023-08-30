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
                result = await _quizService.CreateDraftAsync(quiz, cToken);
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

        [HttpPost("{id}/Question/MultipleChoice")]
        public async Task<IActionResult> PostMultipleChoiceQuestionAsync(
            [FromBody] MultipleChoiceQuestionDTO question, int id,
            CancellationToken cToken
            )
        {
            Quize responseQuiz;
            try
            {
                responseQuiz = await _quizService
                    .AddMultipleChoiceQuestionAsync(id, question, cToken);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(responseQuiz);
        }

        [HttpPost("{id}/Question/FillInBlank")]
        public async Task<IActionResult> PostFillInQuestionAsync(
            [FromBody] FillInQuestionDTO question, int id,
            CancellationToken cToken
            )
        {
            Quize responseQuiz;
            try
            {
                responseQuiz = await _quizService
                    .AddFillInQuestionAsync(id, question, cToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(responseQuiz);
        }
    }
}
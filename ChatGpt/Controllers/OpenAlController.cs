using ChatGpt.Interfaces;
using ChatGpt.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatGpt.Controllers
{
    [Route("/chat-gpt")]
    public class OpenAlController : Controller
    {
        private readonly IOpenAIService _openAIService;

        public OpenAlController(IOpenAIService service)
        {
            _openAIService = service;
        }


        [HttpGet]
        public async Task<string> Get(string question)
        {
            return await _openAIService.AskQuestion(question);
        }
    }
}

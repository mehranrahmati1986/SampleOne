namespace ChatGpt.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> AskQuestion(string question);
    }
}

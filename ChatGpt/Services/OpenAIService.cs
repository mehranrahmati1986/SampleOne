using ChatGpt.Interfaces;
using ChatGpt.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ChatGpt.Services
{
    public class OpenAIService : IOpenAIService
    {
        string _apiKey = "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";
        string modelId = "gpt-3.5-turbo";

        private readonly HttpClient _httpClient;
        public OpenAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AskQuestion(string question)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(CreateResquest(question));
            var content = new StringContent(requestJson, null, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();

            var chatCompletion = JsonConvert.DeserializeObject<ChatCompletion>(responseJson);


            return chatCompletion?.choices?.FirstOrDefault()?.message?.content ?? "";

            #region
            /*            var request = new
                        {
                            prompt = question,
                            model = modelId,
                            max_tokens = 1,
                        };

                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

                        var response = await _httpClient.PostAsync("https://api.openai.com/v1/engines/davinci-codex/completions", content);

                        response.EnsureSuccessStatusCode();

                        var responseContent = await response.Content.ReadAsStringAsync();

                        dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);

                        return responseObject.choices[0].text;*/

            #endregion
        }



        private Resquest CreateResquest(string question)
        {
            var msg = new List<Message>();
            msg.Add(new Message
            {
                role = "user",
                content = question
            });

            return new Resquest
            {
                model = modelId,
                messages = msg.ToList(),
                temperature = 0 / 7
            };
        }
    }

}

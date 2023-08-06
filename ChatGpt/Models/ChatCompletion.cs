namespace ChatGpt.Models
{
    public class ChatCompletion
    {
        public string id { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }

}

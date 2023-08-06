using ChatGpt.Models;

namespace ChatGpt.Services
{
    class Resquest
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
        public double temperature { get; set; }
    }

}

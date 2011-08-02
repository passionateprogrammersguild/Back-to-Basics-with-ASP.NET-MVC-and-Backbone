using System.ComponentModel;

namespace SpeakerRating.Models
{
    public class Topic
    {   
        [DisplayName("What:")]
        public string Title { get; set; }
        public string Abstract { get; set; }
    }
}
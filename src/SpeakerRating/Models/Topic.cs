using System.ComponentModel;

namespace SpeakerRating.Models
{
    public class Topic
    {   
        [DisplayName("What:")]
        public string Title { get; set; }

        [DisplayName("About:")]
        public string Abstract { get; set; }
    }
}
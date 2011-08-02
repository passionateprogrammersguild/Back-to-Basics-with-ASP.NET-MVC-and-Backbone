using System;
using System.ComponentModel;

namespace SpeakerRating.Models
{
    public class SpeakerEngagement
    {
        public int Rating { get; set; }
        public Speaker Speaker { get; set; }
        
        public SpeakingVenue Venue { get; set; }

        [DisplayName("When:")]
        public DateTime? DateTimeSpeaking { get; set; }
        
        public Topic Topic { get; set; }
    }
}
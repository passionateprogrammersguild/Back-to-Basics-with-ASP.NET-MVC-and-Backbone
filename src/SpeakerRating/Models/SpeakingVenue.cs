using System.ComponentModel;

namespace SpeakerRating.Models
{
    public class SpeakingVenue
    {
        [DisplayName("Where:")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Building { get; set; }
        public string Room { get; set; }
    }
}
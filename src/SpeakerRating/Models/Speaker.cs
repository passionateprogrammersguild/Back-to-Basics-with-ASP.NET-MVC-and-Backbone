using System;
using System.Collections.Generic;
using System.ComponentModel;
using SpeakerRating.Controllers;

namespace SpeakerRating.Models
{
    public class Speaker
    {
        private readonly SpeakerService _service;
        private SpeakerEngagement _nextSpeakingEngagement;
        private IEnumerable<SpeakerEngagement> _pastSpeakingEngagement;

        public Speaker(SpeakerService service)
        {
            _service = service;
        }

        public SpeakerEngagement NextSpeakingDate {
            get
            {
                var result = _nextSpeakingEngagement ?? _service.NextSpeakingEngagementFor(this);
                _nextSpeakingEngagement = result;
                return result;                                  
            }
        }

        public IEnumerable<SpeakerEngagement> PastSpeakingEngagements
        {
            get
            {
                var result = _pastSpeakingEngagement ?? _service.PastSpeakingEngagementFor(this);
                _pastSpeakingEngagement = result;
                return result;
            }
        }

        public string Name { get; set; }

        [DisplayName("Works For:")]
        public string Company { get; set; }        
        public DateTime LastSpeakingDate { get; set; }

        [DisplayName("Speaker Rating:")]
        public int SpeakerRating { get; set; }
        public SpeakingVenue LastSpeakingVenue { get; set; }
        public int? Id { get; set; }
        public string SpeakerImage { get; set; }
        public Uri CompanyWebSite { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerRating.Models;

namespace SpeakerRating.Controllers
{
    public class SpeakerService
    {
        
        public Speakers Find(int? id)
        {
            
            var speakers = GetAllSpeakers(this);

            Func<Speakers> findAll = () => {
                                               var speakerList = new Speakers();                                             
                                               speakerList.AddRange(speakers);
                                               return speakerList;
            };

            Func<Speakers> findSingle = () =>
                                            {
                                                var speakerList = new Speakers();
                                                speakerList.AddRange(speakers.Where(s => s.Id == id).ToList());
                                                return speakerList;
                                            };

            return id.HasValue
                       ? findSingle()
                       : findAll();
        }

        private static IEnumerable<Speaker> GetAllSpeakers(SpeakerService speakerService)
        {
            return new List<Speaker>()
                       {
                           {new Speaker(speakerService) {Id = 1, Name = "Bayer White", SpeakerImage = string.Format("/Content/{0}.jpg", 1), Company = "Flow OnFocus",  CompanyWebSite = new Uri("http://www.flowfocus.com"), LastSpeakingDate = new DateTime(2011, 08, 03, 18,30,0,  DateTimeKind.Local), LastSpeakingVenue = new JaxDugVenue(), SpeakerRating = 5}},
                           {new Speaker(speakerService) {Id = 2, Name = "Michael Mann", Company= "DME Automotive", LastSpeakingDate = new DateTime(2011, 07, 06, 18, 30, 0, DateTimeKind.Local ), SpeakerRating = 3}}
                       };
        }

        public SpeakerEngagement NextSpeakingEngagementFor(Speaker speaker)
        {
            Func<SpeakerEngagement> returnNextEngagementForBayer = () => new SpeakerEngagement()
                                                                             {
                                                                                 Speaker = speaker,
                                                                                 Venue = new JaxDugVenue(),
                                                                                 DateTimeSpeaking = DateTime.Now.AddMonths(1),
                                                                                 Topic = new Topic()
                                                                                             {
                                                                                                 Title = "BizTalk in the cloud",
                                                                                                 Abstract = "BizTalk is awesome"
                                                                                             }
                                                                             };

            Func<SpeakerEngagement> returnNextEngagementForMichael = () => new SpeakerEngagement()
                                                                               {
                                                                                   Speaker = speaker,
                                                                                   Venue = new JaxDugVenue(),
                                                                                   DateTimeSpeaking = DateTime.Now.AddMonths(1),
                                                                                   Topic = new Topic()
                                                                                               {
                                                                                                   Title = "Git WorkFlow with TFS",
                                                                                                   Abstract = "Git is awesome"
                                                                                               }
                                                                               };



            return speaker.Name.Contains("Bayer")
                       ? returnNextEngagementForBayer()
                       : returnNextEngagementForMichael();            
        }
    }
}
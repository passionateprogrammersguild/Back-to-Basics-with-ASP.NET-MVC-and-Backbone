using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerRating.Models;

namespace SpeakerRating.Controllers
{
    public class SpeakerService
    {
        
        public Speaker Find(int id)
        {
            
            var speakers = GetAllSpeakers(this);
            Func<Speaker> findSingle = () =>
                                            {
                                                var speakerList = new Speakers();
                                                return speakers.Where(s => s.Id == id).FirstOrDefault();
                                               
                                            };

            return findSingle();
        }

        public Speakers FindAll()
        {
            var speakers = GetAllSpeakers(this);

            Func<Speakers> findAll = () =>
            {
                var speakerList = new Speakers();
                speakerList.AddRange(speakers);
                return speakerList;
            };

            return findAll();
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
                                                                                 EventId = 100,
                                                                                 Speaker = speaker,
                                                                                 Venue = new JaxDugVenue(),
                                                                                 DateTimeSpeaking = GetEventDateFrom(DateTime.Now.AddMonths(1)),
                                                                                 Topic = new Topic()
                                                                                             {
                                                                                                 Title = "BizTalk in the cloud",
                                                                                                 Abstract = "BizTalk is awesome"
                                                                                             }
                                                                             };

            Func<SpeakerEngagement> returnNextEngagementForMichael = () => new SpeakerEngagement()
                                                                               {
                                                                                   EventId = 101,
                                                                                   Speaker = speaker,
                                                                                   Venue = new JaxDugVenue(),
                                                                                   DateTimeSpeaking = GetEventDateFrom(DateTime.Now.AddMonths(2)),
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

        private static DateTime? GetEventDateFrom(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 18, 0,0,0);
        }

        public IEnumerable<SpeakerEngagement> PastSpeakingEngagementFor(Speaker speaker)
        {
            Func<IEnumerable<SpeakerEngagement>> returnPastEngagementForBayer = () => {
                                                                                        
                var talks = new List<SpeakerEngagement>()
                                {
                                    {new SpeakerEngagement()
                                         {
                                             EventId = 1,
                                             Speaker = speaker,
                                             Venue = new ArchSIGVenue(),
                                             DateTimeSpeaking = new DateTime(2011, 2, 2, 18,0,0,0),
                                             Topic = new Topic()
                                             {
                                                 Title = "From Requirements to Solutions in 60 minutes",
                                                 Abstract = "What are the steps for successfully architecting a solution? What makes software projects successful? Have you heard these questions before? In 60 minutes, Bayer White can show and tell you what makes software projects successful from gathering requirements to providing a stable architecture! This presentation will give you a better idea as to the processes that should be followed and artifacts that should be produced to be make a project 360 degrees successful."
                                             },
                                             Rating = 5                                         
                                         }}
                                };
                return talks;
            };

            Func<IEnumerable<SpeakerEngagement>> returnPastEngagementForMichael = () =>
            {

                var talks = new List<SpeakerEngagement>()
                                {
                                    {new SpeakerEngagement()
                                         {
                                             EventId = 2,
                                             Speaker = speaker,
                                             Venue = new ArchSIGVenue(),
                                             DateTimeSpeaking = new DateTime(2010, 1, 26, 18,0,0,0),
                                             Topic = new Topic()
                                             {
                                                 Title = "TDD for Architects",
                                                 Abstract = "The essence  of the presentation is to show the different aspects of TDD from an Architecture perspective both the good and the not so good.  I will also show an example of doing context specification style of TDD."
                                             },
                                             Rating = 2
                                         }
                                    },
                                    {new SpeakerEngagement()
                                         {
                                             EventId = 3,
                                             Speaker = speaker,
                                             Venue = new ArchSIGVenue(),
                                             DateTimeSpeaking = new DateTime(2010, 4, 28, 18,0,0,0),
                                             Topic = new Topic()
                                             {
                                                 Title = "Architecting for Performance",
                                                 Abstract = "Lessons from the trenches on implementing high-performing applications through queueing."
                                             },
                                             Rating = 4
                                         }}
                                };
                return talks;
            };


            return speaker.Name.Contains("Bayer")
                       ? returnPastEngagementForBayer()
                       : returnPastEngagementForMichael();
        }
    }
}
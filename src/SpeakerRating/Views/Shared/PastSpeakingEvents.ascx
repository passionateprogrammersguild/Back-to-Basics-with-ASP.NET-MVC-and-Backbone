<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.Speaker>" %>
 

    <h3>Past Speaking Event(s):</h3>
      <%=Html.DisplayFor(x => x.PastSpeakingEngagements) %>       
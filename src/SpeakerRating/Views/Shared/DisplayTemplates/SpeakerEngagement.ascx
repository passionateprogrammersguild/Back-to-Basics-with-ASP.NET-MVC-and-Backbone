<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.SpeakerEngagement>" %>
<div class = "speaker-engagement">
    <%=Html.DisplayFor(x => x.Venue) %><br />
    <%=Html.DisplayFor(x => x.Topic) %><br />
    <%=Html.LabelFor(x => x.DateTimeSpeaking)%>
    <%=Html.DisplayFor(x => x.DateTimeSpeaking)%>
</div>
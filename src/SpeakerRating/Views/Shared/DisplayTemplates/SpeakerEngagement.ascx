<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.SpeakerEngagement>" %>
<%@ Import Namespace="SpeakerRating.Controllers" %>
<%@ Import Namespace="SpeakerRating.Models" %>
<script runat="server">
 private bool ShowingAllSpeakers() {
        return ((SpeakerController) ViewContext.Controller).ShowingAllSpeakers();
 }
 private MvcHtmlString ShowEventRatingFor(SpeakerEngagement speakerEvent)
 {
     return Html.Stars(speakerEvent.Rating, new { name = "stars_" + speakerEvent.Speaker.Id + "_" + speakerEvent.EventId, @class = "auto-submit-star" });
 }
</script>
<div class = "speaker-engagement">
    <span class="event-title"><%=Html.DisplayFor(x => x.Topic.Title) %></span>
    <fieldset>
        <%=Html.LabelFor(x => x.Topic.Abstract) %>
        <span style="width:100px;text-align:center">
            <%=Html.DisplayFor(x => x.Topic.Abstract) %>
        </span><br />
        <%=Html.DisplayFor(x => x.Venue) %><br />        
        <%=Html.LabelFor(x => x.DateTimeSpeaking)%>
        <%=Html.DisplayFor(x => x.DateTimeSpeaking)%><br />
         <%if(!this.ShowingAllSpeakers()) {%>
            <div style="float:left;">
                <label>Event Star Rating:</label>
            </div>
            <div style="float:left;">
                <form id="<%=Model.EventId %>" action="Speaker.ascx/Event/<%=Model.EventId %>/Rate" >
                   <%=this.ShowEventRatingFor(Model)%>
                </form>
            </div>
        <%}%>
         
    </fieldset>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.SpeakerEngagement>" %>

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
         <%if(this.ViewContext.RouteData.Values["id"] != null) {%>
            <div style="float:left;">
                <label>Event Star Rating:</label>
            </div>
            <div style="float:left;">
                <%=Html.Stars(Model.Rating, new {name = "stars_" + Model.Speaker.Id + "_" + Model.EventId}) %>
            </div>
        <%}%>
         
    </fieldset>
</div>
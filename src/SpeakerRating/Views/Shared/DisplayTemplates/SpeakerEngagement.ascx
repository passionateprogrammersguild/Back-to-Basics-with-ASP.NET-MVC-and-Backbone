<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.SpeakerEngagement>" %>
<script runat="server">
 private static string ConvertToStars(int speakerRating)
    {
        // Could have also done this in a partial class to seperate out the code from the page but oh well
        //TODO:  write code here to create seach of the stars where each star is indexed as id_star_index
        // Based on the star rating will include colored stars based on that
                
        return string.Format("This event was rated at {0} star(s)", speakerRating);        
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
         <%if(this.ViewContext.RouteData.Values["id"] != null) {%>
            <label>Event Star Rating:</label> <%=ConvertToStars(Model.Rating) %>
        <%}%>
         
    </fieldset>
</div>
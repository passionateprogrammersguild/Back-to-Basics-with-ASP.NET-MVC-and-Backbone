<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.Speaker>" %>
 
<div>
    <h3>Next Speaking Event:</h3>
        <%=Html.DisplayFor(x => x.NextSpeakingDate) %>    
</div>
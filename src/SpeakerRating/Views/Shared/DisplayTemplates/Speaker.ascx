<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.Speaker>" %>
<%@ Import Namespace="SpeakerRating.Controllers" %>
<script runat="server">
    private static string ConvertToStars(int speakerRating)
    {
        // Could have also done this in a partial class to seperate out the code from the page but oh well
        //TODO:  write code here to create seach of the stars where each star is indexed as id_star_index
        // Based on the star rating will include colored stars based on that
                
        return string.Format("This speaker is a {0} star speaker", speakerRating);        
    }
</script>
<div class="speaker">
    <div style="float:left; margin-right:5px;">
        <%=Html.Image(UrlHelper.GenerateContentUrl("~/Content/no-image.gif", Html.ViewContext.HttpContext), new { src = Model.SpeakerImage, title = Model.Name, @class="speaker-icon"})%><br />
    </div>
    <div style="float:left;">
        <%=Html.ActionLink(Model.Name, null, new {Model.Id}) %>
    </div>
    <br />
    
    <%=Html.LabelFor(x => x.Company) %>
    <%=Html.Anchor(Model.Company,  new {href=Model.CompanyWebSite, target="_blank"}) %><br />
    
    <div>       
           Next Speaking Event: 
       <fieldset>
          <%=Html.DisplayFor(x => x.NextSpeakingDate) %>
           Star Rating: <%=ConvertToStars(Model.SpeakerRating) %>    
       </fieldset>
    </div>
</div>
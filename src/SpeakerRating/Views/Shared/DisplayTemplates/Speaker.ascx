<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.Speaker>" %>
 
<script runat="server">
 private static string ConvertToStars(int speakerRating)
    {
        // Could have also done this in a partial class to seperate out the code from the page but oh well
        //TODO:  write code here to create seach of the stars where each star is indexed as id_star_index
        // Based on the star rating will include colored stars based on that
                
        return string.Format("This speaker is a {0} star speaker", speakerRating);        
    }
</script>
<div style="margin-bottom:5px;">
   <%if(this.ViewContext.RouteData.Values["id"] != null) {%>
         <%=Html.ActionLink("<-- Back", "Speakers") %>
   <%}%>
 </div>
<div class="speaker" style="margin-bottom:15px;">
    <div style="float:left; margin-right:5px;">
        <%=Html.Image(UrlHelper.GenerateContentUrl("~/Content/no-image.gif", Html.ViewContext.HttpContext), new { src = Model.SpeakerImage, title = Model.Name, @class="speaker-icon"})%><br />
    </div>
    <div style="float:left;">
        <%=Html.ActionLink(Model.Name, "Speaker", "Speaker", new {Id = Model.Id}, null) %><br />
        <%=Html.LabelFor(x => x.Company) %>
        <%=Html.Anchor(Model.Company,  new {href=Model.CompanyWebSite, target="_blank"}) %><br />
        <%=Html.LabelFor(x => x.SpeakerRating) %>
        <%=ConvertToStars(Model.SpeakerRating)%><br />
    </div>
    
    <div style="clear:all;">
        <%Html.RenderPartial(this.ViewContext.RouteData.Values["id"] == null ? "ListView" : "DetailView", Model);%>
     </div>
</div>
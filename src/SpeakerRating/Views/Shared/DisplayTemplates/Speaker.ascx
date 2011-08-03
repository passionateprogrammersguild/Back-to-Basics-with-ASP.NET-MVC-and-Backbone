<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.Speaker>" %>
<%@ Import Namespace="SpeakerRating.Controllers" %>
<%@ Import Namespace="SpeakerRating.Models" %>
<script runat="server">
    private bool ShowingAllSpeakers()
    {
        return ((SpeakerController) ViewContext.Controller).ShowingAllSpeakers();
    }
    
    private MvcHtmlString ShowSpeakerImageFor(Speaker speaker)
    {
        return Html.Image(UrlHelper.GenerateContentUrl("~/Content/no-image.gif", Html.ViewContext.HttpContext),
                          new {src = speaker.SpeakerImage, title = speaker.Name, @class = "speaker-icon"});
    }

    private MvcHtmlString ShowSpeakerNameFor(Speaker speaker)
    {
        return Html.ActionLink(Model.Name, "Speaker", "Speaker", new {Id = speaker.Id}, null);
    }

    private MvcHtmlString ShowCompanyWebSiteLinkFor(Speaker speaker)
    {
        return Html.Anchor(Model.Company, new {href = Model.CompanyWebSite, target = "_blank"});
    }

    private MvcHtmlString ShowSpeakerRatingFor(Speaker speaker)
    {
        return Html.Stars(Model.SpeakerRating, new {disabled = "disabled", name = "star" + Model.Id});
    }
</script>

<div class="speaker" style="border-color:Black; border-bottom-width:medium;">
<div style="margin-bottom:5px;">
   <%if (!this.ShowingAllSpeakers()) {%>
         <%=Html.ActionLink("<-- Back", "Speakers") %>
   <%}%>
 </div>
<div style="margin-bottom:15px;">
    <div style="float:left; margin-right:5px;">
        <%=this.ShowSpeakerImageFor(Model)%><br />
    </div>
    <div style="float:left;">
        <%=this.ShowSpeakerNameFor(Model) %><br />
        <%=Html.LabelFor(x => x.Company) %>
        <%=this.ShowCompanyWebSiteLinkFor(Model) %><br />
        <div style="float:left;">
            <%=Html.LabelFor(x => x.SpeakerRating) %>
        </div>
        <div style="float:left;">
        <%=this.ShowSpeakerRatingFor(Model)%><br />
        </div>
    </div>
    
    <div style="clear:both;">
        <%Html.RenderPartial(this.ShowingAllSpeakers() ? "NextSpeakingEvent" 
                                                       : "PastSpeakingEvents", Model);%>
     </div>
</div>
</div>
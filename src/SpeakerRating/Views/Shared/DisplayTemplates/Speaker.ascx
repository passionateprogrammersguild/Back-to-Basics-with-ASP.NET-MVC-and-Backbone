<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SpeakerRating.Models.Speaker>" %>

<div class="speaker" style="border-color:Black; border-bottom-width:medium;">
<div style="margin-bottom:5px;">
   <%if(this.ViewContext.RouteData.Values["id"] != null) {%>
         <%=Html.ActionLink("<-- Back", "Speakers") %>
   <%}%>
 </div>
<div style="margin-bottom:15px;">
    <div style="float:left; margin-right:5px;">
        <%=Html.Image(UrlHelper.GenerateContentUrl("~/Content/no-image.gif", Html.ViewContext.HttpContext), new { src = Model.SpeakerImage, title = Model.Name, @class="speaker-icon"})%><br />
    </div>
    <div style="float:left;">
        <%=Html.ActionLink(Model.Name, "Speaker", "Speaker", new {Id = Model.Id}, null) %><br />
        <%=Html.LabelFor(x => x.Company) %>
        <%=Html.Anchor(Model.Company,  new {href=Model.CompanyWebSite, target="_blank"}) %><br />
        <div style="float:left;">
            <%=Html.LabelFor(x => x.SpeakerRating) %>
        </div>
        <div style="float:left;">
        <%=Html.Stars(Model.SpeakerRating, new {disabled="disabled", name="star" + Model.Id})%><br />
        </div>
    </div>
    
    <div style="clear:all;">
        <%Html.RenderPartial(this.ViewContext.RouteData.Values["id"] == null ? "ListView" : "DetailView", Model);%>
     </div>
</div>
</div>
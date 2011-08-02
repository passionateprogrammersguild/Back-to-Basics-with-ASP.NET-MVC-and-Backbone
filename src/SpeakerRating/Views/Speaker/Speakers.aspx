<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<SpeakerRating.Models.Speakers>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="/Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="/Scripts/lib/star-rating/jquery.MetaData.js"></script>
    <script type="text/javascript" src="/Scripts/lib/star-rating/jquery.rating.js"></script>
    <style type="text/css">
        label
        {
            font-weight:bold;
        }
        .event-title 
        {
            font-size: 18px;
            font-weight: bold;
        }
        .speaker-engagement 
        {
            margin-bottom:5px;
        }
    </style>
    <link href="/Scripts/lib/star-rating/jquery.rating.css" type="text/css" rel="Stylesheet" />
</head>
<body>
   <!-- TODO Set the model up to signal the view when it changes -->
   <%=Html.DisplayForModel() %>
   <!-- Get a reference to the controller in the View -->
</body>
</html>

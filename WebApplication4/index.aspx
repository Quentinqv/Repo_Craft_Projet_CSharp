<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication4.Index" %>
<!-- <%@ Register Src="~/header.ascx" TagName="HeaderControl" TagPrefix="THeaderControl"%> -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="assets/css/reset.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.1/css/all.css" integrity="sha384-vp86vTRFVJgpjF9jiIGPEEqYqlDwgyBgEF109VFjmqGmIY/Y4HV4d3Gp2irVfcrp" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <title>Craft - Accueil</title>
</head>
    <body>
        <form id="form1" runat="server">

        <THeaderControl:HeaderControl ID="Header" runat="server"/>

        <div class="file-actualite">
            <div class="each-post" data-idpost='0'>
                <div class="minia-post" style="background-image: url('https://pcorrec.go.yo.fr/Craft/assets/img_posts/img5fda21dec6368.jpg')"></div>
                <div class="top-post">
                    <h3>Mon DIY <asp:Label runat="server" id="namePost"></asp:Label></h3>
                    <div style="display: flex; align-items: center;">
                        <p class="nb_like" style="margin-right: 10px">521</p>
                        <i class="fa fa-heart rouge"></i>
                    </div>
                </div>
                <div class="infos-post">
                    <p>Date de mise en ligne : 01/08/2001</p>
                </div>
                <button>Voir plus</button>
            </div>
            <div class="each-post" data-idpost='0'>
                <div class="minia-post" style="background-image: url('https://pcorrec.go.yo.fr/Craft/assets/img_posts/img5fda21dec6368.jpg')"></div>
                <div class="top-post">
                    <h3>Mon DIY</h3>
                    <div style="display: flex; align-items: center;">
                        <p class="nb_like" style="margin-right: 10px">521</p>
                        <i class="fa fa-heart rouge"></i>
                    </div>
                </div>
                <div class="infos-post">
                    <p>Date de mise en ligne : 01/08/2001</p>
                </div>
                <button>Voir plus</button>
            </div>
        </div>
        </form>
        <script src="assets/script/main.js"></script>
    </body>
</html>

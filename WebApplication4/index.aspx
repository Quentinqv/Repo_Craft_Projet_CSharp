<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication4.Index" %>
<!-- <%@ Register Src="~/WebUserControl1.ascx" TagName="WebControl" TagPrefix="TWebControl"%> -->

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
        <div id="header" style="padding: 5px 5% 5px 5%; display: flex; justify-content: space-between; align-items: center;">
            <asp:HyperLink ID="linkLogo" runat="server" NavigateUrl="~/index.aspx">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.png" Width="259px" />
            </asp:HyperLink>
            <input id="Text1" type="search" class="search-bar" placeholder="Rechercher un post ou un ami.." /><div class="elt-nav">
                <ul ID="BulletedList1" runat="server">
                    <li id="connexionPopup">
                        <asp:HyperLink ID="textMoncompte" runat="server" CssClass="link-header">Mon compte</asp:HyperLink>
                        <div id="divConnexion">
                            <form>
                                <i class="croix-fermer fa fa-xs fa-times"></i>
                                <h4>Connexion</h4>
                                <div class="each-input-connexion">
                                    <label>Pseudo :</label>
                                    <input type="text" id="pseudoConnect" name="pseudo" placeholder="Pseudo..." runat="server">
                                </div>
                                <div class="each-input-connexion">
                                    <label>Mot de passe :</label>
                                    <input type="password" id="passwordConnect" name="password" placeholder="Mot de passe..." runat="server">
                                </div>
                                <p>Mot de passe incorrect !</p>
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click_Connect" Text="Submit" />
                                <asp:HyperLink ID="sinscrireLink" runat="server" CssClass="link-header" NavigateUrl="~/inscription.aspx">S'inscrire !</asp:HyperLink>
                            </form>
                        </div>
                    </li>
                </ul>
        </div>
        </div>
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

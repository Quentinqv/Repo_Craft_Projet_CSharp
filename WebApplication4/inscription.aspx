<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="WebApplication4.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="assets/css/reset.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.1/css/all.css" integrity="sha384-vp86vTRFVJgpjF9jiIGPEEqYqlDwgyBgEF109VFjmqGmIY/Y4HV4d3Gp2irVfcrp" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <title>Craft - Inscription</title>
</head>
<body>
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
                                    <input type="text" name="pseudo" placeholder="Pseudo...">
                                </div>
                                <div class="each-input-connexion">
                                    <label>Mot de passe :</label>
                                    <input type="password" name="password" placeholder="Mot de passe...">
                                </div>
                                <p>Mot de passe incorrect !</p>
                                <button>Se connecter</button>
                                <asp:HyperLink ID="sinscrireLink" runat="server" CssClass="link-header" NavigateUrl="~/inscription.aspx">S'inscrire !</asp:HyperLink>
                            </form>
                        </div>
                    </li>
                </ul>
        </div>
        </div>
     <div>
         <h2>Inscription</h2>
         <form id="formInscription" runat="server">
             <input id="pseudo-form" name="pseudo" placeholder="Pseudo.." required="required" type="text" />
             <input id="email-form" name="email" placeholder="Email.." required="required" type="email" />
             <input id="password1-form" minlength="8" name="password-1" placeholder="Mot de passe.." required="required" type="password" />
             <input id="password2-form" minlength="8" name="password-2" placeholder="Confirmation du mot de passe.." required="required" type="password" />
             <asp:Button ID="Button1" runat="server" Text="S'inscrire" />
         </form>
     </div>
     <script src="assets/script/main.js"></script>
</body>
</html>

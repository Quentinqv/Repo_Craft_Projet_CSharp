<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="WebApplication4.Inscription" %>
<!-- <%@ Register Src="~/header.ascx" TagName="HeaderControl" TagPrefix="THeaderControl"%> -->

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
    <form id="form2" runat="server">
    <THeaderControl:HeaderControl ID="Header" runat="server"/>
         <div runat="server">
             <h2>Inscription</h2>
             <div id="formInscription" runat="server">
                 <input id="pseudoForm" name="pseudo" placeholder="Pseudo.." required="required" type="text" runat="server"/>
                 <input id="emailForm" name="email" placeholder="Email.." required="required" type="email" runat="server"/>
                 <input id="password1Form" minlength="8" name="password-1" placeholder="Mot de passe.." required="required" type="password" runat="server"/>
                 <input id="password2Form" minlength="8" name="password-2" placeholder="Confirmation du mot de passe.." required="required" type="password" runat="server"/>
                 <asp:Button Text="Submit" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
             </div>
         </div>
    </form>
    <script src="assets/script/main.js"></script>
</body>
</html>

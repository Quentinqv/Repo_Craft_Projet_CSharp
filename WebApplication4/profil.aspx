﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profil.aspx.cs" Inherits="WebApplication4.profil" %>
<!-- <%@ Register Src="~/header.ascx" TagName="HeaderControl" TagPrefix="THeaderControl"%> -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="assets/css/reset.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.1/css/all.css" integrity="sha384-vp86vTRFVJgpjF9jiIGPEEqYqlDwgyBgEF109VFjmqGmIY/Y4HV4d3Gp2irVfcrp" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <title>Craft - Profil</title>
</head>
<body>
    <form id="form1" runat="server">
        <THeaderControl:HeaderControl ID="Header" runat="server"/>
        <div id="profil">
            <div id="top-profil">
                <div class="name-profil">
                    <h4><asp:Label runat="server" id="titreNom"></asp:Label></h4>
                    <%
                        HttpContext context = HttpContext.Current;
                        if(context.Session["id"] != null && (string)idCpt != (string)context.Session["id"])
                        {
                    %>
                    <asp:Button Text="Ajouter en ami" ID="addFriend" runat="server" OnClick="addFriend_Click" />
                    <%

                        } else if ((string)idCpt == (string)context.Session["id"])
                        {
                            %>
                            <asp:Button Text="Modifier" ID="modifierCompte" runat="server" OnClick="modifierCompte_Click" />
                            <asp:Button Text="Se déconnecter" ID="disconnect" runat="server" OnClick="disconnect_Click" />
                    <%
                        
                        }
                        %>
                </div>
                <div class="name-profil2">
                    <asp:Label ID="emailCompteId" runat="server"></asp:Label>
                    <asp:Label ID="dateNaisId" runat="server"></asp:Label>
                    <asp:Label ID="telId" runat="server"></asp:Label>
                    <asp:Label ID="dateInscriptionId" runat="server"></asp:Label>
                </div>
                <div class="name-profil">
                    <h6><asp:Label ID="nbPubliId" runat="server"></asp:Label> publications</h6>
                    <h6><asp:Label ID="nbAmisId" runat="server"></asp:Label> amis</h6>
                </div>
            </div>
            <div id="post-profil">
                
            </div>
        </div>
    </form>
    <script src="assets/script/main.js"></script>
</body>
</html>

﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebApplication4.header" %>

<header>
    <div id="header" style="padding: 5px 5% 5px 5%; display: flex; justify-content: space-between; align-items: center;">
        <asp:HyperLink ID="linkLogo" runat="server" NavigateUrl="~/index.aspx">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.png" Width="259px" />
        </asp:HyperLink>
        <input id="Text1" type="search" class="search-bar" placeholder="Rechercher un post ou un ami.." /><div class="elt-nav">
            <ul ID="BulletedList1" runat="server">
                <li id="connexionPopup">
                    <asp:HyperLink id="textMoncompte" runat="server" CssClass="link-header">Mon compte</asp:HyperLink>
                    <div id="divConnexion" runat="server">
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
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click_Connect" Text="Se connecter" />
                            <asp:HyperLink ID="sinscrireLink" runat="server" CssClass="link-header" NavigateUrl="~/inscription.aspx">S'inscrire !</asp:HyperLink>
                        </form>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</header>
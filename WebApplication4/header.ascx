<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebApplication4.header" %>

<header>
    <div id="header" style="padding: 5px 5% 5px 5%; display: flex; justify-content: space-between; align-items: center;">
        <asp:HyperLink ID="linkLogo" runat="server" NavigateUrl="~/index.aspx">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.png" Width="259px" />
        </asp:HyperLink>
        
            <ul ID="BulletedList1" runat="server">
                <li id="connexionPopup">
                    <%
                        HttpContext context = HttpContext.Current;
                        /*Response.Write(context.Session["pseudo"]);*/
                        if (context.Session["pseudo"] == null)
                        {
                    %>
                    <asp:HyperLink id="textMoncompte" runat="server" CssClass="link-header">Mon compte</asp:HyperLink>
                    <div id="divConnexion" runat="server">
                        <div>
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
                        </div>
                    </div>
                    <%
                        }
                        else
                        {
                            /* context.Session["pseudo"] = "monpseudo";
                             Response.Write(context.Session["pseudo"]);*/
                            %>
                    <a id="textMonProfil" class="link-header" href="profil.aspx?id=<% Response.Write(context.Session["id"]); %>">Mon profil</a>
                    <%
                        }
                        %>
                </li>
            </ul>
        </div>
    </div>
</header>
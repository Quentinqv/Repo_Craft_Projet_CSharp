<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="poste.aspx.cs" Inherits="WebApplication4.poste" %>
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
        <div id="postUniq" runat="server">

        </div>
    </form>

    <%
            HttpContext context = HttpContext.Current;
                %>
                <script>
                    $('.fa-heart').on('click', function () {
                        let idCpt = "<% Response.Write(context.Session["id"]); %>"
                        let idPoste = $(this).data('idpost')
                        let current = $(this)

                        $.ajax({
                            type: "POST",
                            url: "index.aspx/LikePost",
                            data: JSON.stringify({ "idCpt": idCpt, "idPoste": idPoste }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                if (response.d == 'like') {
                                    current.parent().find('.nb_like')[0].innerText = parseInt(current.parent().find('.nb_like')[0].innerText) + 1
                                } else {
                                    current.parent().find('.nb_like')[0].innerText = parseInt(current.parent().find('.nb_like')[0].innerText) - 1
                                }
                                current.toggleClass('rouge')
                                current.toggleClass('gris')
                            },
                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                    })
                </script>

    <script src="assets/script/main.js"></script>
</body>
</html>

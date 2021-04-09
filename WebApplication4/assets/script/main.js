$(document).ready(function () {
    $('#Header_textMoncompte').on('click', function () {
        if ($('#Header_divConnexion').css('display') == 'none') {
            $('#Header_divConnexion').slideDown()
            return true
        }
        $('#Header_divConnexion').slideUp()
    })

    $('#Header_divConnexion .croix-fermer').on('click', function () {
        $('#Header_divConnexion').slideUp()
    })
});
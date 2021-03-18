$(document).ready(function () {
    $('#divConnexion').hide()

    $('#textMoncompte').on('click', function () {
        if ($('#divConnexion').css('display') == 'none') {
            $('#divConnexion').slideDown()
            return true
        }
        $('#divConnexion').slideUp()
    })

    $('#divConnexion .croix-fermer').on('click', function () {
        $('#divConnexion').slideUp()
    })
});

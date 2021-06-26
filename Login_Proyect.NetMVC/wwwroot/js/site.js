// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).on('submit', '#Registrar', function (e) {
    //alert(2);
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Registrar button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: '@Url.Action("Registrar")',,//funciona cuando el archivo esta en site.js
        data: $(this).serialize(),
        success: function (data) {
            alert('Usuario registrado con exito !');
        },
        error: function (xhr, status) {
            console.log(xhr);
        },
        complete: function () {
            $('#Registrar button[type=submit]').prop('disabled', false);
        }
    });


})
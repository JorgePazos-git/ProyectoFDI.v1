
jQuery(document).ready(function ($) {

    $('#txtUsuario').focus();
    
    $('#btnEntrar').on('click', function () {

        if ($('#txtUsuario').val() != "" & $('#txtClave').val() != "") {
            Validate($('#txtUsuario').val(), $('#txtClave').val())
        } else {
            Swal.fire(
                'Error',
                'Favor de ingresar Usuario y Contraseña',
                'error'
            );
        }
    });

    function Validate(usuario, clave) {
        var record = {
            user : usuario,
            pass : clave
        };

        $.ajax({
            url: '/Users/GetUsers',
            async: false,
            type: 'POST',
            data: record,
            beforeSend: function (xhr, opts) {
            },
            complete: function () {
            },
            success: function (data) {
                if (data.status == true) {
                    window.location.href = "/Home/Index";
                } else if (data.status == false) {
                    Swal.fire(
                        'Error',
                        data.message,
                        'error'
                    );
                }
            },
            error: function (data) {
                Swal.fire(
                    'Error',
                    data.message,
                    'error'
                );
            }
        });
    }
});


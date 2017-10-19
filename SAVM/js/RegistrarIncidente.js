﻿$(document).ready(function () {
    ListarTipoIncientes();
});

$("#btnBuscarProveedor").click(function (e) {
    e.preventDefault();
    ListarProveedoresIN();
    //Se destruye para evitar error de doble instancia
    var tabla = $("#tblProveedoresIN").DataTable();
    tabla.destroy();
});


function ListarProveedoresIN() {
    $.ajax({
        type: "POST",
        url: "Proveedores.aspx/ListarRepProveedores",
        data: {},
        contentType: "application/json; charset=utf-8",
        success: function (respuesta) {
            console.log(respuesta);
            var data = respuesta.d;
            var btnAgregar = "<button id='btnAgregarProveedor' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
            tabla = $("#tblProveedoresIN").DataTable({

                "pagingType": "numbers",
                "language": {
                    "search": "Buscar: ",
                    "searchPlaceholder": "Ingrese el nombre del medicamento",
                    "lengthMenu": "Mostrar _MENU_ Primeros Resultados",
                }
            });
            tabla.clear();    //Limpia la tabla
            for (var i = 0; i < data.length; i++) {
                tabla.row.add([
                    data[i].Proveedor.RUC,
                    data[i].Proveedor.RazonSocial,
                    data[i].Telefono,
                    data[i].Correo,
                    data[i].Proveedor.Direccion,
                    data[i].Paterno + " " + data[i].Materno + ", " + data[i].Nombre,
                    btnAgregar

                ]).draw();
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        }
    });
}

$("#tblProveedoresIN").on('click', '#btnAgregarProveedor', function (e) {
    e.preventDefault();
    var fila = $(this).closest('tr');
    var ruc = fila.find('td:eq(0)').text();
    $("#txtIdProv").val(fila.find('td:eq(4)').text());
    $("#txtRucProveedor").val(fila.find('td:eq(0)').text());
    $("#txtRazonSocial").val(fila.find('td:eq(1)').text());
    $("#txtContacto").val(fila.find('td:eq(5)').text());  
    $('#modalProveedores').modal('toggle');
    CalcularNroIncidentes(ruc);

});



function CalcularNroIncidentes(ruc) {
    var obj = JSON.stringify({ _ruc: ruc });
    $.ajax({
        type: "POST",
        url: "Proveedores.aspx/CalcularIncidentesProveedor",
        data: obj,
        dataType: "json",
        contentType: "application/json",
        success: function (respuesta) {
            $("#txtNroIncidentes").val(respuesta.d).text();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
        }

    });
}

function ListarTipoIncientes() {
    $.ajax({
        type: "POST",
        url: "RegistrarIncidente.aspx/ListarTipoIncidente",
        data: {},
        contentType: "application/json",
        success: function (respuesta) {
            var data = respuesta.d;
            $('#ddlTipoIncidencia').empty();
            for (var i = 0; i < data.length; i++)
            {
                $('#ddlTipoIncidencia').append(
                    "<option>" + data[i].Descripcion + "</option>"
                    );
            }
        }
    });
}
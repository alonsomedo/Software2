$("#btnBuscarProveedor").click(function (e) {
    e.preventDefault();
    ListarProveedoresIN();
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
            tabla = $("#tblProveedoresIN").DataTable();
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
    $("#txtrucOC").val(fila.find('td:eq(0)').text());
    $("#txtrazonsocialOC").val(fila.find('td:eq(1)').text());
    $("#txtcontactoOC").val(fila.find('td:eq(5)').text());
    $('#modalProveedores').modal('toggle');
});

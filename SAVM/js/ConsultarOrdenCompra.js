
$(document).ready(function () {


    var tabla = $("#tblOrdenCompra").DataTable({
        dom: 'BLrtip',
        buttons: [
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: [0, ':visible']
                }
            },
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns:  [0, 1, 2, 3, 4, 5]
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                }
            }
        ],
        //"dom": 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        pagingType: "numbers",
        language: {
            search: "Buscar: ",
            searchPlaceholder: "Ingrese el nombre del medicamento",
            lengthMenu: "Mostrar _MENU_ Primeros Resultados",
        }
    });

    $('#txtFilterOC').on('keyup', function () {
        tabla.search(this.value).draw();
    });

    function ListarOC() {
        $.ajax({
            type: "POST",
            url: "ConsultarOrdenCompra.aspx/ListarOrdenCompra",
            data: {},
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                console.log(respuesta);
                var data = respuesta.d;
                var btnAgregar = "<button id='btnAgregarProveedor' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";   
                tabla.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    tabla.row.add([
                        data[i].CodOrdCompra,
                        data[i].FecOrdCompra,
                        data[i].Igv,
                        data[i].Total,
                        data[i].Proveedor.RUC,
                        data[i].Proveedor.RazonSocial,
                        btnAgregar
                    ]).draw();
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }

    ListarOC();



});


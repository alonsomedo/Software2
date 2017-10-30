
$(document).ready(function () {


    var tabla = $("#tblOrdenCompra").DataTable({
        dom: 'BLrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
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
        paging: true,
        pagingType: "numbers",
        language: {
            search: "Buscar: ",
            searchPlaceholder: "Ingrese el nombre del medicamento",
            
            lengthMenu: "Mostrar _MENU_ Primeros Resultados",
            info: "Mostrando página _PAGE_ de _PAGES_"
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
                var btnDetalleOC = "<button id='btnDetalleOC' type='button' class='btn btn-success btn-md' style='color:white;'>Ver</button>";
                tabla.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    tabla.row.add([
                        data[i].CodOrdCompra,
                        data[i].FecOrdCompra,
                        data[i].Igv,
                        data[i].Total,
                        data[i].Proveedor.RUC,
                        data[i].Proveedor.RazonSocial,
                        btnDetalleOC
                    ]).draw();
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }

    ListarOC();


    $("#tblOrdenCompra").on("click", "btnDetalleOC", function (e) {
        var fila = $(this).closest("tr");
        var codigoOC = $(fila.find("td:eq(0)").text());


    });



});


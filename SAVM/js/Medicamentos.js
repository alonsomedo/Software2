$(document).ready(function () {



    ListarMedicamentos();


    var tabla = $("#tblMedicamentos").DataTable({
        dom: 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        paging: false, //Inhabilitamos paginación
        pagingType: "numbers",
        info: false,
        language: {
            //search: "Buscar: ",
            //searchPlaceholder: "Ingrese el nombre del proveedor",
            //lengthMenu: "Mostrar _MENU_ Primeros Resultados",
            //paging: false
            //info: "Mostrando página _PAGE_ de _PAGES_"
        }

    });

    function ListarMedicamentos() {
        $.ajax({
            type: "POST",
            url: "Medicamentos.aspx/ListarMedicamento",
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                console.log(respuesta);
                var data = respuesta.d;
                var btnEditar = "<button id='btnEditarMedicamento' type='button' class='btn btn-success btn-md' style='color:white;'>Editar</button>";
                var btnEliminar = "<button id='btnEliminarMedicamento' type='button' class='btn btn-danger btn-md' style='color:white;'>Eliminar</button>";
                tabla.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    tabla.row.add([
                        data[i].CodMedicamento,
                        data[i].Descripcion,
                        data[i].PrecioCompra,
                        data[i].PrecioVenta,
                        data[i].Stock,
                        data[i].StockMinimo,
                        data[i].FechaVencimiento,   
                        data[i].TipoMedicamento.Descripcion,
                        data[i].Proveedor.RazonSocial,
                        btnEditar,
                        btnEliminar
                    ]).draw();
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }






});
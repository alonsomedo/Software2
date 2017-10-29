$(document).ready(function () {

    $("#btnGrabar").click(function (e) {
        e.preventDefault();
        var flag = ValidarCampos();
        if (flag) {
            RegistrarFacturaAJAX();
            //RegistrarDetalleFactura();
            //swal('La venta se grabó exitosamente', '',
            //    'success'
            //);
            //PrintModal();
            //Limpiar();
        }
    });

    function RegistrarFacturaAJAX() {

        var obj = JSON.stringify({
            _codFactura: $("#txtNumeroFactura").val(),
            _fecha: $("#txtFecha").val(),
            _ruc: $("#txtRucProveedor").val(),
            _total: $('#txtmontototal').val()
        });

        $.ajax({
            type: "POST",
            url: "RegistrarFactura.aspx/RegistrarFacturaProveedor",
            data: obj,
            dataType: "json",
            async: false,
            contentType: "application/json",
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
                resultado = false;
            },
            success: function (respuesta) {
                console.log(respuesta.d)
            }
        });
    }

    function RegistrarDetalleFactura() {
        $("#tabladetalleventa tr").each(function () {
            var fila = $(this).closest('tr');
            var precio = Number(fila.find('td:eq(2)').text());
            var cantidad = Number(fila.find('td:eq(3)').text());
            var subtotal = Number(fila.find('td:eq(4)').text());
            var codmedicamento = fila.find('td:eq(0)').text();
            var codventa = $("#txtnumventa").val();
            RegistrarDetalleAJAX(precio, cantidad, subtotal, codmedicamento, codventa);
        });
    }

    function RegistrarDetalleAJAX(precio, cantidad, subtotal, codmedicamento, codventa) {
        var obj = JSON.stringify({
            _precio: precio,
            _cantidad: cantidad,
            _subtotal: subtotal,
            _codmedicamento: codmedicamento,
            _codventa: codventa
        });
        $.ajax({
            type: "POST",
            url: "GenerarVenta.aspx/RegistrarDetalleVenta",
            data: obj,
            dataType: "json",
            async: false,
            contentType: "application/json",
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
            },
            success: function (respuesta) {
            }
        });
    }


    function ValidarCampos() {
        if ($("#txtRucProveedor").val() == "" || $("#txtRazonSocial").val() == "") {
            swal('Ingresa datos del proveedor', '',
                'error'
            );
            return false;
        }
        if ($("#txtNumeroFactura").val() == "")
        {
            swal('Ingrese el N° de Factura a Registrar', '',
                'info'
            );
        }
        var filas = Number($('#tblBodyDetalleFactura tr').length);
        if (filas <= 0) {
            swal('Agregue al menos un medicamento a la grilla', '',
                'info'
            );
            return false;
        }
        return true;
    }



    $("#btnBuscarMedicamentos").click(function (e) {
        e.preventDefault();
        ListarMedicamentos();
        //Se destruye para evitar error de doble instancia
        var tablaMedicamentos = $("#tblMedicamentos").DataTable();
        tablaMedicamentos.destroy();
    });

    $("#tblMedicamentos").on("click", "#btnAgregarMedicamento", function (e) {
        var fila = $(this).closest("tr");
        $("#txtCodMedicamento").val(fila.find('td:eq(0)').text());
        $("#txtNomMedicamento").val(fila.find('td:eq(1)').text());
        $("#modalMedicamentos").modal("toggle");
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
                var btnAgregar = "<button id='btnAgregarMedicamento' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
                tablaMedicamentos = $("#tblMedicamentos").DataTable({

                    "pagingType": "numbers",
                    "language": {
                        "search": "Buscar: ",
                        "searchPlaceholder": "Ingrese el nombre del medicamento",
                        "lengthMenu": "Mostrar _MENU_ Primeros Resultados",
                    }
                });
                tablaMedicamentos.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    tablaMedicamentos.row.add([
                        data[i].CodMedicamento,
                        data[i].Descripcion,
                        data[i].PrecioVenta,
                        data[i].Stock,
                        data[i].FechaVencimiento,
                        data[i].TipoMedicamento.Descripcion,
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


    $("#btnBuscarProveedor").click(function (e) {
        e.preventDefault();
        ListarProveedores();
        //Se destruye para evitar error de doble instancia
        var tabla = $("#tblProveedores").DataTable();
        tabla.destroy();
    });


    $("#tblProveedores").on('click', '#btnAgregarProveedor', function (e) {
        e.preventDefault();
        var fila = $(this).closest('tr');
        $("#txtRucProveedor").val(fila.find('td:eq(0)').text());
        $("#txtRazonSocial").val(fila.find('td:eq(1)').text());
        $("#modalProveedores").modal('toggle');


    });



    function ListarProveedores() {
        $.ajax({
            type: "POST",
            url: "Proveedores.aspx/ListarRepProveedores",
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                console.log(respuesta);
                var data = respuesta.d;
                var btnAgregar = "<button id='btnAgregarProveedor' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
                tabla = $("#tblProveedores").DataTable({

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


    $('body').on('click', '#btnAgregar', function (e) {
        if ($("#txtCantidad").val() == "" || $("#txtCantidad").val()<1)
        {
            swal('Ingrese cantidad de medicamento', '',
                'warning'
            );
            return false;
        }
        if ($("#txtPrecio").val()=="")
        {
            swal('Ingrese precio de medicamento', '',
                'warning'
            );
            return false;
        }
        var codMedicamento = $("#txtCodMedicamento").val();
        var medicamento = $("#txtNomMedicamento").val();
        var precio = $("#txtPrecio").val();
        var cantidad = $("#txtCantidad").val();
        var total = Number(precio) * Number(cantidad);
        var btnAgregar = "<button id='btnEliminarDetalle' type='button' class='btn btn-success btn-md' style='color:white;'>Eliminar</button>";
        $('#tblDetalleFactura').append("<tr>" +
            "<td>" + codMedicamento + "</td>" +
            "<td>" + medicamento + "</td>" +
            "<td>" + precio + "</td>" +
            "<td>" + cantidad + "</td>" +
            "<td>" + total + "</td>" +
            "<td>" + btnAgregar + "</td>" +
            "</tr > ");
        ActualizarMontosSumar(total);
        Limpiar();
    });

    function Limpiar() {
        $("#txtCodMedicamento").val("");
        $("#txtNomMedicamento").val("");
        $("#txtPrecio").val("");
        $("#txtCantidad").val("");
    }

    $("#tblDetalleFactura").on("click", "#btnEliminarDetalle", function (e) {

        var respuesta = confirm("¿Está seguro de eliminar el medicamento de la grilla?");
        if (respuesta == true) {
            var fila = $(this).closest('tr');
            fila.remove();
            var monto = Number(fila.find('td:eq(4)').text());
            ActualizarMontosRestar(monto);
        }

    });


    function ActualizarMontosRestar(monto) {
        var anterior = $("#txtmontototal").val();
        if (anterior == "") {
            anterior = "0";
        }
        $("#txtmontototal").val((Number(anterior) - Number(monto)).toFixed(2));
    }

    function ActualizarMontosSumar(monto) {
        var anterior = $("#txtmontototal").val();
        if (anterior == "") {
            anterior = "0";
        }
        $("#txtmontototal").val((Number(anterior) + Number(monto)).toFixed(2));
    }


});
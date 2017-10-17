
$(document).ready(function () {
	var hoy = new Date();
	var dia = hoy.getDate();
	var mes = hoy.getMonth() + 1;
	var year = hoy.getFullYear();

	if (dia < 10) {
		dia = '0' + dia
	}

	if (mes < 10) {
		mes = '0' + mes
	}

	hoy = dia + '/' + mes + '/' + year;

	$("#txtfechaOC").val(hoy);
});

function ObtenerNroOC() {
	$.ajax({
		type: "POST",
		url: "GenerarOrdenCompra.aspx/GenerarNroOC",
		data: {},
		async: false,
		contentType: "application/json",
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
		},
		success: function (respuesta) {
			$("#txtnumocOC").val(respuesta.d);
		}
	});
}

$('body').on('click', '#btnAgregarOC', function (e) {

	if ($("#txtcodmedicamentoOC").val() == "") {
		alert("Busque el medicamento a agregar");
		return false;
	}
	var _cantidad = $("#txtcantidadOC").val().indexOf(".");
	if ($("#txtcantidadOC").val() == "" || Number($("#txtcantidadOC").val()) < 1 || _cantidad != -1) {
		alert("Ingrese la cantidad del medicamento");
		return false;
	}
	var codmedicamento = $("#txtcodmedicamentoOC").val();
	var medicamento = $("#txtnombreOC").val();
	var precio = $("#txtprecioOC").val();
	var cantidad = $("#txtcantidadOC").val();
	var subtotal = parseFloat(precio * cantidad).toFixed(2);
	var botonEliminar = "<button id='btnEliminarOC' type='button' class='btn btn-danger btn-md' style='color:white;'>Eliminar</button>";
	$('#tableDetalleBodyOC').append("<tr>" +
		"<td>" + codmedicamento + "</td>" +
		"<td>" + medicamento + "</td>" +
		"<td>" + precio + "</td>" +
		"<td>" + cantidad + "</td>" +
		"<td>" + subtotal + "</td>" +
		"<td>" + botonEliminar + "</td>" +
		"</tr > ");
	ActualizarMontosSumarOC(subtotal);
	$("#txtcodmedicamentoOC").val("");
	$("#txtnombreOC").val("");
	$("#txtprecioOC").val("");
	$("#txtcantidadOC").val("");
});

function ActualizarMontosSumarOC(subtotal) {
	var anterior = $("#txtmontototalOC").val();
	if (anterior == "") {
		anterior = "0";
	}
	$("#txtmontototalOC").val((Number(anterior) + Number(subtotal)).toFixed(2));
	calcularIGVMontoOC($("#txtmontototalOC").val());
}

$('#tableDetalleBodyOC').on('click', '#btnEliminarOC', function () {
	var respuesta = confirm("¿Está seguro de eliminar el medicamento de la grilla?");
	if (respuesta == true) {
		var fila = $(this).closest('tr');
		fila.remove();
		var subtotal = Number(fila.find('td:eq(4)').text());
		ActualizarMontosRestarOC(subtotal);
	}
});

function ActualizarMontosRestarOC(subtotal) {
	var anterior = $("#txtmontototalOC").val();
	if (anterior == "") {
		anterior = "0";
	}
	$("#txtmontototalOC").val((Number(anterior) - Number(subtotal)).toFixed(2));
	calcularIGVMontoOC($("#txtmontototalOC").val());
}

function calcularIGVMontoOC(monto) {
	var monto_sin_igv = (monto * 0.82).toFixed(2);
	var igv = (monto * 0.18).toFixed(2);
	$("#txtmontoOC").val(monto_sin_igv);
	$("#txtigvOC").val(igv)
}

function RegistrarOCAJAX() {

	var resultado = false;

	var obj = JSON.stringify({
		_CodOc: $("#txtnumocOC").val(),
		_FecOC: $("#txtfechaOC").val(),
		_Igv: $("#txtigvOC").val(),
		_Total: $('#txtmontototalOC').val(),
		_Ruc: $('#txtrucOC').val()
	});

	$.ajax({
		type: "POST",
		url: "GenerarOrdenCompra.aspx/RegistrarOC",
		data: obj,
		dataType: "json",
		async: false,
		contentType: "application/json",
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
			resultado = false;
		},
		success: function (respuesta) {
			//alert("Venta Registrada");
			console.log(respuesta);
			resultado = true;
		}
	});
	return resultado;
}

function RegistrarDetalleOC() {
	$("#tableDetalleBodyOC tr").each(function () {
		var fila = $(this).closest('tr');
		var precio = Number(fila.find('td:eq(2)').text());
		var cantidad = Number(fila.find('td:eq(3)').text());
		var subtotal = Number(fila.find('td:eq(4)').text());
		var codmedicamento = fila.find('td:eq(0)').text();
		var codoc = $("#txtnumocOC").val();
		RegistrarDetalleAJAXOC(precio, cantidad, subtotal, codmedicamento, codoc);
	});
}

function RegistrarDetalleAJAXOC(precio, cantidad, subtotal, codmedicamento, codoc) {
	var obj = JSON.stringify({
		_precio: precio,
		_cantidad: cantidad,
		_subtotal: subtotal,
		_codmedicamento: codmedicamento,
		_codoc: codoc
	});
	$.ajax({
		type: "POST",
		url: "GenerarOrdenCompra.aspx/RegistrarDetalleOC",
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

function ValidarCamposOC() {
	if ($("#txtrucOC").val() == "" || Number($("#txtrucOC").val()) < 1 || $("#txtrazonsocialOC").val() == "") {
		alert("Busque el proveedor para la Orden de Compra");
		return false;
	}
	var filas = Number($('#tableDetalleBodyOC tr').length);
	if (filas <= 0) {
		alert("Agrege al menos un medicamento a la grilla");
		return false;
	}
	
	return true;
}

function LimpiarOC() {
	$("#txtnumocOC").val("");
	$("#txtrucOC").val("");
	$("#txtrazonsocialOC").val("");
	$("#txtcontactoOC").val("");
	$("#txtcodmedicamentoOC").val("");
	$("#txtnombreOC").val("");
	$("#txtprecioOC").val("");
	$("#txtcantidadOC").val("");
	$("#txtmontoOC").val("");
	$("#txtigvOC").val("");
	$("#txtmontototalOC").val("");
	$("#tableDetalleBodyOC").empty();
}

$("#btnBuscarMedicamentoOC").click(function (e) {
	e.preventDefault();
	ListarMedicamentosVentaOC();
});

function ListarMedicamentosVentaOC() {
	$.ajax({
		type: "POST",
		url: "Medicamentos.aspx/ListarMedicamento",
		data: {},
		contentType: "application/json",
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
		},
		success: function (respuesta) {
			var data = respuesta.d;
			$("#tablaMedicamentosOC").empty();
			var btnAgregar = "<button id='btnAgregarMedicamentoOC' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
			for (var i = 0; i < data.length; i++) {
				$("#tablaMedicamentosOC").append("<tr>" +
					"<td>" + data[i].CodMedicamento + "</td>" +
					"<td>" + data[i].Descripcion + "</td>" +
					"<td>" + data[i].PrecioVenta + "</td>" +
					"<td>" + data[i].Stock + "</td>" +
					"<td>" + data[i].FechaVencimiento + "</td>" +
					"<td>" + data[i].TipoMedicamento.Descripcion + "</td>" +
					"<td>" + data[i].Proveedor.RazonSocial + "</td>" +
					"<td>" + btnAgregar + "</td>" +
					"</tr > ");
			}
		}
	});
}

$("#tablaMedicamentosOC").on('click', '#btnAgregarMedicamentoOC', function (e) {
	e.preventDefault();
	var fila = $(this).closest('tr');
	$("#txtcodmedicamentoOC").val(fila.find('td:eq(0)').text());
	$("#txtnombreOC").val(fila.find('td:eq(1)').text());
	$("#txtprecioOC").val(fila.find('td:eq(2)').text());
	$('#modalMedicamentosOC').modal('toggle');
});

$("#btnBuscarProveedor").click(function (e) {
	e.preventDefault();
	ListarProveedoresOC();
});

function ListarProveedoresOC() {
	$.ajax({
		type: "POST",
		url: "Proveedores.aspx/ListarProveedores",
		data: {},
		contentType: "application/json",
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
		},
		success: function (respuesta) {
			var data = respuesta.d;
			$("#tablaProveedoresModal").empty();
			var btnAgregar = "<button id='btnAgregarProveedorLista' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
			for (var i = 0; i < data.length; i++) {
				$("#tablaProveedoresModal").append("<tr>" +
					"<td>" + data[i].Proveedor.RUC + "</td>" +
					"<td>" + data[i].Proveedor.RazonSocial + "</td>" +
					"<td>" + data[i].Telefono + "</td>" +
					"<td>" + data[i].Correo + "</td>" +
					"<td>" + data[i].Proveedor.Direccion + "</td>" +
					"<td>" + data[i].Paterno + " " + data[i].Materno + ", " + data[i].Nombre + "</td>" +
					"<td>" + btnAgregar + "</td>" +
					"</tr > ");
			}
		}
	});
}

$("#tablaProveedoresModal").on('click', '#btnAgregarProveedorLista', function (e) {
	e.preventDefault();
	var fila = $(this).closest('tr');
	$("#txtrucOC").val(fila.find('td:eq(0)').text());
	$("#txtrazonsocialOC").val(fila.find('td:eq(1)').text());
	$("#txtcontactoOC").val(fila.find('td:eq(5)').text());
	$('#modalProveedores').modal('toggle');
});

$("#btnGrabarOC").click(function (e) {
	e.preventDefault();

	var flag = ValidarCamposOC();
	var resultado = false;
	if (flag) {
		ObtenerNroOC();
		RegistrarOCAJAX();
		alert("La Orden de Compra se grabó exitosamente");
		RegistrarDetalleOC();
		PrintModal();
		LimpiarOC();
	}
});

function PrintModal() {
	var codOC = $("#txtnumocOC").val();
	var razonSocial = $("#txtrazonsocialOC").val();
	var RUC = $("#txtrucOC").val();
	var monto = $("#txtmontoOC").val();
	var igv = $("#txtigvOC").val();
	var montototal = $("#txtmontototalOC").val();
	$("#txtRS").val(razonSocial);
	$("#txtRuc").val(RUC);
	$("#txtPrtMonto").val(monto);
	$("#txtPrtIgv").val(igv);
	$("#txtPrtMontoTotal").val(montototal);
	$("#nroOC").text(codOC);
	copiarTablaDetalle('tableDetalleBodyOC', 'prtTableDetalleOC', 0, 1, 2, 3, 4)
	$("#printOC").printThis();
	$("#prtTableDetalleOC").empty();
};


//Copia la tabla detalle a la tabla del modal
function copiarTablaDetalle(sourceTableId, targetTableId) {
	var colNos = [].slice.call(arguments, 2),
		$target = $("#" + targetTableId);
	$("#" + sourceTableId + " tr").each(function () {
		var $tds = $(this).children(),
			$row = $("<tr></tr>");
		for (var i = 0; i < colNos.length; i++)
			$row.append($tds.eq(colNos[i]).clone());
		$row.appendTo($target);
	});
};
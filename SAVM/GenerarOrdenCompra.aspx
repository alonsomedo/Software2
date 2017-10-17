<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GenerarOrdenCompra.aspx.cs" ClientIDMode="Static"
	Inherits="SAVM.GenerarOrdenCompra" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content_GOC" ContentPlaceHolderID="MainContent" runat="server">
	<header class="titulo">
        <div class="container-fluid">
            <h2 style="text-align: left"><strong>Generar Orden de Compra</strong></h2>
        </div>
    </header>
	<div class="container-fluid">
		<br>
			<div class="row">
					<fieldset class="col-md-6">
						<legend>Datos de Proveedor</legend>
						RUC:
						<div class="row">
							<div class="col-md-6">
							<input type="text" class="form-control" id="txtrucOC" disabled>
							</div>
							<div class="col-md-6">
								<button type="button" class="btn btn-primary" id="btnBuscarProveedor"
									data-toggle="modal" data-target="#modalProveedores" >Buscar Proveedor
									</button>
							</div>
						</div><br>
						Razón Social:
						<div class="row">
							<div class="col-md-6">
							<input type="text" class="form-control" id="txtrazonsocialOC" disabled>
							</div>
							<div class="col-md-6">
								<input type="button" class="btn btn-primary" value="Registrar Proveedor">
							</div>
						</div><br>
						Contacto:
						<input type="text" class="form-control" id="txtcontactoOC" disabled><br><br>
					</fieldset>

					<fieldset class="col-md-6">
						<legend>Datos del Medicamento</legend>
						Código:
						<div class="row">
							<div class="col-md-6">
							<input type="text" class="form-control" id="txtcodmedicamentoOC" disabled>
							</div>
							<div class="col-md-6">
								<button type="button" class="btn btn-primary" id="btnBuscarMedicamentoOC"
									data-toggle="modal" data-target="#modalMedicamentosOC" >Buscar Medicamento
									</button>
							</div>
						</div>
						Nombre:
						<div class="row">
							<div class="col-md-6">
							<input type="text" class="form-control" id="txtnombreOC" disabled>
							</div>
							<div class="col-md-6">
								<input type="button" class="btn btn-primary" value="Registrar Medicamento">
							</div>
						</div>
						Precio Unit.:
						<div style="width:100px">
						<input type="number" class="form-control" id="txtprecioOC" disabled>
						</div>
						Cantidad:
						<div class="row">
							<div class="col-md-3">
							<input type="number" class="form-control" id="txtcantidadOC">
							</div>
							<div class="col-md-6 col-md-offset-3">
								<input type="button" class="btn btn-primary" value="Agregar Medicamento" id="btnAgregarOC">
							</div>
						</div>
						<br>
					</fieldset>
			</div><br>	
			<div class="row">
			<fieldset>
				<legend>Datos de la O/C</legend>
				<div class="row">
					<div class="col-md-8 form-inline">
						<label for="txtnumocOC">N° de O/C:</label>&nbsp;&nbsp;&nbsp;
						<input type="text" class="form-control" style="width: 100px" id="txtnumocOC" disabled>
					</div>
						
					<div  class="form-inline col-md-4">
						<label for="txtfechaOC">Fecha:</label>&nbsp;&nbsp;&nbsp;
						<input type="text" class="form-control" id="txtfechaOC" disabled>
					</div>
				</div><br>
	
				<table class="table">
					<thead>
						<tr>
							<td>Medicamento</td>
							<td>PUnitario</td>
							<td>Cantidad</td>
							<td>Subtotal</td>
							<td>Eliminar</td>	
						</tr>
					</thead>
					<tbody id="tableDetalleBodyOC">

					</tbody>
				</table>
				<br><br><br><br>
				<div class="col-md-offset-9 col-md-2">
						Monto:
						<input type="number" class="form-control" id="txtmontoOC" disabled>
						I.G.V(18%):
						<input type="number" class="form-control" id="txtigvOC" disabled>
						Monto Total:
						<input type="number" class="form-control" id="txtmontototalOC" disabled><br>
				</div>
			</fieldset>
			</div><br>
			<div class="row">
				<div class="col-md-1">
					<input type="button" class="btn btn-primary" value="Volver" onClick="location.href='/Index.aspx'">
				</div>
				<div class="col-md-6">
					<input type="button" class="btn btn-success" value="Grabar e Imprimir" id="btnGrabarOC">
				</div><br><br>
			</div>
       </div>

		
		<!-- Modal Medicamentos-->
		<div class="modal fade" id="modalMedicamentosOC" role="dialog">
			<div class="modal-dialog">
				<div class="modal-content modal-lg" style="overflow:auto;height:600px">
					<!-- Modal Header -->
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal">
							<span aria-hidden="true">×</span>
							<span class="sr-only">Close</span>
						</button>
						<h4 class="modal-title">Medicamentos</h4>
					</div>
            
					<!-- Modal Body -->
					<div class="modal-body">
						<p class="statusMsg"></p>
                			<input type="text" placeholder="Ingrese criterio de búsqueda" class="form-control" id="txtBuscarMedicamentoOC">
							<br>
							<table class="table table-bordered">
								<thead>
                    				<tr>
										<td>Cod. Med</td>
										<td>Medicamento</td>
										<td>Precio</td>
										<td>Stock</td>
										<td>Fec. Venc</td>
										<td>Tipo</td>
										<td>Proveedor</td>
										<td>Opción</td>
									</tr>
								</thead>
								<tbody id="tablaMedicamentosOC">

								</tbody>
							</table>
					</div>
            
					<!-- Modal Footer -->
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
					</div>
				</div>
			</div>
		</div>

		<!-- Modal Proveedores-->
		<div class="modal fade" id="modalProveedores" role="dialog">
			<div class="modal-dialog">
				<div class="modal-content modal-lg" style="overflow:auto;height:600px">
					<!-- Modal Header -->
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal">
							<span aria-hidden="true">×</span>
							<span class="sr-only">Close</span>
						</button>
						<h4 class="modal-title">Proveedores</h4>
					</div>
            
					<!-- Modal Body -->
					<div class="modal-body">
						<p class="statusMsg"></p>
                			<input type="text" placeholder="Ingrese criterio de búsqueda" class="form-control" id="txtBuscarProveedor">
							<br>
							<table class="table table-bordered">
								<thead>
                    				<tr>
                        				<td>RUC</td>
										<td>Razón Social</td>
										<td>Telefono</td>
										<td>Correo</td>
										<td>Dirección</td>
										<td>Contacto</td>
									</tr>
								</thead>
								<tbody id="tablaProveedoresModal">

								</tbody>
							</table>
					</div>
            
					<!-- Modal Footer -->
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
					</div>
				</div>
			</div>
		</div>

	<!--Start Modal: Imprimir -->
    <div class="modal fade" id="modalPrintOC" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title" id="modalNroOC"></h4>
                </div>
                <div class="modal-body" id="printOC">

                    <h2>ORDEN DE COMPRA NÚMERO:<label id="nroOC"></label></h2>
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="txtRS">Razón Social</label>
                            <input type="text" id="txtRS" class="form-control" name="nombrecliente" value="" />
                        </div>
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="txtRuc">RUC</label>
                            <input type="number" id="txtRuc" class="form-control" name="idcliente" value="" />
                        </div>
                    </div>
                    <div>
                        <h4>DETALLE DE VENTA </h4>
                        <br />
                        <table id="prtTableDetalleOC" class="table table-bordered table-hover">
                        </table>
                    </div>
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label for="txtPrtMonto">MONTO S/.</label>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <input class="form-control" type="text" id="txtPrtMonto" name="prtmonto" value="" />
                            </div>

                        </div>
                        <div class="form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label for="txtPrtIgv">IGV</label>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <input class="form-control" type="text" id="txtPrtIgv" name="prtigv" value="" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label for="txtPrtMontoTotal">MONTO TOTAL S/.</label>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <input class="form-control" type="text" id="txtPrtMontoTotal" name="prtmontototal" value="" />
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- End Modal: Imprimir -->


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="footer" runat="server">
    <script src="js/GenerarOrdenCompra.js"></script>
	<script src="plugins/printThis.js"></script>
</asp:Content>
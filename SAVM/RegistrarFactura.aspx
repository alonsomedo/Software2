<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistrarFactura.aspx.cs" Inherits="SAVM.RegistrarFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
		<br>
			<div class="row">
					<fieldset class="col-md-6">
						<legend>Datos del Proveedor</legend>
						RUC
						<div class="row">
							<div class="col-md-7">
							<input type="number" class="form-control">
							</div>
							<div class="col-md-4">
							<input type="button" class="form-control btn btn-primary" value="Buscar Proveedor">
							</div>
						</div>
                        <br>
						Razón Social:
						<div class="row">
							<div class="col-md-7">
							<input type="text" class="form-control">
							</div>
						</div><br>
					</fieldset>

					<fieldset class="col-md-6">
						<legend>Datos del Medicamento</legend>
						Medicamento:
						<div class="row">
							<div class="col-md-6">
							<input type="text" class="form-control">
							</div>
							<div class="col-md-6">
								<input type="button" class="btn btn-primary" value="Buscar Medicamento">
							</div>
						</div>
						Precio:
						<div style="width:100px">
						<input type="text" class="form-control" >
						</div>
						Cantidad:
						<div class="row">
							<div class="col-md-3">
							<input type="text" class="form-control">
							</div>
							<div class="col-md-6 col-md-offset-3">
								<input type="button" class="btn btn-primary" value="Agregar Medicamento">
							</div>
						</div>
						<br>
					</fieldset>
			</div><br>	
			<div class="row">
			<fieldset>
				<legend>Datos de la Factura</legend>
				<div class="row">
					<div class="col-md-8 form-inline">
						<label>N° de la Factura:</label>&nbsp;&nbsp;&nbsp;
						<input type="text" class="form-control" style="width: 100px">
					</div>
						
					<div  class="form-inline col-md-4">
						<label for="">Fecha:</label>&nbsp;&nbsp;&nbsp;
						<input type="date" class="form-control">
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
				</table>
				<br><br><br><br>
				<div class="col-md-offset-9 col-md-2">
						Monto Total:
						<input type="text" class="form-control"><br>
				</div>
			</fieldset>
			</div><br>
			<div class="row">
				<div class="col-md-1">
					<input type="button" class="btn btn-primary" value="Volver">
				</div>
				<div class="col-md-6">
					<input type="button" class="btn btn-success" value="Registar Factura">
				</div><br><br>
			</div>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>

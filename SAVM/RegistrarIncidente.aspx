<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistrarIncidente.aspx.cs" ClientIDMode="Static"
	Inherits="SAVM.RegistrarIncidente" %>
<asp:Content ID="Content_RI" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<br>
			<div class="row">
					<fieldset>
						<legend>Datos del Proveedor</legend>
						<div class="row">
							<div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-3">
							        <label>Código:</label>
                                    </div>
                                    <div class="col-md-6">
							        <input type="text" class="form-control" id="txtIdProv">
                                    </div>
                                </div><br/>
                                <div class="row">
                                    <div class="col-md-3">
							        <label>RUC:</label>
                                    </div>
                                    <div class="col-md-6">
							        <input type="number" class="form-control">
                                    </div>
                                </div>
							</div>

                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-3">
							        <label>Razón Social:</label>
                                    </div>
                                    <div class="col-md-6">
							        <input type="text" class="form-control">
                                    </div>
                                </div><br />
                                <div class="row">
                                    <div class="col-md-3">
							        <label>Contacto:</label>
                                    </div>
                                    <div class="col-md-6">
							        <input type="text" class="form-control">
                                    </div>
                                </div>
							</div>

                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-4">
							        <label>Incidentes Registrados:</label>
                                    </div>
                                    <div class="col-md-4">
							        <input type="number" class="form-control">
                                    </div>
                                </div><br />
                                <div class="row">
                                    <div class="col-md-9">
							        <input type="button" class="form-control btn btn-info" value="Buscar Proveedor">
                                    </div>
                                </div>
							</div>
                                
						</div>
					</fieldset>
			</div><br>	

			<div class="row">
			<fieldset>
				<legend>Datos del Incidente</legend>
				<div class="row">
					<div class="col-md-4 form-inline">
						<label>N° del Incidente:</label>&nbsp;&nbsp;&nbsp;
						<input type="text" class="form-control" style="width: 100px">
					</div>
					<div class="col-md-4 form-inline">
                        <label>Tipo de Incidente:</label>&nbsp;&nbsp;&nbsp;
						<select type="text" class="form-control" style="width: 100px"></select>
					</div>	
					<div  class="form-inline col-md-4">
						<label for="">Fecha:</label>&nbsp;&nbsp;&nbsp;
						<input type="date" class="form-control">
					</div>
				</div><br>
                <div>
                    <h4>
                        Descripción del Incidente
                    </h4>
                    <textarea class="form-control" style="width:90%">
                    </textarea>
                </div>
			</fieldset>
			</div><br><br><br> 

			<div class="row">
				<div class="col-md-1">
					<input type="button" class="btn btn-primary" value="Volver">
				</div>
				<div class="col-md-6">
					<input type="button" class="btn btn-success" value="Registrar Incidente">
				</div><br><br>
			</div>
       </div>
</asp:Content>

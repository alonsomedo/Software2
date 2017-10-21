<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Medicamentos.aspx.cs" Inherits="SAVM.Medicamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <header class="titulo">
        <div class="container-fluid">
            <h2 style="text-align: left"><strong>Registrar Medicamento</strong></h2>
        </div>
    </header>
    <div class="container-fluid">
		<br>
        <fieldset>
            <legend>Datos del Medicamento</legend>
            <div class="row">
                <div class="col-md-6">
                  <div class="row">
                    <div class="col-md-4">
                    <p>Nombre de Medicamento:</p>
                    </div>
                    <div class="col-md-5">
                    <input type="text" name="name" value="" class="form-control"/>
                    </div>
                  </div><br>

                  <div class="row">
                    <div class="col-md-4">
                    <p>Prec. Compra Unit.:</p>
                    </div>
                    <div class="col-md-5">
                    <input type="number" name="name" value="" class="form-control"/>
                    </div>
                  </div><br>

                  <div class="row">
                    <div class="col-md-4">
                    <p>Prec. Venta Unit.:</p>
                    </div>
                    <div class="col-md-5">
                    <input type="text" name="name" value="" class="form-control"/>
                    </div>
                  </div><br>


                  <div class="row">
                    <div class="col-md-4">
                    <p>Stock:</p>
                    </div>
                    <div class="col-md-5">
                    <input type="number" name="name" value="" class="form-control"/>
                    </div>
                  </div>
                </div>


                <div class="col-md-6">
                    <div class="row">
                    <div class="col-md-4">
                    <p>Fecha de Vencimiento:</p>
                    </div>
                    <div class="col-md-5">
                    <input type="date" name="name" value="" class="form-control"/>
                    </div>
                  </div><br>

                  <div class="row">
                    <div class="col-md-4">
                    <p>Tipo de Medicamento:</p>
                    </div>
                    <div class="col-md-5">
                    <select class="form-control"></select>
                    </div>
                  </div><br>

                  <div class="row">
                    <div class="col-md-4">
                    <p>Proveedor:</p>
                    </div>
                    <div class="col-md-5">
                    <select class="form-control"></select>
                    </div>
                  </div><br>
                </div>
            </div>
        </fieldset>
        <br>
        <div class="">
					<input type="button" class="btn btn-success" value=" ➕ Agregar Medicamento">
	    </div><br><br>

			<div class="row">
				<div class="col-md-1">
					<input type="button" class="btn btn-primary" value="Volver">
				</div>
			</div>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>

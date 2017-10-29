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
                            <p>Cod.Medicamento:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtCodMedicamento" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <p>Nombre de Medicamento:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtNombreMedicamento" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Prec. Compra Unit.:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Prec. Venta Unit.:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>


                    <div class="row">
                        <div class="col-md-4">
                            <p>Stock:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Stock Mínimo:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <p>Fecha de Vencimiento:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="date" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Tipo de Medicamento:</p>
                        </div>
                        <div class="col-md-5">
                            <select class="form-control"></select>
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Proveedor:</p>
                        </div>
                        <div class="col-md-5">
                            <select class="form-control"></select>
                        </div>
                        <div class="col-md-3">
                            <input class="btn btn-primary" type="button" name="name" value="Buscar Proveedor" />
                        </div>
                    </div>
                    <br>
                </div>
            </div>
        </fieldset>
        <br>
        <div class="">
            <input type="button" class="btn btn-success" value=" ➕ Agregar Medicamento">
        </div>
        <br />
        <div class="row">
            <div class="col-md-11">
                <input type="text" id="txtFiltroMedicamento" name="name" value="" placeholder=" 🔍 Ingrese Código o Nombre de Medicamento" class="form-control" />
            </div>
        </div>
        <br>
        <div class="row">
            <div class="col-md-12" style="overflow: auto; height: 300px">
                <table class="table" id="tblMedicamentos">
                    <thead class="bg-blue-gradient">
                        <tr>
                            <th>CodMedicamento</th>
                            <th>Medicamento</th>
                            <th>P.Compra</th>
                            <th>P.Venta</th>
                            <th>Stock</th>
                            <th>StockMin.</th>
                            <th>Fec.Vencimiento</th>
                            <th>Tipo</th>
                            <th>Proveedor</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="tBodyMedicamentos">
                    </tbody>
                </table>
            </div>
        </div>

        <div class="row">
            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/Medicamentos.js"></script>
</asp:Content>

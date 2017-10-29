<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConsultarOrdenCompra.aspx.cs" ClientIDMode="Static" Inherits="SAVM.ConsultarOrdenCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3>Consultar Órdenes de Compra de Medicamentos</h3>

        <div class="form-inline">
            <span class="fa fa-search"></span>
            <input type="text" id="txtFilterOC" name="name" style="width: 88%" placeholder=" Buscar O/C" class="form-control" />

        </div>
        <br>
        <div class="col-md-11" style="height: 700px; overflow: auto">
            <table id="tblOrdenCompra" class=" display  table table-condensed ">
                <thead>
                    <tr>
                        <th>N° de O/C</th>
                        <th>Fecha de Emisión</th>
                        <th>IGV</th>
                        <th>Total S/.</th>
                        <th>RUC Proveedor</th>
                        <th>R.Social</th>
                        <th>Ver</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
        <div class="col-md-offset-9 col-md-2">
            <input type="button" name="name" class="form-control btn btn-primary" value="Volver" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/ConsultarOrdenCompra.js"></script>
</asp:Content>

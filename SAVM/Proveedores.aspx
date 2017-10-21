<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="SAVM.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <header class="titulo">
        <div class="container-fluid">
            <h2 style="text-align: left"><strong>Mantener Proveedor</strong></h2>
        </div>
    </header>
    <div class="container-fluid">
        <br>
        <fieldset>
            <legend>Datos del Proveedor</legend>
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Razón Social:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>RUC:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Dirección:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>


                    <div class="row">
                        <div class="col-md-4">
                            <p>Correo Electrónico:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Nombre Contacto:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Apellido Paterno:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Apellido Materno:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>


                    <div class="row">
                        <div class="col-md-4">
                            <p>Teléfono:</p>
                        </div>
                        <div class="col-md-5">
                            <input type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>
                </div>
            </div>
        </fieldset>
        <br>
        <div class="">
            <input type="button" class="btn btn-success" value=" ➕ Agregar Proveedor">
        </div>
        <br>
        <br>

        <div class="row">
            <div class="col-md-11">
                <input type="text" name="name" value="" placeholder=" 🔍 Ingrese Medicamento" class="form-control" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-11" style="overflow: auto; height: 200px">
                <table class="table" id="">
                    <thead class="bg-blue-gradient">
                        <tr>
                            <th>Razón Social</th>
                            <th>RUC</th>
                            <th>Dirección</th>
                            <th>Stock</th>
                            <th>Nombre Contacto</th>
                            <th>Apellido Paterno</th>
                            <th>Apellido Materno</th>
                            <th>Teléfono</th>
                            <th>Correo electrónico</th>
                            <th>Modificar</th>
                            <th>Eliminar</th>
                        </tr>
                    </thead>
                    <tbody id="tabladetalleventa">
                    </tbody>
                </table>
            </div>
        </div>
        <br>
        <div class="row">
            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>

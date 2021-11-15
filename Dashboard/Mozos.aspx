<%@ Page Title="Mozo" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Mozos.aspx.cs" Inherits="Dashboard.Pages.Mozo" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="d-flex align-items-center">
            <div class="p-2 bd-highlight">
                <h1>Listado de Empleados</h1>
            </div>
            <div class="p-2 bd-highlight">
                <button type="button" class="btn btn-success btnAdd" data-bs-toggle="modal" data-bs-target="#modal2" />
                <i class="icon ion-md-add">Agregar</i>
            </div>
        </div>
        <table id="table_id" class="display">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Comision</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
        <!-- start modal -->
        <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modal">Actualizar</button>--%>
        <div class="modal fade" id="modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Actualizar mozo</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="name" class="col-form-label">Nombre:</label>
                            <asp:TextBox ID="name" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="lastName" class="col-form-label">Apellido:</label>
                            <asp:TextBox ID="lastName" runat="server" class="form-control" type="text"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="commission" class="col-form-label">Comision:</label>
                            <asp:TextBox ID="commission" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="update">Actualizar</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- end modal-->

        <!-- start modal -->
        <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modal">Actualizar</button>--%>
        <div class="modal fade" id="modal2" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel2">Nuevo mozo</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="Nombre" class="col-form-label">Nombre:</label>
                            <asp:TextBox ID="Nombre" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="Apellido" class="col-form-label">Apellido</label>
                            <asp:TextBox ID="Apellido" runat="server" class="form-control" type="text"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="Comision" class="col-form-label">Comision:</label>
                            <asp:TextBox ID="Comision" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="new">Registrar</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- end modal-->
    </div>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="Script/mozos.js"></script>
</asp:Content>

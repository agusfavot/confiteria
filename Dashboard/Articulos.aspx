<%@ Page Title="Articulo" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Dashboard.Pages.Articulo" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start table -->
    <div class="d-flex align-items-center">
        <div class="p-2 bd-highlight">
            <h1>Listado de Artículos</h1>
        </div>
        <div class="p-2 bd-highlight">
            <button type="button" class="btn btn-success btnAdd" data-bs-toggle="modal" data-bs-target="#modal2" />
            <i class="icon ion-md-add">Agregar</i></div>
    </div>
    <table id="table_id" class="display">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Descripcion</th>
                <th>Sector</th>
                <th>Precio</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>

    <!-- end table -->

    <!-- start modal -->
    <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modal">Actualizar</button>--%>
    <div class="modal fade" id="modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Actualizar artículo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="name" class="col-form-label">Nombre:</label>
                        <asp:TextBox ID="name" runat="server" type="text" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="description" class="col-form-label">Descripcción</label>
                        <asp:TextBox ID="description" runat="server" class="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="price" class="col-form-label">Precio:</label>
                        <asp:TextBox ID="price" runat="server" type="text" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="sector" class="col-form-label">Sector</label>
                        <asp:DropDownList ID="DropDownListSector" runat="server" class="form-control"></asp:DropDownList>
                        <%--<asp:TextBox type="text" ID="sector" runat="server" class="form-control"></asp:TextBox>--%>
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
                    <h5 class="modal-title" id="exampleModalLabel2">Nuevo artículo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="Nombre" class="col-form-label">Nombre:</label>
                        <asp:TextBox ID="Nombre" runat="server" type="text" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="Descripccion" class="col-form-label">Descripcción</label>
                        <asp:TextBox ID="Descripccion" runat="server" class="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="Precio" class="col-form-label">Precio:</label>
                        <asp:TextBox ID="Precio" runat="server" type="text" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="IdSector" class="col-form-label">Sector</label>
                         <asp:TextBox ID="IdSector" runat="server" type="text" class="form-control"></asp:TextBox>
                        <%--<asp:TextBox type="text" ID="IdSector" runat="server" class="form-control"></asp:TextBox>--%>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="new">Registrar</button>
                </div>
            </div>
        </div>
    </div>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="Script/listItem.js"></script>
</asp:Content>


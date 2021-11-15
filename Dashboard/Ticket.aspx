<%@ Page Title="Ticket" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="Dashboard.Pages.Ticket" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--<script src="https://cdn.datatables.net/1.11.3/js/dataTables.bootstrap.min.js" type="text/javascript"></script>--%>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div class="d-flex align-items-center">
                <div class="p-2 bd-highlight">
                    <h1>Mozo</h1>
                </div>
                <div class="p-2 bd-highlight">
                    <button type="button" class="btn btn-success btnAdd" data-bs-toggle="modal" data-bs-target="#modalMozo" >
                    <i class="icon ion-md-add m-2"></i>Seleccionar mozo</button>
                </div>
            </div>
            <div class="d-flex">
                <div class="m-2">
                    <label class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="name" disabled="disabled">
                </div>
                <div class="m-2">
                    <label class="form-label">Apellido</label>
                    <input type="text" class="form-control" id="lastName" disabled="disabled">
                </div>
                <div class="m-2">
                    <label class="form-label">Comision</label>
                    <input type="text" class="form-control" id="commission" disabled="disabled">
                </div>
            </div>
        </div>
        <div>
            <div class="d-flex align-items-center">
                <div class="p-2 bd-highlight">
                    <h1>Detalle de compra</h1>
                </div>
                <div class="p-2 bd-highlight">
                    <button type="button" class="btn btn-success btnAdd" data-bs-toggle="modal" data-bs-target="#modalArticle" >
                    <i class="icon ion-md-add m-2"></i>Seleccionar artículo</button>
                </div>
                <div class="p-2 bd-highlight">
                    <button type="button" class="btn btn-danger btnDelet"" >
                    <i class="icon ion-md-trash m-2"></i>Eliminar artículo </button>
                </div>
            </div>
            <table id="tableItem" class="display">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nobre</th>
                        <th>Descripción</th>
                        <th>Precio</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                <button type="button" class="btn btn-success btnAcept"><i class="icon ion-md-paper m-2"></i>Registrar compra</button>
            </div>
        </div>

    <!-- START MODAL MOZO-->
    <div class="modal fade" id="modalMozo" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Seleccionar Mozo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <table id="tableMozo" class="display">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Comision</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary addMozo">Seleccionar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- END MODAL MOZO-->

    <!-- START MODAL ARTICULO-->
    <div class="modal fade" id="modalArticle" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Seleccionar Artículo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <table id="tableArticulo" class="display">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Nombre</th>
                                <th>Descripcion</th>
                                <th>Precio</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary addItem">Seleccionar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- END MODAL ARTICULO-->

    <script>
        $(document).ready(function () {
            $('#tableItem').DataTable({
                "scrollY": "180px",
                "filter": false,
                "info": false,
                "scrollCollapse": true,
                "paging": false
            });            

            $('#tableItem tbody').on('click', 'tr', function () {
                var table = $('#tableItem').DataTable();
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                }
                else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }
            });

            $('.btnDelet').click(function () {
                var table = $('#tableItem').DataTable();
                table.row('.selected').remove().draw(false);
            });
        });
    </script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="Script/ticket.js"></script>
</asp:Content>

<%@ Page Title="Local" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Dashboard.Pages.Local" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="container">
        <h1>Informes
        </h1>
        <div class="w-100 p-2" style="background-color: #E9967A">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Style="width: 100%">
                <LocalReport ReportPath="C:\Dashboard\Report\ReportCantArti.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="DSConfiteria" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <div class="p-3"></div>
        <div class="d-flex">
            <div class="m-3">
                <label id="startDat">Fecha desde:</label>
                <input id="startDate" class="form-control" />                
            </div>
            <div class="m-3">
                <label>Fechas hasta:</label>
                <input id="endDate" class="form-control"/>
            </div>
            <div class="m-3">                
                <button id="btnFilter" class="btn btn-success align-items-end">Filtrar</button>
            </div>
        </div>        
        <div class="w-100 p-2" style="background-color: #E9967A">
            <rsweb:ReportViewer ID="ReportViewer2" runat="server" Style="width: 100%">
                <LocalReport ReportPath="C:\Dashboard\Report\ReportVentaMozo.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="DSConfiteria" Name="DataSet2" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </div>
    <script src="Script/informes.js"></script>
</asp:Content>

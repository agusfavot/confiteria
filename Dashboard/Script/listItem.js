var table, data;

function addRows(data) {
    table = $("#table_id").dataTable({
    });
    for (var i = 0; i < data.length; i++) {
        table.fnAddData([
            data[i].Id,
            data[i].Name,
            data[i].Description,
            data[i].IdSector,
            data[i].Price,
            '<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btnEdit" data-bs-toggle="modal" data-bs-target="#modal"><i class="icon ion-md-create"></i></button>&nbsp' +
            '<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btnDelet"><i class="icon ion-md-trash"></i></i></button>'
        ]);
    }
}

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Articulos.aspx/loadGrid",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            addRows(data.d);
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d)
        }
    });
}

$(document).on('click', '.btnEdit', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    data = table.fnGetData(row);
    fillModalData();
});

$(document).on('click', '.btnDelet', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    data = table.fnGetData(row);
    deleteDataAjax();
});

function fillModalData() {
    $("#name").val(data[1]);
    $("#description").val(data[2]);
    $("#price").val(data[3]);
    $("#sector").val(data[4]);
}

$("#update").click(function (e) {
    var table = $("#table_id").dataTable();
    e.preventDefault();
    updateDataAjax();
    table.clear().draw();
    sendDataAjax();
});

$("#new").click(function (e) {
    e.preventDefault();
    addDataAjax();
    var table = $("#table_id").DataTable();
    table.clear().draw();
    sendDataAjax();
});

function addDataAjax() {
    var obj = JSON.stringify({
        name: $("#Nombre").val(),
        description: $("#Descripccion").val(),
        price: $("#Precio").val(),
        idSector: $("#IdSector").val()
    });

    $.ajax({
        type: "POST",
        url: "Articulos.aspx/addArticle",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.d) {
                swal("success", "successfull operation", "success");
            }
            else {
                swal("Error", "cancelled operation", "error");
            }
        }
    });
}

function updateDataAjax() {
    var obj = JSON.stringify({
        id: JSON.stringify(data[0]),
        name: $("#name").val(),
        description: $("#description").val(),
        price: $("#price").val(),
        idSector: $("#sector").val()
    })

    $.ajax({
        type: "POST",
        url: "Articulos.aspx/updateArticle",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.d) {
                swal("success", "successfull operation", "success");
            }
            else {
                swal("Error", "cancelled operation", "error");
            }
        }
    });
}

function deleteDataAjax() {
    var obj = JSON.stringify({ id: JSON.stringify(data[0]) });

    $.ajax({
        type: "POST",
        url: "Articulos.aspx/deleteArticle",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.d) {
                swal("success", "successfull operation", "success");
            }
            else {
                swal("Error", "cancelled operation", "error");
            }
        }
    });

}

function close() {
    $("#modal").modal("hide")
    $('body').removeClass('modal-open')
    $('.modal-backdrop').remove()
}

sendDataAjax();
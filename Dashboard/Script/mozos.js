var table, data;


function addRows(data) {
    table = $("#table_id").dataTable();
    for (var i = 0; i < data.length; i++) {
        table.fnAddData([
            data[i].Id,
            data[i].Name,
            data[i].LastName,
            data[i].Commission,            
            '<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btnEdit" data-bs-toggle="modal" data-bs-target="#modal"><i class="icon ion-md-create"></i></button>&nbsp' +
            '<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btnDelet"><i class="icon ion-md-trash"></i></i></button>'
        ]);
    }
}
 
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "Mozos.aspx/loadGrid",
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

function fillModalData() {
    $("#name").val(data[1]);
    $("#lastName").val(data[2]);
    $("#commission").val(data[3]);
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
    sendDataAjax();
});

$("#new").click(function (e) {
    e.preventDefault();
    addDataAjax();
    sendDataAjax();
});

$("#update").click(function (e) {
    e.preventDefault();
    updateDataAjax();
    sendDataAjax();
});

function addDataAjax() {
    var obj = JSON.stringify({
        name: $("#Nombre").val(),
        lastName: $("#Apellido").val(),
        commission: $("#Comision").val()
    });

    $.ajax({
        type: "POST",
        url: "Mozos.aspx/addEmployee",
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
        lastName: $("#lastName").val(),
        commission: $("#commission").val()
    });

    $.ajax({
        type: "POST",
        url: "Mozos.aspx/updateEmployee",
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
    var obj = JSON.stringify({ id: JSON.stringify(data[0])})

    $.ajax({
        type: "POST",
        url: "Mozos.aspx/deleteEmployee",
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

function close(modal) {
    $("#{0}", modal).modal("hide")
    $('body').removeClass('modal-open')
    $('.modal-backdrop').remove()
}


sendDataAjax();
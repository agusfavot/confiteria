var list = [];
//START AJAX Employee

$(".addMozo").click(function (e) {
    var table = $("#tableMozo").DataTable();
    e.preventDefault();
    var data = table.row('.selected').data();
    list.push(data[0]);
    loadData(data);
})

$('#tableMozo tbody').on('click', 'tr', function () {
    var table = $("#tableMozo").DataTable();
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
});

function addRowsMozo(data) {
    var table = $("#tableMozo").dataTable();
    for (var i = 0; i < data.length; i++) {
        table.fnAddData([
            data[i].Id,
            data[i].Name,
            data[i].LastName,
            data[i].Commission
        ]);
    }
}

function sendDataMozo() {
    $.ajax({
        type: "POST",
        url: "Ticket.aspx/loadEmployee",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            addRowsMozo(data.d);
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d)
        }
    });
}

function loadData(data) {
    $("#name").val(data[1]);
    $("#lastName").val(data[2]);
    $("#commission").val(data[3]);
}

//END AJAX Employee


//START AJAX ITEM
$('#tableArticulo tbody').on('click', 'tr', function () {
    var table = $("#tableArticulo").DataTable();
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    }
    else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
});

$(".addItem").click(function (e) {
    var table = $("#tableArticulo").DataTable();
    e.preventDefault();
    var data = table.row('.selected').data();    
    loadDataTable(data);
})

$(document).on('click', '.btnDelet', function () {
    var table = $("#tableArticulo").DataTable();
    var row = $(this).parent().parent()[0];

    table.row(row).remove().draw(false);
})

function addRowsItem(data) {
    var table = $("#tableArticulo").dataTable();
    for (var i = 0; i < data.length; i++) {
        table.fnAddData([
            data[i].Id,
            data[i].Name,
            data[i].Description,
            data[i].Price
        ]);
    }
}

function sendDataItem() {
    $.ajax({
        type: "POST",
        url: "Ticket.aspx/loadItem",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            addRowsItem(data.d);
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d)
        }
    });
}

function loadDataTable(data) {

    var table = $("#tableItem").dataTable();

    table.fnAddData([
        data[0],
        data[1],
        data[2],
        data[3],
    ])
    list.push(data[0]);
}

//END AJAX ITEM

$(".btnAcept").click(function (e) {
    e.preventDefault();
    registerTicket();
});

function registerTicket() {
    var obj = JSON.stringify(list);
    var table = $("#tableItem").DataTable();
    $.ajax({
        type: "POST",
        url: "Ticket.aspx/insertTicket",
        data: "{'json':'" + obj + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.d) {
                swal("success", "successfull operation", "success");
                list = [];
                table.clear().draw();
                cleanField();                
            }
            else {
                swal("Error", "cancelled operation", "error");
            }
        },
        failure: function (response) {
            alert(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        }
    });
}

function close() {
    $('#tableMozo').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}

function cleanField() {
    $("#name").val("");
    $("#lastName").val("");
    $("#commission").val("");
};

sendDataMozo();
sendDataItem();

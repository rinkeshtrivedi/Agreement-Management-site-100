
$(document).ready(function () {
    Get();
});

function Get() {
    $.ajax({
        type: "POST",
        url: "/Agreement/Get",
        cache: false,
        data: {
            UserId: $("#UserId").val()
        },
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
}

function OnSuccess(response) {
    $("#AgreementList").DataTable(
        {
            processing: true,
            //dom: 'Bfrtip',
            //retrieve: true,
            bLengthChange: true,
            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
            bFilter: true,
            bSort: true,
            bPaginate: true,
            data: response,
            columns: [{ 'data': 'GroupDescription' },
            { 'data': 'ProductDescription' },
            { 'data': 'ProductNumber' },
            { 'data': 'ProductPrice' },
            { 'data': 'NewPrice' },
            {
                "render": function (data, type, full, meta) { return '<a class="btn btn-info add-edit-detail" data-id=' + full.Id + '>Edit</a>'; }
            },
            {
                "render": function (data, type, full, meta) { return '<button class="delete-agreement" data-id=' + full.Id + '>Delete</button>'; }
            },
                /*{ title: "", "defaultContent": "<button class='delete-agreement'  >Delete</button>" }*/
            ]
        });
};

$("#txtSearch").on("keyup", function () {
    if ($("txtSearch").val() != "") {
        Get();
    }
});

$("#ddl_StateId").change(function () {
    GetCityList($(this));
});

$(document).on("click", ".save-agreement", function () {
    processSaveAgreement($(this));
});

function processSaveAgreement() {
    if (!setFocusInvalidControll($("#frmAgreement"))) {
        return false;
    }
    $.ajax({
        type: "POST",
        url: "/Agreement/CreateUpdate",
        cache: false,
        data: $("#frmAgreement").serialize(),
        success: function (data) {
            if (data == true) {
                alert("Sucess");
                $('#dialog').dialog('close');
                ClearData();
                $('#AgreementList').DataTable().clear().destroy();
                //$('#AgreementList').empty();
                Get();
            } else {
                alert("Error");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) { }
    })
}

function setFocusInvalidControll(form) {
    if (!$(form).valid()) {
        var formerrorList = $(form).data("validator").errorList;
        var element = formerrorList[0].element;
        var classname = element.className;

        if (classname.indexOf("full-name__input--1").toString() != "-1" || classname.indexOf("full-name__input--2").toString() != "-1" || classname.indexOf("full-name__input--3").toString() != "-1") {
            $(element).closest(".full-name").addClass('focus');
            element.focus();
            return false;
        }
        else if (classname.indexOf("address-control__input--1").toString() != "-1" || classname.indexOf("address-control__input--2").toString() != "-1" || classname.indexOf("address-control__input--3").toString() != "-1") {
            $(element).closest(".address-control").addClass('focus');
            element.focus();
            return false;
        }
        else {
            element.focus();
            return false;
        }
    }
    return true;
}

$(document).on("click", ".btncancel", function () {
    ClearData();
});

function ClearData() {
    $("#ProductGroupId").val('');
    $("#ProductId").val('');
    $("#EffectiveDate").val('');
    $("#ExpirationDate").val('');
    $("#ProductPrice").val('');
    $("#NewPrice").val('');
    //$(".selectpicker").selectpicker('refresh');
}

$(document).on("click", ".delete-agreement", function () {
    Delete($(this));
});

function Delete(ctrl) {

    var Id = $(ctrl).attr("data-id");
    $.ajax({
        type: "POST",
        url: "/Agreement/Delete",
        cache: false,
        data: {
            id: Id
        },
        success: function (data) {
            if (data == true) {
                alert("Sucess");
                $('#AgreementList').DataTable().clear().destroy();
                Get();
            } else {
                alert("Error");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}

//$(document).on("change", ".datepickertime", function () {
//    $('.datepickertime').datetimepicker({
//        format: 'DD/MM/YYYY HH:mm',
//    });
//});

$(document).on("click", ".add-edit-detail", function () {
    //var table = $('#AgreementList').DataTable();
    // var data = table.row(this).data();
    // alert('You clicked on ' + data[0] + '\'s row');
    var _Id = $(this).attr("data-id");

    $.ajax({
        type: "GET",
        url: "/Agreement/Detail",
        data: {
            id: _Id
        },
        cache: false,
        datatype: 'application/json',
        success: function (data) {
            $("#dialog").html("");
            $("#dialog").html(data.Data);
            //$('.datepickertime').datetimepicker({
            //    format: '‘MM/dd/yyyy'
            //});
            if (_Id == null || _Id == undefined) {
                $('.datepickertime').datetimepicker({
                    defaultDate: new Date(),
                    format: 'DD/MM/YYYY HH:mm',
                });
            } else {
                //$('.datepickertime').datetimepicker({
                //    format: 'DD/MM/YYYY HH:mm',
                //});
            }
            /*$('#dialog').html(response);*/
            $('#dialog').dialog('open');
        },
        failure: function (response) {
            alert(data.Message);
        },
        error: function (response) {
            alert(data.Message);
        }
    });
});

$(document).on("change", "#ProductGroupId", function () {
    GetProductList($(this));
});

function GetProductList(cltr) {
    if (cltr.val() == "0") {
        $("#ProductId").prop('disabled', true);
        $("#ProductId").val("0");
    } else {
        $("#ProductId").prop('disabled', false);

        $.ajax({
            type: "GET",
            url: "/Agreement/GetProductList",
            cache: false,
            data: {
                GroupId: cltr.val()
            },
            datatype: 'application/json',
            success: function (data) {
                $("#ProductId").prop('disabled', false);
                $("#ProductId").empty();
                $("#ProductId").append($('<option>', { value: '0', text: '--Select Product--' }));
                $(data).each(function (index, item) {
                    console.log(item)
                    //$("#CityName").append($('<option>', { value: item.stateId, text: item.name }));
                    var opt = new Option(item.ProductNumber, item.Id);
                    $("#ProductId").append(opt);
                });
            }
        })
    }
}
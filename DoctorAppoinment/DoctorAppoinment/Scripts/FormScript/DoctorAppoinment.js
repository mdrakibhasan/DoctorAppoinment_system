$(document).ready(function () {
    alert("");
    $("#IsMale").attr('checked', true);

});

$(document.body).on("click", ".js-edit", function () {

    var button = $(this);
    var id = button.attr("data-id");
    getData(id);

});
$("#txtFindTrainee").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/api/DoctorAppoinment/Search",
            data: { query: request.term },
            type: "GET"
        }).done(function (data) {
            response($.map(data, function (item) {
                return { label: item.Id + " " + item.Name, value: item.Id }
            }));
        });
    },
    minLength: 2,
    select: function (e, ui) {

        $.get("/api/DoctorAppoinment/SearchAutoComplete", { pNumber: ui.item.value })
            .done(function (data) {
                //console.log(pData);
                // window.pId = data.id;
               
                $("#PatientName").val(data.Name);               
                $("#PatientHistory").val(data.PatientHistory);
                $("#MobileNo").val(data.MobileNo);

            });

    }
});
function getData(id) {
    $.get("/api/DoctorAppoinment/" + id)
        .done(function (data) {
            refressForm();
            $("#Id").val(data.Id);
            $("#PatientName").val(data.PatientName);
            $("#AppoinmentNo").val(data.AppoinmentNo);
            $("#SerialNo").val(data.SerialNo);
            $("#PatientHistory").val(data.PatientHistory);
            $("#Address").val(data.Address);
            $("#MobileNo").val(data.MobileNo);
            $("#DoctorInfoId").val(data.DoctorInfoId);
            var gender = data.Gender;
            var com = "Female";
            if (String(data.Gender) === String(com)) {
                $("#IsFemale").prop('checked', true);
            }
            else {

                $("#IsMale").prop('checked', true);
            }

            $("#Gender").val(data.Gender);

        });
}

function refressForm() {
    $("#Id").val('');
    $("#PatientName").val('');
    $("#AppoinmentNo").val('');
    $("#SerialNo").val('');
    $("#PatientHistory").val('');
    $("#MobileNo").val('');
    $("#DoctorInfoId").val('');   
    $("#Gender").val('');
    $("#FatherName").val('');
    $("#Address").val('');
}

$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.PatientName = $("#PatientName").val();
    vm.AppoinmentNo = $("#AppoinmentNo").val();
    vm.SerialNo = $("#SerialNo").val();
    vm.PatientHistory = $("#PatientHistory").val();
    vm.MobileNo = $("#MobileNo").val();
    vm.DoctorInfoId = $("#DoctorInfoId").val();
    vm.FatherName = $("#FatherName").val();
    vm.DoctorInAddressfoId = $("#Address").val();

    var checkedradio = $('[name="Gender"]:radio:checked').val();
    vm.Gender = checkedradio;

    if (id == "" || id == 0 || id == null) {
        $.ajax({
            url: "/api/DoctorAppoinment",
            data: vm,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Save Success.", "Success!!!");
                    refressForm();
                    loadHistoryTable();
                } else {
                    toastr.warning("Save Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    } else {
        vm.id = id;

        $.ajax({
            url: "/api/DoctorAppoinment/" + id,
            data: vm,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Update Success", "Success!!!");
                    refressForm();
                    loadHistoryTable();
                } else {
                    toastr.warning("Update Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }

});

function loadHistoryTable() {

    $("#informationHistory").DataTable().destroy();

    $("#informationHistory").DataTable({
        paging: true,
        ajax: {
            url: "/api/PatientInfo",
            dataSrc: ""
        },
        columns: [
            {
                data: "PatientName"
            },
            {
                data: "SerialNo"
            },
            {
                data: "AppoinmentNo"
            },
            {
                data: "MobileNo"
            },
            
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn btn-info btn-sm js-edit' data-id=" + data + " >Edit</button>";
                }
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-id=" + data + ">Delete</button>";
                }
            }
        ]
    });
}
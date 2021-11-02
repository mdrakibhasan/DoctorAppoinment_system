$(document).ready(function () {


    loadHistoryTable();
    $("#IsMale").attr('checked', true);

});
$(document.body).on("click", "#btnClear", function () {
    refressForm();
});
$(document.body).on("click", "#btnSubmit", function () {
    var vm = {};
    var id = $("#Id").val();
    vm.Name = $("#Name").val();
    vm.FatherName = $("#FatherName").val();
    vm.MotherName = $("#MotherName").val();
    vm.DateofBirth = $("#DateofBirth").val();
    vm.Address = $("#Address").val();
    vm.MobileNo = $("#MobileNo").val();
    vm.DistrictInfoId = $("#DistrictInfoId").val();
    vm.ThanaInfoId = $("#ThanaInfoId").val();
    vm.CountryInfoId = $("#CountryInfoId").val();
    vm.PatientHistory = $("#PatientHistory").val();

    var checkedradio = $('[name="Gender"]:radio:checked').val();
    vm.Gender = checkedradio;

    vm.Email = $("#Email").val();
    if (id == "" || id == 0 || id == null) {
        $.ajax({
            url: "/api/PatientInfo",
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
            url: "/api/PatientInfo/" + id,
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


function refressForm() {
    $("#Id").val('');
    $("#Name").val('');
    $("#MotherName").val('');
    $("#DateofBirth").val('');
    $("#Address").val('');
    $("#MobileNo").val('');
    $("#FatherName").val('');
    $("#DistrictInfoId").val('');
    $("#ThanaInfoId").val('');
    $("#CountryInfoId").val('');
    $("#Gender").val('');
    $("#Email").val('');
    $("#PatientHistory").val('');
    
}
$(document.body).on("click", ".js-edit", function () {


    var button = $(this);
    var id = button.attr("data-id");
    getData(id);

});

function getData(id) {
    $.get("/api/PatientInfo/" + id)
        .done(function (data) {
            refressForm();
            $("#Id").val(data.Id);
            $("#Name").val(data.Name);
            $("#MotherName").val(data.MotherName);
            $("#Email").val(data.Email);
            $("#DateofBirth").val(data.DateofBirth);
            $("#Address").val(data.Address);
            $("#MobileNo").val(data.MobileNo);
            $("#FatherName").val(data.FatherName);            
            $("#DistrictInfoId").val(data.DistrictInfoId);
            $("#ThanaInfoId").val(data.ThanaInfoId); 
            $("#PatientHistory").val(data.PatientHistory);
            $("#CountryInfoId").val(data.CountryInfoId);
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
$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Do you want to delete the information?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/PatientInfo/" + id,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                        toastr.success("Delete Success");
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
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
                data: "Name"
            },
            {
                data: "FatherName"
            },
            {
                data: "MotherName"
            },
            {
                data: "MobileNo"
            },
            {
                data: "Email"
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

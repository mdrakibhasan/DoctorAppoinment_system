$(document).ready(function () {

    loadHistoryTable();
    $("#IsMale").attr('checked', true);
    $("#PatientName ,#MobileNo").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/api/DoctorAppoinment/Search",
                data: { query: request.term },
                type: "GET"
            }).done(function (data) {
                response($.map(data, function (item) {
                    return { label: item.MobileNo + " " + item.Name, value: item.Id }
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
    
   
    $('#DoctorInfoId ,#AppoinmentDate').change(function () {

        var vm = {};
        var id = $("#Id").val();       
        vm.MobileNo = $("#MobileNo").val();
        vm.DoctorInfoId = $("#DoctorInfoId").val();       
        vm.AppoinmentDate = $("#AppoinmentDate").val();
       
        
            if (vm.DoctorInfoId != "" && vm.DoctorInfoId != 0 && vm.DoctorInfoId != null) {

                $.ajax({
                    url: "/api/DoctorAppoinment/CountSerialNumber",
                    data: { DoctorID: vm.DoctorInfoId, Date: vm.AppoinmentDate },
                    type: "GET",
                    success: function (e) {
                        if (e > 0) {
                            $("#SerialNo").val(e);
                        } else {
                            $("#SerialNo").val('0');
                        }

                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        else
            {
                $("#SerialNo").val('0');
            }
            
            
        
        
  });


});



function refressForm() {
    $("#Id").val('');
    $("#PatientName").val('');
    $("#AppoinmentNo").val('');
    $("#SerialNo").val('');
    $("#Address").val('');
    $("#MobileNo").val('');
    $("#FatherName").val('');
    $("#PatientHistory").val('');
    $("#DoctorInfoId").val('');
    $("#Gender").val('');
    $("#AppoinmentDate").val('');
    
}
$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Do you want to delete the information?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/DoctorAppoinment/" + id,
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
    vm.Address = $("#Address").val();
    vm.AppoinmentDate = $("#AppoinmentDate").val();
    var checkedradio = $('[name="Gender"]:radio:checked').val();
    vm.Gender = checkedradio;

    //var d = new Date();
    //var d1 = Date.parse(vm.AppoinmentDate);
    //var dt2 = $.now();
    
    //if ( d1< Date.now()) {
    //    alert(Date.now() + ' ' + date);

    //    return;
    //}
    //else {
    //    alert(Date.now());
    //    return;
    //}

    if (vm.PatientName == "" || vm.PatientName == null) {       
        toastr.warning("Please Input Patient Name.", "Warning!!!");
        return;
    }    
    if (vm.MobileNo == "" ||  vm.MobileNo == null) {
        toastr.warning("Please Input Mobile No.", "Warning!!!");
        return;
    }
    if (vm.DoctorInfoId == "" || vm.DoctorInfoId == 0 || vm.DoctorInfoId == null) {
        alert('');
        toastr.warning("Please Select Doctor.!!","Warning!!!");
        return;
    }
  
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
                }else if(e==0)
                {
                    toastr.warning("Please Input Valid Date.", "Warning!!!");
                }

                else {
                    toastr.warning("Save Fail.", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
                alert(response.message + ' ' + response);
                
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

$(document.body).on("click", "#btnClear", function () {
    refressForm();
});

$(document.body).on("click", ".js-edit", function () {


    var button = $(this);
    var id = button.attr("data-id");
    getData(id);

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
            $("#FatherName").val(data.FatherName);            
            var res = (date.getFullYear() + '-'(date.getMonth() + 1) + '-' + date.getDate());
            $("#AppoinmentDate").val(data.AppoinmentDate);
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

function loadHistoryTable() {

    $("#informationHistory").DataTable().destroy();

    $("#informationHistory").DataTable({
        paging: true,
        ajax: {
            url: "/api/DoctorAppoinment",
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
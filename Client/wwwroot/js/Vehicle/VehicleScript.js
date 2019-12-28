$(document).ready(function () {
    $('#vehicleGrid').dataTable({
        "columnDefs": [
            { "orderable": false, "targets": 1 }
        ],
        "ajax": loadData(),
        "responsive": true
    });
});
function loadData() {
    $.ajax({
        url: "/Vehicles/List",
        type: "GET",
        async: false,
        success: function (result) {
            debugger;
            var html = '';
            $.each(result, function (key, vehicle) {
                html += '<tr>';
                html += '<td>' + vehicle.vehicleType + '</td>';
                html += '<td><button type="button" class="btn btn-warning" id="Edit" onclick="return GetbyID(' + vehicle.Id + ')">Edit</button> ' +
                    '<button type = "button" class="btn btn-danger" id="Delete" onclick="return Delete(' + vehicle.Id + ')" > Delete</button ></td > ';
                html += '</tr>';
            });
            $('.tbVehicleBody').html(html);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
}
//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var vehicle = new Object();
    vehicle.VehicleType = $('#VehicleType').val();
    $.ajax({
        type: "POST",
        url: "/Vehicles/Create",
        data: vehicle
    })
        .then((result) => {
            if (result.StatusCode == 200) {
                loadData();
                $('#myModal').modal('hide');
                alert("Success");
            }
            else {
                alert("Error");
            }
        });
}

function GetbyID(ID) {
    $('#VehicleName').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Vehicles/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        async: false,
        success: function (result) {
            const obj = JSON.parse(result);
            $('#Id').val(obj.Id);
            $('#VehicleType').val(obj.VehicleType);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Update Function
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var vehicle = new Object();
    vehicle.Id = $('#Id').val();
    vehicle.VehicleType = $('#VehicleType').val();
    $.ajax({
        url: "/Vehicles/Update/",
        data: vehicle
    })
        .then((result) => {
            if (result.StatusCode == 200) {
                loadData();
                $('#myModal').modal('hide');
                alert("Success");
            }
            else {
                alert("Error");
            }
        });
}

//Delete Function
function Delete(ID) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            swalWithBootstrapButtons.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
            debugger;
            $.ajax({
                url: "/Vehicles/Delete/" + ID,
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    loadData();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            )
        }
    })
}

//Function for clearing the textboxes
function clearTextBox() {
    $('#Id').val("");
    $('#VehicleType').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#VehicleType').css('border-color', 'lightgrey');
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#VehicleType').val().trim() == "") {
        $('#VehicleType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VehicleType').css('border-color', 'lightgrey');
    }
    return isValid;
}
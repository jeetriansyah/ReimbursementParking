$(document).ready(function () {
    $('#roleGrid').dataTable({
        "columnDefs": [
            { "orderable": false, "targets": 1 }
        ],
        "ajax": loadData(),
        "responsive": true
    });
});
function loadData() {
    $.ajax({
        url: "/Roles/List",
        type: "GET",
        async: false,
        success: function (result) {
            debugger;
            var html = '';
            $.each(result, function (key, role) {
                html += '<tr>';
                html += '<td>' + role.roleName + '</td>';
                html += '<td><button type="button" class="btn btn-warning" id="Edit" onclick="return GetbyID(' + role.Id + ')">Edit</button> ' +
                    '<button type = "button" class="btn btn-danger" id="Delete" onclick="return Delete(' + role.Id + ')" > Delete</button ></td > ';
                html += '</tr>';
            });
            $('.tbRoleBody').html(html);
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
    var role = new Object();
    role.RoleName = $('#RoleName').val();
    $.ajax({
        type: "POST",
        url: "/Roles/Create",
        data: role
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
    $('#RoleName').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Roles/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        async: false,
        success: function (result) {
            const obj = JSON.parse(result);
            $('#Id').val(obj.Id);
            $('#RoleName').val(obj.RoleName);
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
    var role = new Object();
    role.Id = $('#Id').val();
    role.RoleName = $('#RoleName').val();
    $.ajax({
        url: "/Roles/Update/",
        data: role
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
                url: "/Roles/Delete/" + ID,
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
    $('#RoleName').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#RoleName').css('border-color', 'lightgrey');
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#RoleName').val().trim() == "") {
        $('#RoleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#RoleName').css('border-color', 'lightgrey');
    }
    return isValid;
}
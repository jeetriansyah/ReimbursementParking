$(document).ready(function () {
    $('#departments').dataTable({
        "columnDefs": [{
            "orderable": false,
            "targets": 1
        }],
        "ajax": loadDataDepartments(),
        "responsive": true
    });
});
function loadDataDepartments() {
    $.ajax({
        url: "/Departments/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            var html = '';
            $.each(result, function (key, Department) {
                html += '<tr>';
                html += '<td>' + Department.Name + '</td>';
                html += '<td><button type="button" class="btn btn-warning" id="Update" onclick="return GetbyId(' + Department.Id + ')">Edit</button> ';
                html += '<button type="button" class="btn btn-danger" id="Delete" onclick="return Delete(' + Department.Id + ')" >Delete</button ></td > ';
                html += '</tr>';
                html += '</tr>';
                html += '</tr>';
            });
            $('.departmentsbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Save() {
    if ($('#DepartmentName').val() === 0) {
        Swal.fire({
            position: 'center',
            type: 'error',
            title: 'Please Full Fill The Name',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        var Department = new Object();
        Department.Id = $('#Id').val();
        Department.Name = $('#DepartmentName').val();
        $.ajax({
            type: 'POST',
            url: '/Departments/InsertOrUpdate/',
            data: Department
        }).then((result) => {
            //debugger;
            if (result.StatusCode === 200) {
                Swal.fire({
                    position: 'center',
                    type: 'success',
                    title: 'Insert Successfully'
                });
                ResetTable();
            }
            else {
                Swal.fire('Error', 'Insert Fail', 'error');
                ClearScreen();
            }
        });
    }
}

function Update() {
    if ($('#Name').val() === 0) {
        Swal.fire({
            position: 'center',
            type: 'error',
            title: 'Please Full Fill The Name',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        //debugger;
        var data = new Object();
        data.Id = $('#Id').val();
        data.Name = $('#Name').val();
        data.Email = $('#Email').val();
        $.ajax({
            url: "/Departments/InsertOrUpdate/",
            data: data
        }).then((result) => {
            //debugger;
            $('#myModal').hide();
            if (result.StatusCode === 200) {
                Swal.fire({
                    position: 'center',
                    type: 'success',
                    title: 'Update Successfully',
                    showConfirmButton: false,
                    timer: 1500
                });
                ResetTable();
            }
            else {
                Swal.fire('Error', 'Update Fail', 'error');
                ClearScreen();
            }
        });
    }
}

function GetbyId(Id) {
    //debugger;
    $('#DepartmentName');
    $.ajax({
        url: "/Departments/GetbyId/" + Id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        async: false,
        success: function (result) {
            const obj = JSON.parse(result);
            $('#Id').val(obj.Id);
            $('#DepartmentName').val(obj.Name);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function ClearScreen() {
    $('#Id').val('');
    $('#DepartmentName').val('');
    $('#Update').hide();
    $('#Save').show();
}

function ResetTable() {
    $('#departments').dataTable().destroy();
    $('#departments').dataTable({
        "ajax": loadDataDepartments()
    });
}

function Delete(Id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            //debugger;
            $.ajax({
                url: "/Departments/Delete/",
                type: "POST",
                data: { id: Id }
            }).then((result) => {
                //debugger;
                if (result.StatusCode === 200) {
                    Swal.fire({
                        position: 'center',
                        type: 'success',
                        title: 'Delete Successfully'
                    });
                    ResetTable();
                }
                else {
                    Swal.fire('Error', 'Update Fail', 'error');
                    ClearScreen();
                }
            });
        }
    });
}
var dataTable;

$(function () {
    // Handler for .ready() called.
    loadDataTable();
});
  
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'name', className: "text-bg-dark", "width": "20%" },
            { data: 'email', className: "text-bg-dark", "width": "15%" },
            { data: 'company.name', className: "text-bg-dark", "width": "25%" },
            { data: 'role', className: "text-bg-dark", "width": "5%" },
            { data: 'phoneNumber', className: "text-bg-dark", "width": "15%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" }, className: "text-bg-dark",
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `<div class="text-center">
                         <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style= "cursor:pointer; width:50px;">
                            <i class= "bi bi-unlock-fill"></i> 
                        </a>
                         <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-info text-white" style= "cursor:pointer; width:50px;">
                            <i class= "bi bi-pencil-square"></i> 
                        </a>
                    </div >`
                    }
                    else {
                        return `<div class="text-center">
                        <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style= "cursor:pointer; width:50px;">
                            <i class= "bi bi-unlock-fill"></i>
                        </a>
                         <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-info text-white" style= "cursor:pointer; width:50px;">
                            <i class= "bi bi-pencil-square"></i> 
                        </a>
                    </div >`
                    }


                },
                "width": "10%"
            },
        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}
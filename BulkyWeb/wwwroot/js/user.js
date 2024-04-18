var dataTable;

$(document).ready(function () {
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
                data: 'id', className: "text-bg-dark",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href = "/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square" ></i ></a>
                        <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill" ></i ></a>
                    </div >`
                },
                "width": "10%"
            },
        ]
    });
}

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall' },
        "columns": [
            { data: 'id', className: "text-bg-dark", "width": "3%" },
            { data: 'name', className: "text-bg-dark", "width": "20%" },
            { data: 'phoneNumber', className: "text-bg-dark", "width": "15%" },
            { data: 'applicationUser.email', className: "text-bg-dark", "width": "20%" },
            { data: 'orderStatus', className: "text-bg-dark", "width": "15%" },
            { data: 'orderTotal', className: "text-bg-dark", "width": "8%"},
            {
                data: 'id', className: "text-bg-dark",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href = "/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square" ></i ></a>
                    </div >`
                },
                "width": "10%"
            },
        ]
    });
}

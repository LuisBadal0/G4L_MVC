$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'productName', "width": "15%" },
            { data: 'developer', "width": "10%" },
            { data: 'publisher', "width": "10%" },
            { data: 'description', "width": "25%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href = "/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square" ></i ></a>
                        <a href = "" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill" ></i ></a>
                    </div >`
                },
                "width": "10%"
            },
        ]
    });
}


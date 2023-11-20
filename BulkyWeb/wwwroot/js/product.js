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
        ]
    });
}


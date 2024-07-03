var dataTable;

$(function () {
    // Handler for .ready() called.
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'productName', className: "text-bg-dark", "width": "20%" },
            { data: 'developer', className: "text-bg-dark", "width": "15%" },
            { data: 'publisher', className: "text-bg-dark", "width": "25%" },
            { data: 'listPrice', className: "text-bg-dark", "width": "5%" },
            { data: 'category.name', className: "text-bg-dark", "width": "15%" },
            {
                data: 'id', className: "text-bg-dark",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href = "/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square" ></i ></a>
                        <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill" ></i ></a>
                    </div >`
                },
                "width": "10%"
            },
        ]
    });
}

function Delete(url){
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}

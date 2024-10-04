$(document).ready(function () {
    var table = $('#productTable').DataTable({
        responsive: true,
        columnDefs: [
            { orderable: false, targets: 0 }
        ]
    });

    $('#selectAll').on('click', function () {
        var rows = table.rows({ 'search': 'applied' }).nodes();
        $('input[type="checkbox"]', rows).prop('checked', this.checked);
    });

    $('#productTable tbody').on('change', 'input[type="checkbox"]', function () {
        if (!this.checked) {
            $('#selectAll').prop('checked', false);
        }

        if ($('#productTable tbody input[type="checkbox"]:checked').length === $('#productTable tbody input[type="checkbox"]').length) {
            $('#selectAll').prop('checked', true);
        }
    });

    $('#insert').click(function () {
        $('#productid').val('');
        $('#modaltitle').text('Add Product');
        $('#productId').val('');
        $('#productName').val('');
        $('#productDescription').val('');
        $('#productPrice').val('');
        $('#productStock').val('');
    });

    $('.edit').click(function () {
        var productId = $(this).data('id');
        $('#confirmDeleteButton').data('id', productId);

        $.ajax({
            url: '/products/' + productId,
            contentType: 'application/json',
            type: 'GET',
            success: function (data) {
                $('#productId').val(data.id);
                $('#productName').val(data.name);
                $('#productDescription').val(data.description);
                $('#productPrice').val(data.price);
                $('#productStock').val(data.stockQuantity);
                $('#modalTitle').text('Edit Product');
                $('#cancelButton').click();
            },
            error: function () {
                alert('Error fetching product data');
            }
        });
    });

    $('#productForm').on('submit', function (e) {
        e.preventDefault();

        var productId = $('#productId').val();

        url = '/products/save';
        method = 'POST';

        var Product = {
            Id: productId,
            Name: $('#productName').val(),
            Description: $('#productDescription').val(),
            Price: parseFloat($('#productPrice').val()),
            StockQuantity: parseInt($('#productStock').val())
        };

        var productJson = JSON.stringify(Product);

        $.ajax({
            url: '/products/save',
            type: 'POST',
            contentType: 'application/json',
            data: productJson,
            success: function () {
                $('#editProductModal').modal('hide');
                alert('Product saved successfully!');
                location.reload();
            },
            error: function () {
                alert('Error saving product');
            }
        });
    });

    $('.delete').click(function () {
        var productId = $(this).data('id');
        $('#confirmDeleteButton').data('id', productId);
    });

    $('#confirmDeleteButton').click(function () {
        var productId = $(this).data('id');

        $.ajax({
            url: '/products/delete/' + productId,
            type: 'DELETE',
            contentType: 'application/json',
            success: function (response) {
                if (response) {
                    alert("Product deleted successfully!");
                    location.reload();
                } else {
                    alert("Error when deleting product.");
                }
            },
            error: function (xhr, status, error) {
                alert("An error occurred when trying to delete the product.");
            }
        });

        $('#deleteProductModal').modal('hide');
    });
});
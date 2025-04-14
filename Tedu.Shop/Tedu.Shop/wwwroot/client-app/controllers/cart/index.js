﻿var CartController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveFromCart',
                type: 'post',
                data: {
                    productId: id
                },
                success: function () {
                    tedu.notify('Xoá sản phẩm thành công', 'success');
                    loadHeaderCart();
                    loadData();
                }
            });
        });
        $('body').on('keyup', '.txtQuantity', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var q = $(this).val();
            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q
                    },
                    success: function() {
                        tedu.notify('Cập nhật thành công', 'success');
                        loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                tedu.notify('Số lượng không hợp lệ', 'error');
            }
           
        });
        $('#btnClearAll').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/Cart/ClearCart',
                type: 'post',
                success: function () {
                    tedu.notify('Xoá giỏ hàng thành công', 'success');
                    loadHeaderCart();
                    loadData();
                }
            });
        });
    }
    function loadHeaderCart() {
        $("#headerCart").load("/AjaxContent/HeaderCart");
    }
    function loadData() {
        $.ajax({
            url: '/Cart/GetCart',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                var template = $('#template-cart').html();
                var render = "";
                var totalAmount = 0;
                $.each(response, function (i, item) {
                    render += Mustache.render(template,
                        {
                            ProductId: item.Product.Id,
                            ProductName: item.Product.Name,
                            Image: item.Product.ThumbnailImage,
                            Price: tedu.formatNumber(item.Price, 0),
                            Quantity: item.Quantity,
                            Amount: tedu.formatNumber(item.Price * item.Quantity, 0),
                            Url: '/' + item.Product.SeoAlias + "-p." + item.Product.Id + ".html"
                        });
                    totalAmount += item.Price * item.Quantity;
                });
                $('#lblTotalAmount').text(tedu.formatNumber(totalAmount, 0));
                if (render !== "")
                    $('#table-cart-content').html(render);
                else
                    $('#table-cart-content').html('Bạn chưa chọn sản phẩm nào');
            }
        });
        return false;
    }
}
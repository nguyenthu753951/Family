var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.quantity');
            var cartList = [];


            $.each(listProduct, function (i, item) {
                cartList.push({
                    sO_LUONG: $(item).val(),
                    monAn: {
                        MA_MON_AN: $(item).data("id")
                    }
                });
            });

            console.log(cartList);
            $.ajax({
                url: '/GioHang/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang";
                    }                  
                }
            })
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/GioHang/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/GioHang/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang";
                    }
                }
            })
        });
    }  
}
cart.init();

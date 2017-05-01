

$(document).ready(function () {
    //--Add item in cart
    $('.AddToCart').click(function () {
        var value = $(this).val();
        $.ajax({
            url: "/Ajax/AddItemInCart",
            type: "POST",
            datatype: "json",
            data: { productID: value, },
            success: function (data) {
                if (data) {
                    $(".TagToRemove").remove();
                    //Get Cart Quantity and increment it
                    var text = $(".cart-quantity").text();
                    var count = parseInt(text);
                    $(".cart-quantity").html(++count);
                    //Cart Total
                    var total = parseFloat(0);
                    //Appending Quick Cart List
                    for (var i = 0; i < data.length; i++) {
                        $("#QuickCartView").append("<li class=\"product-info TagToRemove\"> <div class=\"p-left\"><a href=\"#\"><img class=\"img-responsive\" src='" + data[i].ProductDetail.ProductImage1.replace(/~/g, ' ') + "' alt=\"Cart Product\"></a></div><div class=\"p-right\"><p class=\"p-name\">" + data[i].ProductDetail.ProductName + "</p><p class=\"p-rice\">" + data[i].ProductDetail.Price * data[i].Quantity + "</p><p>Quantity: " + data[i].Quantity + "</p><button class=\"btn-hover-2 DeleteItemFromCart pull-right\" onclick=\"f1(this)\" value=" + data[i].ProductID + "><i class=\"glyphicon glyphicon-trash\"></i></button></div></li>");
                        var price = data[i].ProductDetail.Price * data[i].Quantity;
                        total = parseFloat(price) + total;
                    }
                    //Updating Cart Total
                    $("#CartTotal").html(total);
                } else {
                    alert('failed');
                }
            }
        })
    });
});


function f1(obj) {
    var value = obj.value;
    $.ajax({
        url: "/Ajax/DeleteItemFromCart",
        type: "POST",
        datatype: "json",
        data: { productID: value, },
        success: function (data) {
            $(".TagToRemove").remove();
            var quantity = parseInt(0);
            var total = parseFloat(0.0);
            for (var i = 0; i < data.length; i++) {
                quantity = data[i].quantity + quantity;
                $("#QuickCartView").append("<li class=\"product-info TagToRemove\"> <div class=\"p-left\"><a href=\"#\"><img class=\"img-responsive\" src='" + data[i].ProductDetail.ProductImage1.replace(/~/g, ' ') + "' alt=\"Cart Product\"></a></div><div class=\"p-right\"><p class=\"p-name\">" + data[i].ProductDetail.ProductName + "</p><p class=\"p-rice\">" + data[i].ProductDetail.Price * data[i].Quantity + "</p><p>Quantity: " + data[i].Quantity + "</p><button class=\"btn-hover-2 DeleteItemFromCart pull-right\" onclick=\"f1(this)\" value=" + data[i].ProductID + "><i class=\"glyphicon glyphicon-trash\"></i></button></div></li>");
                var price = data[i].ProductDetail.Price * data[i].Quantity;
                total = price + total;
            }
            $(".cart-quantity").html(quantity);
            //Updating Cart Total
            $("#CartTotal").html(total);
        }
    })
}
$(document).ready(function () {
    //--Add item in cart
    $('.AddToCart').click(function () {
        var value = $(this).val();
        debugger;
        $.ajax({
            url: "/Cart/AddItemInCart",
            type: "POST",
            datatype: "json",
            data: { productID: value },
            success: function (data) {
                if (data) {
                    $(".TagToRemove").remove();
                    //int variable empty(0)
                    var count = parseInt(0);
                    //Cart Total
                    //float variable empty
                    var total = parseFloat(0);
                    debugger;
                    //Appending Quick Cart List
                    for (var i = 0; i < data.length; i++) {
                        //rendor cart items
                        $("#QuickCartView").append("<li class=\"product-info TagToRemove\"> <div class=\"p-left\"><a href=\"#\"><img class=\"img-responsive\" src='" + data[i].ProductDetail.ProductImage1.replace(/~/g, ' ') + "' alt=\"Cart Product\"></a></div><div class=\"p-right\"><p class=\"p-name\">" + data[i].ProductDetail.ProductName + "</p><p class=\"p-rice\">" + data[i].ProductDetail.Price * data[i].Quantity + "</p><p>Quantity: " + data[i].Quantity + "</p><button class=\"btn-hover-2 DeleteItemFromCart pull-right\" onclick=\"f1(this)\" value=" + data[i].ProductID + "><i class=\"glyphicon glyphicon-trash\"></i></button></div></li>");
                        //unit price
                        var price = data[i].ProductDetail.Price * data[i].Quantity;
                        total = parseFloat(price) + total;
                        //cart count
                        count = count + data[i].Quantity;
                    }
                    //Cart Quantity  increment
                    $(".cart-quantity").html(count);
                    alertify.success("Item successfully added...");
                    //Updating Cart Total
                    $(".CartTotal").html(total);

                } else {
                    alert('failed');
                }
            }
        })
    });
});



//to remove item from cart
function f1(obj) {
    var value = obj.value;
    $.ajax({
        url: "/Cart/DeleteItemFromCart",
        type: "POST",
        datatype: "json",
        data: { productID: value },
        success: function (data) {
            $(".TagToRemove").remove();
            var quantity = parseInt(0);
            var total = parseFloat(0.0);
            for (var i = 0; i < data.length; i++) {
                quantity = data[i].Quantity + quantity;
                $("#QuickCartView").append("<li class=\"product-info TagToRemove\"> <div class=\"p-left\"><a href=\"#\"><img class=\"img-responsive\" src='" + data[i].ProductDetail.ProductImage1.replace(/~/g, ' ') + "' alt=\"Cart Product\"></a></div><div class=\"p-right\"><p class=\"p-name\">" + data[i].ProductDetail.ProductName + "</p><p class=\"p-rice\">" + data[i].ProductDetail.Price * data[i].Quantity + "</p><p>Quantity: " + data[i].Quantity + "</p><button class=\"btn-hover-2 DeleteItemFromCart pull-right\" onclick=\"f1(this)\" value=" + data[i].ProductID + "><i class=\"glyphicon glyphicon-trash\"></i></button></div></li>");
                var price = data[i].ProductDetail.Price * data[i].Quantity;
                total = price + total;
            }
            $(".cart-quantity").html(quantity);
            alertify.success("Item successfully Removed...");
            //Updating Cart Total
            $(".CartTotal").html(total);
        }
    })
}










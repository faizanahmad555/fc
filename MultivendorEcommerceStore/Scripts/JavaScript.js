



$('.ItemToDelete').click(function () {
    var productId = $(this).attr("value");
    $("#btnContinueDelete").val(productId);

});

$('#btnContinueDelete').click(function () {
    var productId = $(this).attr("value");
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteProductConfirm",
        data: { ProductID: productId },
        success: function (data) {
            if (data == "True") {
                $("#myModal").modal("hide");
                $("#ProductToDelete_" + productId).remove();
            }
        }

    });
});



$('.ItemToChange').click(function () {
    $(this).css('btn btn-danger', 'btn btn-primary');
    var productId = $(this).attr("value");
    var active = $("#ItemActive_" + productId).text();
    var ActiveState;
    if (active == "Yes") {
        ActiveState = 1;
    }
    else {
        ActiveState = 0;
    }
    
    $.ajax({
        type: "POST",
        url: "/Admin/ChangeProductActiveStatus",
        data: { ProductID: productId, IsActive: ActiveState },
        success: function (data) {
            if (data == "1") {

                $("#ItemActive_" + productId).text("Yes");

                $("#button").click(function () {
                    $(this).css(".btn btn-primary");
                });

            } else {
                $("#ItemActive_" + productId).text("No");

                $("#button").click(function () {
                    $(this).css(".btn btn-danger");
                });
            }
        }

    });
});




$('.ItemToChangeSupplier').click(function () {
    var productId = $(this).attr("value");
    var active = $("#ItemActive_" + productId).text();
    var ActiveState;
    if (active == "Yes") {
        ActiveState = 1;
    }
    else {
        ActiveState = 0;
    }

    $.ajax({
        type: "POST",
        url: "/Supplier/ChangeProductActiveStatus",
        data: { ProductID: productId, IsActive: ActiveState },
        success: function (data) {
            if (data == "1") {
                $("#ItemActive_" + productId).text("Yes");
            } else {
                $("#ItemActive_" + productId).text("No");
            }
        }

    });
});
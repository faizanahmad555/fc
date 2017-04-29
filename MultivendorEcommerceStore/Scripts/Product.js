


$("#SelectedCategory").change(function () {
    var categoryId = $('#SelectedCategory').val();
    $.ajax({
        url: "/Product/SubCategoriesByCategoryID/" + categoryId,
        type: "Get",
        contentType: "application/json; charset=utf-8",
        datatype: 'JSON',
        success: function (data) {
            $('#SubCategory').empty();
            for (var i = 0; i < data.subcategory.length; i++) {
                $('#SubCategory').append("<option value= " + data.subcategory[i].Value + ">" + data.subcategory[i].Text + "</option>");
            }
        }
    });
});

$("#SubCategory").change(function () {
    var subcategoryId = $('#SubCategory').val();
    $.ajax({
        url: "/Product/SubCategoryItemsBySubCategoryID/" + subcategoryId,
        type: "Get",
        contentType: "application/json; charset=utf-8",
        datatype: 'JSON',
        success: function (data) {
            $('#SubCategoryItem').empty();
            for (var i = 0; i < data.subcategoryitem.length; i++) {
                $('#SubCategoryItem').append("<option value= " + data.subcategoryitem[i].Value + ">" + data.subcategoryitem[i].Text + "</option>");
            }
        }
    });
});




$('.ItemToDelete').click(function () {
    var productId = $(this).attr("value");
    $("#btnContinueDelete").val(productId);

});

$('#btnContinueDelete').click(function () {
    var productId = $(this).attr("value");
    $.ajax({
        type: "POST",
        url: "/Product/DeleteProductConfirm",
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
        url: "/Product/ChangeProductActiveStatus",
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



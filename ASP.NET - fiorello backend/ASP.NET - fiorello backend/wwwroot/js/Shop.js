$(document).ready(function () {

    let parent = $("#parent");

    $(".show-more").on("click", function () {

        let skipCount = parent.children().length;
        let productsCount = $("#products").attr("data-count");

        $.ajax({
            url: `shop/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                parent.append(res);
                skipCount = parent.children().length;
                if (skipCount == productsCount) {
                    $(".show-more").addClass("d-none");
                    $(".show-less").removeClass("d-none");
                }
            }

        })
    })

    $(".show-less").on("click", function () {

        let skipCount = 0;
        $.ajax({
            url: `shop/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                parent.empty();
                parent.append(res);
                $(".show-less").addClass("d-none");
                $(".show-more").removeClass("d-none");
            }

        })
    })
   
})
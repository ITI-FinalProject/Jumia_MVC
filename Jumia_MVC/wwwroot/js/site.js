// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    //$('#progress').show();

    //getAlldata();
    updatecartCount();
});

function getAlldata() {
    //  $.mobile.loading('show');
    $.ajax({
        url: '/api/OrdersApi/',
        //url:'@Url.Action("ShoppingCart")',
        method: "Get",
        success: function (data) {
            var res = data.shoppingCart.shoppingCartItems;
            $('#progress').hide();

            if (res.length == 0) {
                emptyCart();
            } else {
                createTable(data);

            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            // $.mobile.loading('hide');
            alert("Excpetion " + errorThrown + XMLHttpRequest);
        }

    });

}
function updatecartCount() {

    $.ajax({
        url: '/api/ShoppingCartApi/',
        method: "Get",
        success: function (data) {

            $('#showcount').html(data);
        },
        errot: function () {
            alert("Some thing with wrong");
        }

    });
}

function AddItemINCard(id) {
    $.ajax({
        url: '/api/OrdersApi/' + id,
        method: "put",
        success: function (data) {
            console.log(data);
            //btn.parents('tr').fadeOut();
            //alert("user Delete");
            //  $('#alertShow').removeClass('d-none')
            // setTimeout(function() {  $('#alertShow').addClass('d-none');},3000);
            updatecartCount();
            swal({
                title: "Done",
                text: "Product Add To Cart",
                icon: "success",
                button: "Ok",
            });
        },
        errot: function () {
            alert("Some thing with wrong");
        }

    });

}
function deleteproduct(id) {
    $.ajax({
        url: '/api/OrdersApi/' + id,
        method: "delete",
        success: function (data) {
            console.log(data);
            //$('#progress').hide();
            //$('#records_table').show();
            //$('#addButton').show();

            updatecartCount();
            getAlldata();

            swal({
                title: "Done",
                text: "Product Delete From Cart",
                icon: "success",
                button: "Ok",
            });
            // this.parents('tr').fadeOut();

        },
        errot: function () {
            alert("Some thing with wrong");
        }

    });
}

function addItem(id) {
    $.ajax({
        url: '/api/OrdersApi/' + id,
        method: "put",
        success: function (data) {
            console.log(data);
            //$('#progress').hide();
            //$('#records_table').show();
            //$('#addButton').show();

            updatecartCount();
            getAlldata()

            swal({
                title: "Done",
                text: "Product Add To Cart",
                icon: "success",
                button: "Ok",
            });

        },
        errot: function () {
            alert("Some thing with wrong");
        }

    });


}
//favourit

function AddItemINFavourit(id, changeheart) {
    $.ajax({
        url: '/api/FavouritApi/' + id,
        method: "put",
        success: function (data) {
            $(changeheart).removeClass("far fa-heart");
            $(changeheart).addClass("fas fa-heart");
            swal({
                title: "Done",
                text: "Product Add To Favourit",
                icon: "success",
                button: "Ok",
            });
        },
        errot: function () {
            alert("Some thing with wrong");
        }

    });

}

function deleteFavourit(id) {
    $.ajax({
        url: '/api/FavouritApi/' + id,
        method: "delete",
        success: function (data) {
            console.log(data);
            //$('#progress').hide();
            //$('#records_table').show();
            //$('#addButton').show();

            updatecartCount();
            getAlldata();

            swal({
                title: "Done",
                text: "Product Delete From Favourit",
                icon: "success",
                button: "Ok",
            });
            // this.parents('tr').fadeOut();

        },
        errot: function () {
            alert("Some thing with wrong");
        }

    });
}

//header
window.addEventListener("scroll", function () {
    if (window.scrollY > 100) {
        document.querySelector("#navbar").style.opacity = 0.9;
    } else {
        document.querySelector("#navbar").style.opacity = 1;
    }
});

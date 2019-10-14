$(document).ready(function () {

    $('#inlineFormCustomSelect').change(function () {
        var selVal = $(this).val();
        if (selVal != "") {
            $.ajax({
                url: "/Home/GetLocationVenue",
                type: "GET",
                data: { cityId: selVal }
            })
                .done(function (partialViewResult) {
                    $("#refLocationVenue").html(partialViewResult);
                });

        }
       
    });
});
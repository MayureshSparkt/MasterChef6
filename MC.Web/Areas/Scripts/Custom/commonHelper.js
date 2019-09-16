var commonHelper = function (statusCode) {
    var that = {};

    var loaderHtml = '<div id="custom-loader" class="overlay"><i class="fa fa-spinner fa-spin"></i></div>';

    that.handleStatusCode = function (statusCode) {
        var errorMessage = 'Uncaught Error.';
        switch (statusCode) {
            case 0:
                errorMessage = 'Not connect.\n Verify Network.';
                break;
            case 404:
                errorMessage = 'Requested page not found. [404]';
                break;
            case 500:
                errorMessage = 'Internal Server Error [500].';
            case 401:
                errorMessage = 'UnAuthorized access to requested content.';
                break;
        }

        alert("Something Went Wrong");
    };

    that.showHideLoader = function (toBeShown) {
        if (toBeShown) {
            if ($('body').find('#custom-loader').length == 0) {
                $('body').append(loaderHtml);
            }
        }
        else {
            if ($('body').find('#custom-loader').length > 0) {
                $('body').find('#custom-loader').each(function () {
                    $(this).remove();
                });
            }
        }
    }

    return that;
}();


var commonConstant = function () {

    var that = {};

    that.defaultGoogleMetaTags = '<meta itemprop="name" content="">\n<meta itemprop="description" content="">';
    that.defaultFacebookMetaTags = '<meta property="og:title" content="" />\n<meta property="og:url" content="" />\n<meta property="og:description" content="" />\n<meta property="og:site_name" content="" />\n<meta property="og:type" content="website" />\n<meta property="fb:admins" content="" />\n<meta property="og:image" content="" />';
    that.defaultTwitterSummaryCardMetaTags = '<meta name="twitter:card" content="summary" />\n<meta name="twitter:site" content="" />\n<meta name="twitter:title" content="" />\n<meta name="twitter:description" content="" />\n<meta name="twitter:image" content="" />';
    that.defaultTwitterSummaryWithLargeImageMetaTags = '<meta name="twitter:card" content="summary_large_image">\n<meta name="twitter:site" content="">\n<meta name="twitter:creator" content="">\n<meta name="twitter:title" content="">\n<meta name="twitter:description" content="">\n<meta name="twitter:image" content="">';
    that.defaultTwitterAppCardMetaTags = '<meta name="twitter:card" content="app">\n<meta name="twitter:site" content="">\n<meta name="twitter:description" content="">\n<meta name="twitter:app:country" content="">\n<meta name="twitter:app:name:iphone" content="">\n<meta name="twitter:app:id:iphone" content="">\n<meta name="twitter:app:url:iphone" content="">\n<meta name="twitter:app:name:ipad" content="">\n<meta name="twitter:app:id:ipad" content="">\n<meta name="twitter:app:url:ipad" content="">\n<meta name="twitter:app:name:googleplay" content="">\n<meta name="twitter:app:id:googleplay" content="">\n<meta name="twitter:app:url:googleplay" content="">';
    that.defaultTwitterPlayerCardMetaTags = '<meta name="twitter:card" content="player">\n<meta name="twitter:title" content="">\n<meta name="twitter:site" content="">\n<meta name="twitter:description" content="">\n<meta name="twitter:player" content="">\n<meta name="twitter:player:width" content="">\n<meta name="twitter:player:height" content="">\n<meta name="twitter:image" content="">\n<meta name="twitter:image:alt" content="">\n<meta name="twitter:player:stream" content="">\n<meta name="twitter:player:stream:content_type" content="">';

    that.LocationContentType = {
        Office: 'Office',
        CorporateOffice: 'Corporate Office',
        Email: 'Email',
        PhoneCall: 'Phone Call',
        VisitingHour: 'Visiting Hour'
    }

    return that;


}();
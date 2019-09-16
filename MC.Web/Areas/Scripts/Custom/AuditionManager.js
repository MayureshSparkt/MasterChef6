var auditionContentManager = function () {

    var that = {};
    var initEvents = function () {
        $('#btnAdduser').click(function () {
            var error_count = 0;
            var Id = $('#AuditionId').val();
            var Venue = $('#Venue').val();
            
            var Day = $('#Day').val();
            var Date = $('#Date').val();
            
            
            var PlaceId = $('#PlaceId').val();
            var CityId = $('#CityId').val();
            var IsActive = $('#IsActive option:selected').val();
           

            var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

            if (CityId == "") {
                $('.errorCityId').text('Please select City.');
                error_count++;
            }
            else {
                $('.errorCityId').text('');
            }

            //if (PlaceId == "") {
            //    $('.errorPlaceId').text('Please select PlaceId.');
            //    error_count++;
            //}
            //else {
            //    $('.errorPlaceId').text('');
            //}

            if (Date == "") {
                $('.errorDate').text('Please select Date.');
                error_count++;
            }
            else {
                $('.errorDate').text('');
            }


            if (Venue == "") {
                $('.errorVenue').text('Please enter Venue.');
                error_count++;
            }
            else {
                $('.errorVenue').text('');
            }

            if (Day == '') {
                $('.errorDay').text('Please enter Day.');
                error_count++;
            }
            else {
               
                    $('.errorDay').text('');
               
            }

            if (IsActive == "" || IsActive == 0 || IsActive == undefined) {
                $('.errorIsActive').text('Please select Status');
                error_count++;
            }
            else {
                $('.errorIsActive').text('');
            }

            if (Id == "") {
                Id = "0";
            }

            
            if (error_count == 0) {
                var Data = {};
                Data.AuditionId = Id,
                Data.CityId = CityId;
                Data.Venue = Venue;
                Data.PlaceId = PlaceId;
                Data.Day = Day;
                Data.Date = Date;
                Data.IsActive = IsActive;



                $.ajax({
                    type: "POST",
                    url: "/Admin/Audition/Modify",
                    data: Data,
                    dataType: 'json',
                    success: function (data) {
                        if (data.StatusCode) {
                            commonHelper.handleStatusCode(data.StatusCode);
                        } else {
                            if (data.Status) {
                                alert("Audition Saved Successfully.");

                                //auditionContentManager.FilterData();
                                auditionContentManager.clearForm();
                                location.reload(true);

                            }
                            else {
                                alert(data.Message);
                            }
                        }
                        $('#manageAuditionContent').modal('close');
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        commonHelper.handleStatusCode("Something went wrong");
                        $('#manageAuditionContent').modal('close');
                    },
                    cache: false
                });

            }
        });
    }
    that.init = function () {
        initEvents();

    };
    that.clearForm = function () {

        $('#manageAuditionContent #IsActive').prop('checked', true);

        $('#manageAuditionContent form').find('input:not(input[name=__RequestVerificationToken])').each(function () {
            $(this).val('');
        });

        $('#manageAuditionContent text').each(function () {
            $(this).val('');
        });

        $('#manageAuditionContent textArea').each(function () {
            $(this).val('');
        });
        $('#manageAuditionContent .error').each(function () {
            $(this).html('');
        });

        $('#manageAuditionContent').find('select').each(function () {
            $(this).val($(this).find('option:eq(0)').val());
            $(this).material_select();
        });

        Materialize.updateTextFields();

    }


    that.editLocationContent = function (id) {



        $.ajax({
            type: "POST",
            url: "/Admin/Audition/GetAuditionById",
            data: { auditionId: id },
            success: function (data) {
                if (data.StatusCode !== undefined) {
                    commonHelper.showHideLoader(false);
                    return;
                }
                if (data.Status) {

                    commonHelper.showHideLoader(false);
                    auditionContentManager.setUsermodal(data.Audition);
                    $('#manageAuditionContent').modal('open');
                }
                else {
                    alert(data.Message);
                    commonHelper.showHideLoader(false);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                commonHelper.handleStatusCode("Something went wrong");
                commonHelper.showHideLoader(false);

            },
            cache: false
        });


    }

    that.setUsermodal = function (audition) {
        if (audition) {

            $('#AuditionId').val(audition.AuditionId);
            $('#CityId').val(audition.CityId);
            $('#Venue').val(audition.Venue);
            $('#Day').val(audition.Day);
            $('#PlaceId').val(audition.PlaceId);
            $('#Date').val(audition.Date);
            $('#IsActive').val(""+audition.IsActive);
            $('select').material_select();

        }
    }

    that.deleteAuditionContent = function (id) {
        var result = confirm("Are you sure? You want to delete Audition?")
        if (result) {

            commonHelper.showHideLoader(true);

            $.ajax({
                type: "POST",
                url: "/Admin/Audition/DeleteAudition",
                data: { articleId: id },
                success: function (data) {
                    if (data.StatusCode !== undefined) {
                        commonHelper.showHideLoader(false);
                        return;
                    }

                    if (data.Status) {
                        alert(data.Message);
                        commonHelper.showHideLoader(false);
                        articleDataTableHandlers.FetchArticles('');
                    }
                    else {
                        alert(data.Message);
                        commonHelper.showHideLoader(false);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    commonHelper.handleStatusCode("Something went wrong");
                    commonHelper.showHideLoader(false);

                },
                cache: false
            });

        }
    };


    return that;
}();

var auditionDataTableHandlers = function () {

    var that = {};

    that.allauditionsContents = [];
    var currentPage = 1;
    var pageSize = 25;
    var noOfPageToDisplay = 5;
    var noOfPageToAddAndHide = 3;
    var startPageNo = 1;
    var lastPageNo = 5;

    $('#drpPageSize').change(function (event) {
        pageSize = $('#drpPageSize').val();
        currentPage = 1;
        startPageNo = 1;
        lastPageNo = noOfPageToDisplay;
        FilterData();
        event.preventDefault();
    });

    that.init = function () {
        $('#btnAddauditionContent').on('click', function (e) {
           
            auditionContentManager.clearForm();
            $('#manageAuditionContent').modal('open');
        });


        $('.filter').on('change', function () {
            pageSize = $('#drpPageSize').val();
            currentPage = 1;
            startPageNo = 1;
            lastPageNo = noOfPageToDisplay;
            FilterData();
        });

        that.FetchauditionContents('');
    }
    function GetPageData(event, pageNo) {
        currentPage = pageNo;
        FilterData();
        event.preventDefault();
    }

    function GetNextPageData(event) {
        currentPage = currentPage + 1;
        FilterData();
        event.preventDefault();
    }
    function GetPrevPageData(event) {
        currentPage = currentPage - 1;
        FilterData();
        event.preventDefault();
    }
    function FilterData() {

        commonHelper.showHideLoader(true);

        var vFltData = '';

        if ($('#txtCity').val().trim().length > 0)
            vFltData += $('#txtCity').val() + ",";
        else
            vFltData += '' + ",";

        if ($('#txtDate').val().trim().length > 0)
            vFltData += $('#txtDate').val() + ",";
        else
            vFltData += '' + ",";

        

        if ($('#txtVenue').val().trim().length > 0)
            vFltData += $('#txtVenue').val() + ",";
        else
            vFltData += '' + ",";

        if ($('#txtDay').val().trim().length > 0)
            vFltData += $('#txtDay').val() + ",";
        else
            vFltData += '' + ",";

        
        if ($('#drpStatus option:selected').val() != '')
            vFltData += $('#drpStatus option:selected').val() + ",";
        else
            vFltData += '' + ",";



        that.FetchauditionContents(vFltData);
    }
    that.FetchauditionContents = function (vFltData) {
        $.ajax({
            type: "POST",
            url: "/Admin/audition/GetAudditionContent",
            data: JSON.stringify({ 'FilterData': vFltData, 'currentPage': currentPage, 'pageSize': pageSize }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.StatusCode) {
                    commonHelper.handleStatusCode(data.StatusCode);
                } else {
                    PopulateauditionContentGrid(data);
                }

                commonHelper.showHideLoader(false);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                commonHelper.handleStatusCode("Something went wrong");
                commonHelper.showHideLoader(false);

            },
            cache: false
        });
    }

    function PopulateauditionContentGrid(vData) {

        that.allLocationContents = vData;
        var vTableContent = '';
        if (vData != null && vData.length > 0) {
            for (var vCounter = 0; vCounter < vData.length; vCounter++) {

                var isEnabledText = vData[vCounter].IsActive == true ? "Active " : "Inactive";
                var cssClass = vData[vCounter].IsActive == true ? "badge badge-success " : "badge badge-danger";
                var status = vData[vCounter].IsActive == true ? "Inactive" : "Active";
                var modifyTitle = vData[vCounter].IsActive == true ? "Deactivate" : "Activate";
                var statusClass = vData[vCounter].IsActive == true ? "fa fa-window-close" : "fa fa-check-square";
                var dropdownAction = '<select class="actionType"><option value="0">Select</option><option value="' + vData[vCounter].AuditionId + '">Edit</option><option value="' + vData[vCounter].AuditionId + '" >' + status + '</option><option value="' + vData[vCounter].AuditionId + '">Preview</option></select>';

                vTableContent += "<tr>";
                vTableContent += "<td class='left-align'>" + (vData[vCounter].City) + "</td>";
                vTableContent += "<td class='left-align'>" + vData[vCounter].Day + "</td>";

                vTableContent += "<td class='left-align'>" + (vData[vCounter].Venue) + "</td>";
                vTableContent += "<td class='left-align'>" + vData[vCounter].Date + "</td>";

                vTableContent += "<td>" + '<span class="' + cssClass + '">' + isEnabledText + '</span>' + "</td>";
                vTableContent += "<td class='action-column'> <a title='Edit' class='edit-icon' onclick='auditionContentManager.editLocationContent(\"" + vData[vCounter].AuditionId + "\");'><i class='fa fa-pencil-square' aria-hidden='true'></i></a><a title='" + modifyTitle + "' class='delete-icon' onclick='auditionContentManager.deleteAuditionContent(\"" + vData[vCounter].AuditionId + "\");'> <i class='" + statusClass + "' aria-hidden='true'></i></a ></td>";

                vTableContent += "</tr>";
            }


            $('table.table tbody').html(vTableContent);

            var noOfPages = Math.ceil(vData[0].TotalRecords / pageSize);
            $('#spnTotalReords').html("Total Records: - " + vData[0].TotalRecords);
            $('#spnTotalPages').html("Total Pages: - " + noOfPages);

            if (currentPage == lastPageNo && lastPageNo < noOfPages) {
                startPageNo = startPageNo + noOfPageToAddAndHide;
                lastPageNo = lastPageNo + noOfPageToAddAndHide;
                if (lastPageNo > noOfPages) {
                    lastPageNo = noOfPages;
                }
                if ((lastPageNo - startPageNo) + 1 < noOfPageToDisplay && noOfPages > noOfPageToDisplay) {
                    if (startPageNo - (noOfPageToDisplay - (lastPageNo - startPageNo)) >= 1) {
                        startPageNo = startPageNo - (noOfPageToDisplay - (lastPageNo - startPageNo));
                        if (lastPageNo - startPageNo >= noOfPageToDisplay) {
                            startPageNo = startPageNo + 1;
                        }
                    }
                }
            }
            else if (currentPage == startPageNo && currentPage > 1) {
                startPageNo = startPageNo - noOfPageToAddAndHide;
                if (startPageNo <= 0) {
                    startPageNo = 1;
                }
                lastPageNo = lastPageNo - noOfPageToAddAndHide;
                if ((lastPageNo - startPageNo) + 1 < noOfPageToDisplay && noOfPages > noOfPageToDisplay) {
                    lastPageNo = lastPageNo + (noOfPageToDisplay - (lastPageNo - startPageNo));
                }

            }
            else if (noOfPages < noOfPageToDisplay) {
                startPageNo = 1;
                lastPageNo = noOfPages;
            }

            if (currentPage > 1) {
                $('#ulPagination').html('<li><a href="#!" onclick="GetPrevPageData(event)"><i class="material-icons">chevron_left</i></a></li>');
            }
            else {
                $('#ulPagination').html('<li class="disabled"><a href="#!"><i class="material-icons">chevron_left</i></a></li>');
            }
            for (var pageCounter = startPageNo; pageCounter <= lastPageNo; pageCounter++) {
                if (pageCounter == currentPage) {
                    $('#ulPagination').append('<li class="active"><a href="#!">' + pageCounter + '</a></li>');
                }
                else {
                    $('#ulPagination').append(' <li class="waves-effect"><a href="#" onclick="GetPageData(event,' + pageCounter + ')">' + pageCounter + '</a></li>');
                }
            }
            if (noOfPages > currentPage) {
                $('#ulPagination').append(' <li class="waves-effect"><a href="#" onclick="GetNextPageData(event)"><i class="material-icons">chevron_right</i></a></li>');
            }
            else {
                $('#ulPagination').append(' <li class="waves-effect disabled"><a href="#!"><i class="material-icons">chevron_right</i></a></li>');
            }
        }
        else {
            $('#ulPagination').html('');
            $('#spnTotalReords').html("Total Records: - " + 0);
            $('#spnTotalPages').html("Total Pages: - " + 0);
            $('table.table tbody').html(vTableContent);
        }

    }
    return that;
}();
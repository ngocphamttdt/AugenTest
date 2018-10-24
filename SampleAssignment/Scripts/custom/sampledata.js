$(document).ready(function () {
    $("#btnSearch").on("click", function () {
        var urlSearch = $("#searchField").data("url-search");
        var keyWord = $("#searchField").val();
        var filedData = new FormData();
        filedData.append('keyword', keyWord);
        $.ajax({
            method: "POST",
            url: urlSearch,
            data: { keyWord: keyWord },
            cache: false,
            processData: true
        })
        .done(function (response) {
            $("#dataContent").html(response);
        });
    });

    $(".page-item").on("click", function () {
        debugger;
        var $this = $(this);
        var fromIndex = $this.data("index-from");
        var toIndex = $this.data("index-to");
        var urlPaging = $this.data("url-paging");
        var filedData = new FormData();
        filedData.append('fromIndex', fromIndex);
        filedData.append('toIndex', toIndex);
        $.ajax({
            method: "POST",
            url: urlPaging,
            data:
            {
                fromIndex: fromIndex,
                toIndex: toIndex
            },
            cache: false,
            processData: true
        })
            .done(function (response) {
                $("#dataContent").html(response);
            });

    });

}); 


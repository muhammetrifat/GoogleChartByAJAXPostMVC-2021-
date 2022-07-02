function fillActionLinks() {
    var url = "/Home/ActionLinkFill";
    $.getJSON(url, function (data) {
        for (var item in data.Result) {
            var deger = '<li><a href="/Home/' + data.Result[item].name + '" style="font-size:15px">' + data.Result[item].name + '</a></li>';
            $("#ulemenu1").append(deger);
            
        }
    });
}

/*<li>@Html.ActionLink("' + data.Result[item].name + '", "Index", "Home")</li>*/

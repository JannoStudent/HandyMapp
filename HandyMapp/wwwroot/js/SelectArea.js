console.log("hallo");

var AreaHover = "";
var AreaClicked = "";

$("g").mouseenter(function () {
    AreaHover = $(this).attr("id");
    $("#wijk").text(AreaHover);
});
$("g").mouseleave(function () {
    $("#wijk").text(AreaClicked);
});
$("g").click(function () {
    AreaClicked = $(this).attr("id");
    $("#wijk").text(AreaClicked);
    $("#wijk").parent().animate({ borderColor: "#fff" },"fast");
    $("#wijk").parent().animate({ borderColor: "#1370B8"});
});


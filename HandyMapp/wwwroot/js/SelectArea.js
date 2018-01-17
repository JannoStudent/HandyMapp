var BuitengebiedLat = 52.070103;
var BuitengebiedLng = 4.452895; 
var MeerzichtLat = 52.056198; 
var MeerzichtLng = 4.470166; 
var RokkeveenLat = 52.04202;
var RokkeveenLng = 4.472265; 
var DriemanspolderLat = 52.054316;
var DriemanspolderLng = 4.4862; 
var Buytenwegh_De_LeyensLat = 52.065245;
var Buytenwegh_De_LeyensLng = 4.48612; 
var NoordhoveLat = 52.075237;
var NoordhoveLng = 4.515552; 
var SeghwaertLat = 52.065616;
var SeghwaertLng = 4.510139; 
var StadscentrumLat = 52.063673;
var StadscentrumLng = 4.496848; 
var DorpLat = 52.049281;
var DorpLng = 4.503855; 
var PalensteinLat = 52.055786;
var PalensteinLng = 4.505899; 
var OosterheemLat = 52.06596;
var OosterheemLng = 4.532519; 
var BedrijventerreinenLat = 52.041557;
var BedrijventerreinenLng = 4.533239; 

var AreaHover;
var AreaClicked;
var AreaClickedLat;
var AreaClickedLng;

$("g").click(function () {
    AreaClicked = $(this).attr("id");
    $("#wijk").text(AreaClicked);
    AreaClickedLat = $(this).attr("id") + "Lat";
    AreaClickedLng = $(this).attr("id") + "Lng";
    $("#latArea").text(window[AreaClickedLat]);
    $("#lngArea").text(window[AreaClickedLng]);
    $("#wijk").parent().animate({ borderColor: "#fff" },"fast");
    $("#wijk").parent().animate({ borderColor: "#1370B8" });
    $(".wijkStroke").removeClass("AreaClicked");
    $(this).find("polygon").addClass("AreaClicked");
    $("#SelectArea, #WijkTitle").fadeOut("fast");
    $("#SelectArea, #WijkTitle").fadeIn();
});


$("g").mouseenter(function () {
    AreaHover = $(this).attr("id");
    $("#wijk").text(AreaHover);
});
$("g").mouseleave(function () {
    $("#wijk").text(AreaClicked);
});



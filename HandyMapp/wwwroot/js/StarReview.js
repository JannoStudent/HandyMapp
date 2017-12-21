$("path").hover(function () {
    var i;
    var starClass = $(this).attr("class").split(' ')[1];
    var starNumber = starClass.slice(4);
    $(this).removeClass("hoverColor").css('cursor', 'pointer');;
    for (i = 0; i <= 4; i++) {
        var starClassUnselected = ".star" + (i + 1);
        $(starClassUnselected).removeClass("hoverColor");
    }
    for (i = 0; i <= starNumber - 1; i++) {
        var starClassSelected = ".star" + (i + 1);
        $(starClassSelected).addClass("hoverColor");
        switch (starNumber) {
            case "1":
                $("#tekst").text("Very poor");
                break;
            case "2":
                $("#tekst").text("Poor");
                break;
            case "3":
                $("#tekst").text("Normal");
                break;
            case "4":
                $("#tekst").text("Good");
                break;
            case "5":
                $("#tekst").text("Very good");
                break;
        }
    }
});

$("path").click(function () {
    var starClassClicked = $(this).attr("class").split(' ')[1];
    var starNumberClicked = starClassClicked.slice(4);
    var i;
    for (i = 0; i <= 4; i++) {
        var starClassUnselected = ".star" + (i + 1);
        $(starClassUnselected).removeClass("colorSelected");
    }
    for (i = 0; i <= starNumberClicked - 1; i++) {
        var starClassSelected = ".star" + (i + 1);
        $(starClassSelected).addClass("colorSelected");
        $("#tekstDef").attr("value", starNumberClicked);
    }
});

$("svg").mouseleave(function () {
    $(this).find("path").removeClass("hoverColor");
    var starGrade = $("#tekstDef").val();
    switch (starGrade) {
        case "":
            $("#tekst").text("");
            break;
        case "1":
            $("#tekst").text("Very poor");
            break;
        case "2":
            $("#tekst").text("Poor");
            break;
        case "3":
            $("#tekst").text("Normal");
            break;
        case "4":
            $("#tekst").text("Good");
            break;
        case "5":
            $("#tekst").text("Very good");
            break;
    }
});
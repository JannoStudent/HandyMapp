$(function () {
    $(':input[type="submit"]').prop('disabled', true);
    $(':input[type="text"]').keyup(function () {
        if ($(this).val() !== '') {
            $(':button[type="submit"]').prop("disabled", false);
        }
    });
    $(".PlaceResult").click(function () {
        var rating = 5;//Variable input                            /*Bernhard*/
        var i;
        var objectId = "#" + $(this).find(".rating").attr("id");
        for (i = 0; i <= rating - 1; i++) {
            $(objectId + "> path.helft").eq(i).addClass("colorSelected");
            $(objectId + "> path.midden").eq(i / 2).addClass("colorSelected");
        };                                                              /*Bernhard*/
    });
    $("path").hover(function () {
        var i;
        var starClass =$(this).attr("class").split(' ')[1];
        var starNumber = starClass.slice(4);
        $(this).removeClass("hoverColor");
        for (i = 0; i <= 4; i++) {
            var starClassUnselected = ".star" + (i + 1);
            $(starClassUnselected).removeClass("hoverColor");
        }
        for (i = 0; i <= starNumber - 1; i++) {
            var starClassSelected = ".star" + (i + 1);
            $(starClassSelected).addClass("hoverColor");
            $("#tekst").text(starNumber);
        }
    });

    $("path").click(function() {
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
            console.log(starClassSelected);
        }
    });

    $("svg").mouseleave(function () {
        $(this).find("path").removeClass("hoverColor");
        $("#tekst").text("");
    });
    /*
    $(".PlaceResult").click(function () {
        if ($(this).css("height") === "200px") {
            $(".PlaceResult").animate({
                height: '200px'
            },
                { queue: false });
            $(this).animate({
                height: '455px'
            },
                { queue: false });
            $(".ImageContainter").animate({
                height: '110px'
            },
                { queue: false });
            $(this).find(".ImageContainter").animate({
                height: '200px'
            },
                { queue: false });
            $(this).siblings().find(".ImageContainter img").animate({
                marginTop: '-89'
            },
                { queue: false });
            $(this).find(".ImageContainter img").animate({
                marginTop: '-50'
            },
                { queue: false });
            $(this).find(".DescriptionContainer").slideDown({ queue: false });
            $(this).find(".btn").fadeIn({ queue: false });
        } else {
            $(this).animate({ height: "200px" });
            $(this).find(".ImageContainter img").animate({
                marginTop: '-89'
            },
                { queue: false });
            $(".ImageContainter").animate({
                height: '110px'
            },
                { queue: false });
            $(this).find(".DescriptionContainer").slideUp({ queue: false });
            $(this).find(".btn").fadeOut({ queue: false });
        }
        //var offset = $(this).offset().top;
        //$(this).parent().animate({ scrollTop: offset });
    });*/
});

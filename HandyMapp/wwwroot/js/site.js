﻿$(function () {
    $(':input[type="submit"]').prop('disabled', true);
    $(':input[type="text"]').keyup(function () {
        if ($(this).val() != '') {
            $(':button[type="submit"]').prop("disabled", false);
        }
    });
    $(".PlaceResult").click(function () {
        var rating = 5;//$("#gradeInput").val();                            /*Bernhard*/
        var i;
        var color = "#2ecc71";
        var object = $(this).parents(".PlaceTitle").attr("id");
        alert(object);
        for (i = 0; i <= rating - 1; i++) {
            $(".rating > path.helft").eq(i).css("fill", color);
            $(".rating > path.midden").eq(i / 2).css("fill", color);
        };                                                              /*Bernhard*/
    });/*
    $(".PlaceResult").click(function () {
        if ($(this).css("height") == "200px") {
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

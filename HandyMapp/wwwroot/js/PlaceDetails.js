$(function () {
    var rating = ($("#AvrageRatting").val() * 2); //Variable input                         
    var i;
    for (i = 0; i <= rating - 1; i++) {
        $("#averageRatingStars > path.helft").eq(i).addClass("colorSelected");
        $("#averageRatingStars > path.midden").eq(i / 2).addClass("colorSelected");
    }
     //Variable input         reviewRatting  
    var a;
    var reviewCounter = $(".ReviewStar").length;
    for (a = 0; a < reviewCounter; a++) {
        var starId = "#reviewRatting" + [a];
        var starHalfId = "#reviewRattingStars" + [a];
        var ratingReview = ($(starId).text() * 2);
        //console.log(starId);
        //console.log(ratingReview);
        var b;
        for (b = 0; b <= ratingReview - 1; b++) {
            $(starHalfId + "> path.helft").eq(b).addClass("colorSelected");
            $(starHalfId + "> path.midden").eq(b / 2).addClass("colorSelected");
        }
    }
    
    /*var objectId = "#" + $(this).find(".rating").attr("id");
    for (i = 0; i <= rating - 1; i++) {
        $(objectId + "> path.helft").eq(i).addClass("colorSelected");
        $(objectId + "> path.midden").eq(i / 2).addClass("colorSelected");
    } */
});
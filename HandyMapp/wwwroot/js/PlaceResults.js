$(function () {
    //Variable input         reviewRatting  
    var a;
    var reviewCounter = $(".PlaceResult").length;
    console.log(reviewCounter);
    for (a = 0; a < reviewCounter; a++) {
        var starId = "#rating" + [a];
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
});
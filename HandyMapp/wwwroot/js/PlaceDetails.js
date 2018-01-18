$(function () {
    var rating = ($("#AvrageRatting").val() * 2); //Variable input                         
    var i;
    for (i = 0; i <= rating - 1; i++) {
        $("#averageRatingStars > path.helft").eq(i).addClass("colorSelected");
        $("#averageRatingStars > path.midden").eq(i / 2).addClass("colorSelected");
    }

    var ratingReview = ($("#reviewRatting").text() * 2); //Variable input         reviewRatting        
    var b;
    console.log(ratingReview);
    for (b = 0; b <= ratingReview - 1; b++) {
        $("#reviewRattingStars > path.helft").eq(b).addClass("colorSelected");
        $("#reviewRattingStars > path.midden").eq(b / 2).addClass("colorSelected");
    }
});
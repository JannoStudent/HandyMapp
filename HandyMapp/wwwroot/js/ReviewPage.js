var questions = [
    "Are there ramps beside the stairs?",
    "Are there thresholds?",
    "Are there elevators?",
    "Are there wheelchair accessible toilets?",
    "Are hallways wide enough for wheelchairs?",
    "Are there loose tiles or floormats?"
];

var values = [
    "Description",
    "Ramps",
    "Threshold",
    "Elevators",
    "AccessibleToilets",
    "HallwaysWide",
    "LooseTilesOrFloormats"
];
var QuestionCounter = 0;

/*////////////////////////////////AUTOCOMPLETE////////////////// */

/*/////////////////////////////// DISPLAY NEXT QUESTION REVIEW///*/

$("#further").click(function () {
    $("#EndReview").fadeOut("slow");
    $("#EndReview").remove();
    $("#DetailsQuestions").text(questions[QuestionCounter]);
    $("#DetailsButtons, #DetailsQuestions, #DetailsQuestionsNumber").fadeIn("slow");
});

$("#DetailsButtons > div").click(function () {
    if (QuestionCounter < 5) {
        QuestionCounter += 1;
        $("#DetailsQuestions").text(questions[QuestionCounter]);
        $("#DetailsQuestionsNumber").text(QuestionCounter + 1 + "/6");
        $('#' + values[QuestionCounter]).val($(this).attr("id"));
        //$('#answers').append('<input name=' + values[QuestionCounter] + ' value=' + $(this).attr("id")+'/>');
    } else {
        QuestionCounter += 1;
        $('#' + values[QuestionCounter]).val($(this).attr("id"));
        //$('#answers').append('<input name=' + values[QuestionCounter] + ' value=' + $(this).attr("id") + '/>');
        $("#form").submit();
    }
});


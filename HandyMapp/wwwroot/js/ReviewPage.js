var questions = [
    "Are there ramps beside the stairs?",
    "Are there dorpels?",
    "Are there elevators?",
    "Are there wheelchair accessible toilets?",
    "Are hallways wide enough for wheelchairs?",
    "Are there loose tiles or floormats?"
];
var QuestionCounter = 0;



$("#further").click(function () {
    $("#EndReview").fadeOut("slow");
    $("#EndReview").remove();
    $("#DetailsButtons").fadeIn("slow");
    $("#DetailsQuestions").fadeOut("fast");
    $("#DetailsQuestions").text(questions[QuestionCounter]);
    $("#DetailsQuestions").fadeIn("fast");
});

$("#DetailsButtons > div").click(function () {
    $("#DetailsQuestions").text(questions[QuestionCounter]);
    QuestionCounter += 1;
    console.log(QuestionCounter);
});
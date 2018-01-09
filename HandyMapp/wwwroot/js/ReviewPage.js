﻿var questions = [
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
    $("#DetailsQuestions").text(questions[QuestionCounter]);
    $("#DetailsButtons, #DetailsQuestions, #DetailsQuestionsNumber").fadeIn("slow");
});

$("#DetailsButtons > div").click(function () {
    if (QuestionCounter < 5) {
        QuestionCounter += 1;
        $("#DetailsQuestions").text(questions[QuestionCounter]);
        $("#DetailsQuestionsNumber").text(QuestionCounter + 1 + "/6");
    }else {
        window.location.replace("http://localhost:55742/ReviewPlaces/ThankYouBuilding");
    }
});
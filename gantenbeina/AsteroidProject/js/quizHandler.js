var quiz;

var questions = [];

var questionIndex = 0;

var questionAnswered = false;

var choiceCards = [$('#choice0'), $('#choice1'), $('#choice2'), $('#choice3')];

//function getURLParam() {
//    var urlParam = new URLSearchParams(window.location.search);
//    var quizID;
//    if (urlParam.has('quizID'))
//        quizID = urlParam.get('quizID');
//    else
//        quizID = 'colorblind';
//    console.log(quizID);
//    return quizID;
//}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};

$(document).ready(function () { 
    GetQuiz();
    $("#quiz-title").text(quiz.name);
    $("#quiz-description").text(quiz.description);
    loadQuestion(questionIndex);
});

$("#btnNext").click(function () {
    $("#question").fadeOut("slow", function () { loadNext(); });
    $("#question").fadeIn();
});

$("#btnPrev").click(function () {
    $("#question").fadeOut("slow", function () { loadPrev(); });
    $("#question").fadeIn();
});

$("#btnLogIn").click(function(){
    try {
    var jsonfile = require("jsonfile");
    jsonfile.writeFile(questionFile, questionsfunction, function(err) {
            if (err) alert(err)
        });
    alert("done");
    }
    catch(err){
        console.log(err);
    }
});

function submitAnswer(choice){
    if(answered) return;

    answered = true;

    if(choice !== quiz.questions[questionIndex].answer){
        choiceCards[choice].addClass("bg-danger");
        $(".alert-danger").prepend("<strong>Incorrect!</strong> ").show("slow");
    }
    else{  
        $(".alert-success").prepend("<strong>Correct!</strong> ").show("slow");
    }

    choiceCards[quiz.questions[questionIndex].answer].addClass("bg-success");
    
    if(questionIndex !== 0)
        $("#btnPrev").removeAttr("disabled");
    if(questionIndex !== quiz.questions.length - 1)
        $("#btnNext").removeAttr("disabled");
}

function loadNext() {
    questionIndex = mod(++questionIndex, quiz.questions.length);
    loadQuestion(questionIndex);
}

function loadPrev() {
    i = mod(--questionIndex, quiz.questions.length);
    loadQuestion(questionIndex);
}

function loadQuestion(slideNum) {
    answered = false;
    $('#qText').text(quiz.questions[slideNum].text);
    $('#qImg').attr('src', quiz.questions[slideNum].image);
    choiceCards[0].find("p").text(quiz.questions[slideNum].choices[0]);
    choiceCards[1].find("p").text(quiz.questions[slideNum].choices[1]);
    choiceCards[2].find("p").text(quiz.questions[slideNum].choices[2]);
    choiceCards[3].find("p").text(quiz.questions[slideNum].choices[3]);
    $(".choice-card").removeClass("bg-success");
    $(".choice-card").removeClass("bg-danger");
    $("#btnPrev").attr("disabled", "disabled");
    $("#btnNext").attr("disabled", "disabled");
    $(".alert").text(quiz.questions[questionIndex].message).hide();
    submitAnswer(1);
}

function mod(n, m) {
    return ((n % m) + m) % m;
}

function Question(text, image, choices, answer, message) {
    this.text = text;
    this.image = image;
    this.choices = choices;
    this.answer = answer;
    this.message = message;
}

function GetQuiz() {
    $.ajaxSetup({ async: false });
    $.get('./assets/' + getUrlParameter('quizID') + '.json', function (data) {
        quiz = data;
    }, 'json');
    //$.ajax({
    //    url: 'https://alpha.ion.uwplatt.edu/gantenbeina/project/assets/info.json',
    //    type: "GET",
    //    dataType: "json",
    //    complete: function (data) {
    //        alert(data);
    //    },
    //});
    //$.ajax({
    //    error: function () { alert("error"); },
    //    type: "POST",
    //    url: "Quiz.aspx/getQuiz",
    //    data: JSON.stringify({ name: "colorblind" }),
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    async: true,
    //    success: function (response) {
    //        quiz = JSON.parse(response);
    //        alert(quiz.name);
    //        questions = quiz.questions;
    //    }
    //});
}
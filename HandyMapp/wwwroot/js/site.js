$(function () {
    $(".PlaceResult").click(function () {
        var rating = 10; //Variable input                          
        var i;
        var objectId = "#" + $(this).find(".rating").attr("id");
        for (i = 0; i <= rating - 1; i++) {
            $(objectId + "> path.helft").eq(i).addClass("colorSelected");
            $(objectId + "> path.midden").eq(i / 2).addClass("colorSelected");
        } 

        $("form > input").keyup(function () {

            var empty = false;
            $('form > input').each(function () {
                if ($(this).val() === '') {
                    empty = true;
                }
            });

            if (empty) {
                $("#submitButton").attr("disabled", "disabled");
            } else {
                $('#submitButton').removeAttr('disabled'); 
            }
        });
    });
});

$(".PlaceResultButton").click(function () {
    var description = $(this).parent('div.PlaceResult').children('div.DescriptionContainer');
    var imageContainter = $(this).parent('div.PlaceResult').children('div.ImageContainter');
    var image = $(this).parent('div.PlaceResult').children('div.ImageContainter').children('img');

    $(this).find('span').toggleClass('glyphicon-chevron-down').toggleClass('glyphicon-chevron-up');

    if (description.css("height") === "15px") {
        var curHeight = description.height();
        var autoHeight = description.css('height', 'auto').height() + 20;
        description.height(curHeight).animate({
            height: autoHeight
        });
        imageContainter.animate({
            height: (imageContainter.height() * 1.20)
        });
        image.animate({
            marginTop: (image.height() * 0.00)
        });

    } else {
        description.animate({
            height: '15px'
        });
        imageContainter.animate({
            height: (imageContainter.height() * 0.80)
        });
        image.animate({
            marginTop: -(image.height() * 0.10)
        });
    }
});


///AUTOCOMPLETE///////////////////////////////////////

var arrDescription = [];

$(".search").keypress(function (e) {
    fillautocomplete($(this));
    if (e.which === 13) {
        $(".ui-autocomplete").css("display", "none");
    }
});



function fillautocomplete(input) {
    $.ajax({
        type: "GET",
        url: '/api/Places/AutoComplete/' + input.val(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var form = "";
            arrDescription = [];
            for (var i = 0; i < result.predictions.length; i++) {
                arrDescription.push(result.predictions[i].description);
                form += '<input type="text" id="z' + i + '__Id" name="[' + i + '].Id" value="' + result.predictions[i].id + '">' +
                    '<input type="text" id="z' + i + '__PlaceId" name="[' + i + '].PlaceId" value="' + result.predictions[i].place_id + '">' +
                    '<input type="text" id="z' + i + '__Description" name="[' + i + '].Description" value="' + result.predictions[i].description + '">' +
                    '<input type="text" id="z' + i + '__Reference" name="[' + i + '].Reference" value="' + result.predictions[i].reference + '"><div> result terms</div>';
                for (var j = 0; j < result.predictions[i].terms.length; j++) {
                    form += '<input type="text" id="z' + i + '__Terms_' + j + '__Value" name="[' + i + '].Terms[' + j + '].Value" value="' + result.predictions[i].terms[j].value + '">' +
                        '<input type="text" id="z' + i + '__Terms_' + j + '__Offset" name="[' + i + '].Terms[' + j + '].Offset" value="' + result.predictions[i].terms[j].offset + '">';
                }
            }
            document.getElementById('hiddenForm').innerHTML = form;
        },
        error: window.errorFunc
    }).done(function () {
        input.autocomplete({
            source: arrDescription,
            position: { my: "left top ", at: "left+0 top+50" }
        });
    });
}

////////////////////////////////////////////DISABLE BUTTON////////////////////
$('#placeInputSubmit').click(function () {
    if ($('#search').val("")) {
        alert("hallo");
    }
});


///////////////////////////////////////////////////////////////////////////////////



/*
window.addEventListener("load", function () {
    window.cookieconsent.initialise({
        "palette": {
            "popup": {
                "background": "#fec20f"
            },
            "button": {
                "background": "#000000"
            }
        },
        "theme": "classic"
    });
});*/
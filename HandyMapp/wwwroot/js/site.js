$(function () {
    //$(':input[type="submit"]').prop('disabled', true);
    /*$(':input[type="text"]').keyup(function () {
        if ($(this).val() !== '') {
            $(':button[type="submit"]').prop("disabled", false);
        }
    });*/
    $(".PlaceResult").click(function () {
        var rating = 10;//Variable input                            /*Bernhard*/
        var i;
        var objectId = "#" + $(this).find(".rating").attr("id");
        for (i = 0; i <= rating - 1; i++) {
            $(objectId + "> path.helft").eq(i).addClass("colorSelected");
            $(objectId + "> path.midden").eq(i / 2).addClass("colorSelected");
        }                                                              /*Bernhard*/
        
    });
    /*
    $(".PlaceResult").click(function () {
        if ($(this).css("height") === "200px") {
            $(".PlaceResult").animate({
                height: '200px'
            },{ queue: false });
            $(this).animate({
                height: 'auto'
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
});


///AUTOCOMPLETE///////////////////////////////////////

var arrDescription = [];

$(".search").keypress(function(e) {
    if ($(".search").val().length >= 3) {
        fillautocomplete();
        if (e.which === 13)
        {
            $("input:text").val(arrDescription[0]);
            $(".ui-autocomplete").css("display", "none");
        }
    }
});



function fillautocomplete() {
    $.ajax({
        type: "GET",
        url: '/api/Places/AutoComplete/' + $(".search").val(),
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
        $(".search").autocomplete({
            source: arrDescription,
            position: { my: "left top ", at: "left+0 top+50" }
        });
    });
}

///////////////////////////////////////////////////////////////////////////////////


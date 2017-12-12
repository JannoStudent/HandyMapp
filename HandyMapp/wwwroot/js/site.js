    $(function () {
        $(':input[type="submit"]').prop('disabled', true);
        $(':input[type="text"]').keyup(function () {
            if ($(this).val() != '') {
                $(':button[type="submit"]').prop("disabled", false);
            }
        });
        $("#grade").click(function() {
            var rating = $("#gradeInput").val()-1;
            var i;
            for (i = 0; i <= rating; i++) {
                $(".rating > path.helft").eq(i).css("fill", "#1370B8");
                $(".rating > path.midden").eq(i / 2).css("fill", "#1370B8");
            }
        });
    });

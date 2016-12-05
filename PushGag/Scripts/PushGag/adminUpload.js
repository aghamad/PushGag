$(".typeText").hide();
$(".typeVideo").hide();
$(".typeImage").hide();


$(".type-section li").click(function () {
    $(this).addClass("active");
    if ($(this).text() == "Text") {
        $(".typeVideo").hide();
        $(".typeImage").hide();
        $(".typeText").show();
    }
    if ($(this).text() == "Video") {
        $(".input-text").val("");
        $(".typeText").hide();
        $(".typeImage").hide();
        $(".typeVideo").show();
    }
    if ($(this).text() == "Image") {
        $(".typeText").hide();
        $(".typeVideo").hide();
        $(".typeImage").show();
    }
});


$(".testButton").click(function () {
    console.log('working');
    //$(".mainContainer").toggle("slow");

    $(".individualProduct").toggleClass("active", 500, "easeOutSine");
});

$(".learnMore").click(function () {

    $(".alignCenter").nextAll(".moreResources").eq(0).slideToggle();
})



function next(x) {
    var total = $(".productParent").children().length;
    for (var i = 0; i< total; i = i+x)
    {
        if( $(".productParent").children().eq(i).is(":visible")===true)
        {
            $(".productParent").children().eq(i).hide();
            $(".productParent").children().eq(i + x).show();
            if (i+1 === total)
            {
                $(".productParent").children().eq(0).show();
            }


            //debugger;


            return "working";
        }
    }

    $(".productParent").children().eq(0).show();



}


$(".next").click(function () {
    next(1);
});


$('.prev').click(function () {

    next(-1);

});
window.onload = next(1);

//var myInter = setInterval(function myInterval () {
//    next(1);
//}, 5000);


$('.showReview').click(function () {
    $(".leaveReview").toggle("slow");
    clearInterval(myInter)
})

$('.rate label').click(function () {
    $(this).prev().prop("checked", true);
})

$(':radio').change(
  function () {
      var text = parseInt(this.value);
      $('.testStars').val(text);
  }
)

$('.tweet').submit(function (event) {
    event.preventDefault();
    console.log("tweeting!");
    debugger;
    $.ajax({
        url: '/../Category/Tweet/',
        type: 'POST',
        dataType: 'json',
        data: $(this).serialize(),
        success: function (result) {
            console.log(result);
            $(".tweetNumber").text(result);
        }
    });

    console.log("endTweet!");
});


$(".showProducts").click(function () {
    $(this).parent().next().next().next().fadeToggle("slow");
})
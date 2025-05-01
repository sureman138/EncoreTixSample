$(document).ready(function () {
    $(".attraction-row").click(function () {
        let attractionId = $(this).find('.attractionId').data('id');
        let attractionName = $(this).find('.attractionName').data('name');
        let imageUrl = $(this).find('.imageUrl').data('imageurl');
        let twitterUrl = $(this).find('.twitterUrl').data('twitter');
        let youTubeUrl = $(this).find('.youTubeUrl').data('youtube');
        let spotifyUrl = $(this).find('.spotifyUrl').data('spotify');
        let homePageUrl = $(this).find('.homePageUrl').data('homepage');

        $("#attractionId").val(attractionId);
        $("#attractionName").val(attractionName);
        $("#imageUrl").val(imageUrl);
        $("#twitterUrl").val(twitterUrl);
        $("#youTubeUrl").val(youTubeUrl);
        $("#spotifyUrl").val(spotifyUrl);
        $("#homePageUrl").val(homePageUrl);
    });
});

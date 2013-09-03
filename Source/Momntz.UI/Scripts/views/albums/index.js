function getItems(getData) {
    var last = $('input#lastalbumid');
    var username = $('input#username').val();

    function executeOnData(data) {

        if (data != null && data.length > 0) {
            var item = data[data.length - 1];
            last.val(item.Id);

            getData(data);
        }
    }

    $.post('/api/scroll/albumscroll?albumid=' + last.val() + '&username='+ username, executeOnData);
}

function getTemplate() { return $("#album-template").html(); }

$(function () {

    $("a#triggerAlbumAdd").leanModal({ closeButton: "button#cancelAlbum" });
    $("button#createalbum").click(function () {

        var name = $("input#albumName");
        var story = $("textarea#albumStory");

        var c = $('#container');

        $.post('/api/albums/new', { name: name.val(), story: story.val() }, function (data) { prependTiles(data, c); });

        $("#lean_overlay").fadeOut(200);
        $('#addAlbum').css({ 'display': 'none' });

        name.val('');
        story.val('');
    });
});


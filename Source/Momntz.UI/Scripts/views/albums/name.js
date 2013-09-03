function getItems(getData) {
    var last = $('input#lastmomentid');
    var albumId = $('input#albumId');
    var username = $('input#username').val();

    function executeOnData(data) {

        var item = data[data.length - 1];
        if (item !== undefined) {
            last.val(item.Id);
        }

        getData(data);
    }

    $.post('/api/scroll/TileScroll?albumid=' + albumId.val() + '&momentoid=' + last.val() + '&username=' + username, executeOnData);
}

function getTemplate() {
    return $("#entry-template").html();
}

$(function () {
    Dropzone.options.upload = {
        init: function () {
            this.on("sending", function (file, xhr, formData) {
                var albumId = $("input#albumId").val();
                formData.append("albumid", albumId);
            });

            this.on("complete", function (file) {
                var albumId = $("input#albumId").val();
                var c = $('#container');
                $.post('/api/momentomedia/GetNewlyAddedAlbumPhoto?filename=' + file.name + '&size=' + file.size + '&albumid=' + albumId, function (data) {

                    var last = $('input#lastmomentid');
                    var item = data[data.length - 1];
                    last.val(item.Id);

                    prependTiles(data, c);
                });
            });
        }
    };
});
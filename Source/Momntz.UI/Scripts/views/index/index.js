function getItems(addTiles) {
    var last = $('input#lastmomentid');

    $.post('/api/scroll/userscroll?username=@Model.Username&momentoid=' + last.val(), function (data) {

        var item = data[data.length - 1];
        if (item !== undefined) {
            last.val(item.Id);
        }

        addTiles(data);
    });
}

function getTemplate() {
    return $("#entry-template").html();
}


$(function () {
    Dropzone.options.upload = {
        init: function () {
            this.on("complete", function (file) {
                var c = $('#container');
                $.post('/api/momentomedia/GetNewlyAddedPhoto?filename=' + file.name + '&size=' + file.size, function (data) {

                    var last = $('input#lastmomentid');
                    var item = data[data.length - 1];
                    last.val(item.Id);

                    prependTiles(data, c);
                });
            });
        }
    };
});
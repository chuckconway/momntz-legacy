
var container = $('#container');

function addTiles(data) {

    if (data != null && data.length > 0) {
        var source = getTemplate();
        var template = Handlebars.compile(source);

        var html = '';

        for (var index = 0; index < data.length; index++) {

            html = html + template(data[index]);
        }

        html = $($.trim(html));

        html.imagesLoaded(function () {
            $('div#loading').remove();
            container.append(html);
            container.masonry('appended', html, true);
        });
    } else {
        $('div#loading').remove();
    }
}

function prependTiles(data) {

    if (data != null && data.length > 0) {

        var source = getTemplate();
        var template = Handlebars.compile(source);

        var html = '';

        for (var index = 0; index < data.length; index++) {

            html = html + template(data[index]);
        }

        html = $($.trim(html));

        html.imagesLoaded(function () {
            $('div#loading').remove();
            container.prepend(html);
            container.masonry('prepended', html, true);
        });
    } else {
        $('div#loading').remove();
    }
}


$(window).scroll(function () {

    var scrollTop = $(window).scrollTop();
    var documentHeight = $(document).height();
    var windowHieght = $(window).height();

    if (scrollTop == (documentHeight - windowHieght)) {

        if ($('div#loading').length == 0) {

            $('<div id="loading"><img src="/Content/images/spinner.gif" title="Spinner " /></div>').insertAfter(container);

            getItems(addTiles);
        }
    }
});

$(function () {

    $('button#addimages').click(function () {
        if ($("div#add").is(":hidden")) {
            $("div#add").show("slow");
        } else {
            $("div#add").slideUp();
        }
    });

    container.imagesLoaded(function () {
        container.masonry({
            itemSelector: '.box',
            columnWidth: 10
        });
    });

    // Lightbox Init
    var fancyboxArgs = {
        padding: 0,
        overlayColor: "#000",
        autoScale: false,
        overlayOpacity: 0.85,
        loadDetails: function (c, image) {

            var view = new afterLoad();
            view.load(this, c, image);
        }
    };
    $("a[rel='lightbox']").fancybox(fancyboxArgs);
});




//Edit View
//1. title
//2. story
//3. albumns
//4. date

function editView() {

    this.load = function(data, container, refreshViewCallback) {
        var tplt = jQuery(this.html());
        
        var title = tplt.find('input#title'); //.val(data.title);
        var story = tplt.find('input#story'); //.val(data.story);
        var day = tplt.find('select#day'); //.val(data.day);
        var month = tplt.find('select#month'); //.val(data.month);
        var year = tplt.find('input#year'); //.val(data.year);
        var albums = tplt.find('input#albums'); //.val(data.albums);

        title.val(data.title);
        story.val(data.story);
        day.val(data.day);
        month.val(data.month);
        year.val(data.year);
        albums.val(data.albums);

        tplt.find('input#save').click(function () {
            jQuery.post('/api/momento/', { title: title.val(), story: story.val(), day: day.val(), month: month.val(), year: year.val(), albums: albums.val() });

            refreshViewCallback(container);
        });

        container.empty();
        container.append(tplt);
    };

    this.html = function() {
        return '<input id="title" type="text" class="inputField" value="Title?" /> ' +
            '<input id="story" type="text" class="inputField" value="Is there a story?" />' +
            '<div id="date" class="inputField" >' +
            '<select id="day" >' +
            '<option>Day</option>' +
            '<option>1</option>' +
            '<option>2</option>' +
            '<option>3</option>' +
            '<option>4</option>' +
            '<option>5</option>' +
            '<option>6</option>' +
            '<option>7</option>' +
            '<option>8</option>' +
            '<option>9</option>' +
            '<option>10</option>' +
            '<option>11</option>' +
            '<option>12</option>' +
            '<option>13</option>' +
            '<option>14</option>' +
            '<option>15</option>' +
            '<option>16</option>' +
            '<option>17</option>' +
            '<option>18</option>' +
            '<option>19</option>' +
            '<option>20</option>' +
            '<option>21</option>' +
            '<option>22</option>' +
            '<option>23</option>' +
            '<option>24</option>' +
            '<option>25</option>' +
            '<option>26</option>' +
            '<option>27</option>' +
            '<option>28</option>' +
            '<option>29</option>' +
            '<option>30</option>' +
            '<option>31</option>' +
            '</select>' +
            '<select id="month" >' +
            '<option>Month</option>' +
            '<option value="1">January</option>' +
            '<option value="2">February</option>' +
            '<option value="3">March</option>' +
            '<option value="4">April</option>' +
            '<option value="5">May</option>' +
            '<option value="6">June</option>' +
            '<option value="7">July</option>' +
            '<option value="8">August</option>' +
            '<option value="9">September</option>' +
            '<option value="10">October</option>' +
            '<option value="11">November</option>' +
            '<option value="12">December</option>' +
            '</select>' +
            '<input id="year" maxlength="4" type="text" value="Year" />' +
            '</div>' +
            '<input id="albumns" class="inputField" type="text" value="Add to an album" />' +
            '<input id="save" type="submit" class="inputField" value="Save"  />';
    };
}

function readView() {

    this.load = function(data, container) {

        container.append(this.html());

        var title = container.children('span#title');
        var story = container.find('div#story');
        var day = container.find('span#day');
        var month = container.find('span#month');
        var year = container.find('span#year');
        var albums = container.find('span#albums');
        var people = container.find('span#people');
        var location = container.find('span#location');
        var addedDate = container.find('span#addedDate');
        var addedBy = container.find('span#addedBy');
        
        var edit = container.find('input#editdetails');
        var addlocation = container.find('input#addlocation');
        var tagpeople = container.find('input#tagpeople');

        title.text(data.Title);
        story.text(data.Story);

        if (data.Albums != null && data.Albums.length > 0) {
            albums.text('In ');

            for (var index = 0; index < data.Albums.length; index++) {
                albums.append(jQuery('<a>').attr('href', '/' + data.Username + '/albums/' + encodeURI(data.Albums[index])).text(data.Albums[index]));
                
                if (data.Albums.length > 2 && index < data.Albums.length -1) {
                    albums.append(', ');
                }
                
                if(data.Albums.length > 1 && index == data.Albums.length -2) {
                    albums.append(' and ');
                }
            }

            albums.append(' albums.');
        }

        if (data.Month != null) {
            month.text('Taken ' + data.Month);
        }

        if (data.Day != null) {
            day.text(data.Day);
        }
        
        if (data.Day != null) {
            year.text(', ' +data.Year);
        }
        
        if (data.Location != null) {
            location.text(' in ' + data.Location);
        }

        if (data.People != null && data.People.length > 0) {
            people.text(' with ');

            for (var i = 0; i < data.People.length; i++) {
                people.append(jQuery('<a>').attr('href', '/' + data.People[i].Username).text(data.People[i].DisplayName));
             
                if (data.People.length > 2 && i < data.People.length - 1) {
                    people.append(', ');
                }

                if (data.People.length > 1 && i == data.People.length - 2) {
                    people.append(' and ');
                }
            }

        }
        
        addedBy.text('Added by ').append(jQuery('<a>').attr('href', '/' + data.AddedUsername + '/').text(data.DisplayName));
        addedDate.text('on ' + data.Added);
     };

    this.html = function() {
        return '<br style="clear:both;margin:0;padding:0;" />' +
            '<span id="title"></span>' +
            '<div id="story"></div>' +
            '<span id="month"></span>' +
            '<span id="day"></span>' +
            '<span id="year"></span>' +
            '<span id="location"></span>' +
            '<span id="people"></span>' +
            '<span id="albums"></span>' +
            '<span id="addedBy"></span>' +
            '<span id="addedDate"></span>' +
            '<a id="editdetails" href="#" >Edit</a> &#183; ' +
            '<a id="addlocation" href="#" >Location</a > &#183; ' +
            '<a id="tagpeople" href="#" >Tag</a>';
    };
    
}

//Location View
//1. location (name of location, zip code, gps)



//Tag
//1. select people and their names.

function afterLoad() {
    this.load = function(fancybox, container) {
        var id = jQuery(fancybox.element.outerHTML).attr('id');
        //var container = jQuery('div#fancybox-content');

        jQuery.post('/api/momento/byid?id=' + id, function(data) {
            var rv= new readView();
            rv.load(data, container);
        });

    };
}




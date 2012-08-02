


//Edit View
//1. title
//2. story
//3. albumns
//4. date
//5.location

function editView() {

    this.load = function(data, container, refreshViewCallback) {

        container.empty();
        container.append(this.html());
        
        var title = container.find('input#title'); //.val(data.title);
        var story = container.find('textarea#story'); //.val(data.story);
        var day = container.find('select#day'); //.val(data.day);
        var month = container.find('select#month'); //.val(data.month);
        var year = container.find('input#year'); //.val(data.year);
        var albums = container.find('input#albums'); //.val(data.albums);
        var location = container.find('input#location');

        title.val(data.title);
        story.val(data.story);
        day.val(data.day);
        month.val(data.month);
        year.val(data.year);
        albums.val(data.albums);
        location.val(data.location);

        container.find('input#done').click(function () {
            jQuery.post('/api/momento/save', { id: data.Id, title: title.val(), story: story.val(), day: day.val(), month: month.val(), year: year.val(), albums: albums.val() });

            refreshViewCallback(container);
        });

    };

    this.html = function() {
        return ' <br style="clear:both;" />' +
            '<label>Title</label>' +
            '<input id="title" type="text" class="inputField" /> ' +
            '<label>Story</label>' +
            '<textarea id="story" class="inputField" ></textarea>' +
            '<label>Date</label>' +
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
            '<label>Location</label>' +
            '<input id="location" class="inputField" type="text" value="Location?" />' +
            '<label>Albums</label>' +
            '<input id="albumns" class="inputField" type="text" value="Add to an album" />' +
            '<input id="done" type="submit" class="inputField" value="Done"  />';
    };
}

function readView() {

    this.load = function(data, container, image) {

       //var item = jQuery('div.photoTag');

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

        var photoTag = container.find('a#tagpeople');
        photoTag.click(function () {
         
            
            
        });
        
        
        var edit = container.find('a#editdetails');
        edit.click(function () {
            var eview = new editView();
            eview.load(data, container, new readView().load);
            return false;
        });

        //var tagpeople = container.find('a#tagpeople');

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

        month.text('Taken ');


        var monthSet = false;
        if (data.Month != null && data.Month.length > 0) {
            monthSet = true;
            month.append(data.Month);
        }

        if (data.Day != null) {
            day.text(data.Day);
        }
        
        if (data.Day != null && monthSet) {
            
            year.text(', ' +data.Year);
        }
        
        if (data.Location != null) {
            location.text(' in ' + data.Location);
        }

        if (data.People != null && data.People.length > 0) {
            people.text(' with ');

            for (var i = 0; i < data.People.length; i++) {
                people.append(jQuery('<a>').attr('href', '/' + data.People[i].Username).text(data.People[i].Name));
             
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
        
        jQuery('img.phototag', image).photoTag({
            requesTagstUrl: '/api/tags/retrieve',
            deleteTagsUrl: '/api/tags/delete',
            addTagUrl: '/api/tags/add',
            externalAddTagLinks: {
                bind: true,
                selector: "a.addTag"
            },
            parametersForNewTag: {
                name: {
                    parameterKey: 'name',
                    isAutocomplete: true,
                    autocompleteUrl: '/api/tags/names',
                    label: 'Name'
                }
            }
        });
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
            '<a class="addTag" href="#" >Tag people</a>';
    };
    
}

//Location View
//1. location (name of location, zip code, gps)



//Tag
//1. select people and their names.

function afterLoad() {
    this.load = function(fancybox, container, image) {
        var id = jQuery(fancybox.element.outerHTML).attr('id');
        //var container = jQuery('div#fancybox-content');

        jQuery.post('/api/momento/byid?id=' + id, function(data) {
            var rv= new readView();
            rv.load(data, container, image);
        });

    };
}




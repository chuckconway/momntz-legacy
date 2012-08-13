


//Edit View
//1. title
//2. story
//3. albumns
//4. date
//5.location

function editView() {

    this.load = function(data, container, image) {

        container.empty();
        container.append(this.html());
        
        var title = container.find('input#title'); //.val(data.title);
        var story = container.find('textarea#story'); //.val(data.story);
        var day = container.find('select#day'); //.val(data.day);
        var month = container.find('select#month'); //.val(data.month);
        var year = container.find('input#year'); //.val(data.year);
        var albums = container.find('ul#albums');
        var location = container.find('input#location');

        location.autocomplete({
            minLength: 2,
            source: function (request, response) {
                jQuery.ajax({
                    url: "/api/momento/locationsearch",
                    data: { term: request.term },
                    success: function (data) {
                        response(data);
                    }
                });
            }
        });

        title.val(data.Title);
        story.val(data.Story);
        
        day.val(data.Day);
        month.val(data.Month);
        year.val(data.Year);

        location.val(data.Location);
        
        if (data.Albums.length > 0) {

            for (var index = 0; index < data.Albums.length; index++) {
                var name = data.Albums[index];
                albums.append('<li>' + name + '</li>');
            }
        }

        albums.tagit({
            singleField: true,
            singleFieldNode: jQuery('input#myalbums'),
            allowSpaces: true,
            minLength: 2,
            removeConfirmation: true,
            onTagAdded: function (event, tag) {
                jQuery.get("/api/albums/add",{ tag: tag, momentoId: data.Id });
            },
            
            onTagRemoved:function (event, tag) {
                jQuery.get("/api/albums/remove", { tag: tag, momentoId: data.Id });
            },
            tagSource: function (request, response ) {
                jQuery.ajax({
                        url: "/api/albums/index",
                        data: { term: request.term},
                        success: function (data) {
                            response(data);
                        }
                    });
            }
        });
        
        container.find('input#done').click(function () {
            jQuery.post('/api/momento/save', { id: data.Id, title: title.val(), story: story.val(), day: day.val(), month: month.val(), year: year.val(), albums: albums.val(), location: location.val() });

            var al = new afterLoad();
            al.internalLoad(data.Id, container, image);
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
            '<option value="1">Jan</option>' +
            '<option value="2">Feb</option>' +
            '<option value="3">Mar</option>' +
            '<option value="4">Apr</option>' +
            '<option value="5">May</option>' +
            '<option value="6">Jun</option>' +
            '<option value="7">Jul</option>' +
            '<option value="8">Aug</option>' +
            '<option value="9">Sep</option>' +
            '<option value="10">Oct</option>' +
            '<option value="11">Nov</option>' +
            '<option value="12">Dec</option>' +
            '</select>' +
            '<input id="year" maxlength="4" type="text" value="Year" />' +
            '</div>' +
            '<label>Location</label>' +
            '<input id="location" class="inputField" type="text" value="" />' +
            '<label>Albums <span style="font-weight:normal;">(<a href="#">?</a>)</span></label>' +
            '<input type="hidden" name="tags" id="myalbums" disabled="true">' +
            '<ul id="albums"></ul>' +
            '<input id="done" type="submit" class="inputField" value="Done"  />';
    };
}

function readView() {

    this.convertNumberToMonth = function(number) {
        var month = new Array();
        month[0] = "January";
        month[1] = "February";
        month[2] = "March";
        month[3] = "April";
        month[4] = "May";
        month[5] = "June";
        month[6] = "July";
        month[7] = "August";
        month[8] = "September";
        month[9] = "October";
        month[10] = "November";
        month[11] = "December";

        return month[number - 1];
    };

    var self = this;
    this.load = function(data, container, image) {

        container.empty();
        container.append(self.html());

        var title = container.children('span#title');
        var story = container.find('div#story');
        var whowhenwhere = container.find('span#whowhenwhere');
        var albums = container.find('span#albums');
        var addedDate = container.find('span#addedDate');
        var addedBy = container.find('span#addedBy');
       
        
        var edit = container.find('a#editdetails');
        edit.click(function () {
            var eview = new editView();
            eview.load(data, container, image);
            return false;
        });

        title.text(data.Title);
        story.text(data.Story);
        
        if (title.text().length == 0) {
            title.remove();
        }
        
        if(story.text().length == 0) {
            story.remove();
        }

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
        } else {
            albums.remove();
        }

        var yearSet = data.Year != null && data.Year.length > 0;
        var monthSet = data.Month != null && data.Month.length > 0;
        var daySet = data.Day != null && data.Day.length > 0;

        if ((monthSet) ||
            (yearSet) ||
            (daySet) ||
             data.People != null && data.People.length > 0 ||
            (data.Location != null && data.Location.length > 0)) {

            whowhenwhere.text('Taken ');
        }

        var text = '';
        var value = '';
        
        if (yearSet & !monthSet & !daySet) {
            text = data.Year;
            value = data.Year;
        }
        

        if (monthSet & yearSet & !daySet) {
            text = self.convertNumberToMonth(data.Month) + ' ' + data.Year;
            value = data.Year + '/' + data.Month;
        }
        
        if (daySet && monthSet && yearSet) {
            text = self.convertNumberToMonth(data.Month) + ' ' + data.Day + ', ' + data.Year;
            value = data.Year + '/' + data.Month + '/' + data.Day;
        }
        
        if (text.length > 0) {
            whowhenwhere.append(jQuery('<a>').attr('href', '/' + data.Username + '/' + value).text(text));
        }
        
        if (data.Location != null && data.Location.length > 0) {
            whowhenwhere.append(' in ' + data.Location);
        }
        
        if (whowhenwhere.text().length == 0) {
            whowhenwhere.remove();
        }

        if (data.People != null && data.People.length > 0) {
            whowhenwhere.append(' with ');

            for (var i = 0; i < data.People.length; i++) {
                whowhenwhere.append(jQuery('<a>').attr('href', '/' + data.People[i].Username).text(data.People[i].Name));
             
                if (data.People.length > 2 && i < data.People.length - 1) {
                    whowhenwhere.append(', ');
                }

                if (data.People.length > 1 && i == data.People.length - 2) {
                    whowhenwhere.append(' and ');
                }
            }

        }
        
        addedBy.text('Added by ').append(jQuery('<a>').attr('href', '/' + data.AddedUsername + '/').text(data.DisplayName));
        addedDate.text('on ').append(jQuery('<a>').attr('href', '/' + data.AddedUsername + '/added/' + data.AddedUrl).text(data.Added));
        
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
            '<span id="whowhenwhere"></span>' +
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
    var self = this;
    this.load = function(fancybox, container, image) {
        var id = jQuery(fancybox.element.outerHTML).attr('id');
        //var container = jQuery('div#fancybox-content');

        self.internalLoad(id, container, image);
    };

    this.internalLoad = function(id, container, image) {
        jQuery.post('/api/momento/byid?id=' + id, function (data) {
            var rv = new readView();
            data.Id = id;
            rv.load(data, container, image);
        });
    };
}




/* VIT */
(function($){$.fn.vit=function(options){var settings={'parent':this.parent().height(),'offset':0};if(options){$.extend(settings,options);}
return this.each(function(){var myHeight=$(this).height();$(this).css('margin-top',((settings.parent-myHeight)/2)+settings.offset);});};})(jQuery);

/**
 * Isotope v1.5.19
 * An exquisite jQuery plugin for magical layouts
 * http://isotope.metafizzy.co
 *
 * Commercial use requires one-time license fee
 * http://metafizzy.co/#licenses
 *
 * Copyright 2012 David DeSandro / Metafizzy
 */
(function(a,b,c){"use strict";var d=a.document,e=a.Modernizr,f=function(a){return a.charAt(0).toUpperCase()+a.slice(1)},g="Moz Webkit O Ms".split(" "),h=function(a){var b=d.documentElement.style,c;if(typeof b[a]=="string")return a;a=f(a);for(var e=0,h=g.length;e<h;e++){c=g[e]+a;if(typeof b[c]=="string")return c}},i=h("transform"),j=h("transitionProperty"),k={csstransforms:function(){return!!i},csstransforms3d:function(){var a=!!h("perspective");if(a){var c=" -o- -moz- -ms- -webkit- -khtml- ".split(" "),d="@media ("+c.join("transform-3d),(")+"modernizr)",e=b("<style>"+d+"{#modernizr{height:3px}}"+"</style>").appendTo("head"),f=b('<div id="modernizr" />').appendTo("html");a=f.height()===3,f.remove(),e.remove()}return a},csstransitions:function(){return!!j}},l;if(e)for(l in k)e.hasOwnProperty(l)||e.addTest(l,k[l]);else{e=a.Modernizr={_version:"1.6ish: miniModernizr for Isotope"};var m=" ",n;for(l in k)n=k[l](),e[l]=n,m+=" "+(n?"":"no-")+l;b("html").addClass(m)}if(e.csstransforms){var o=e.csstransforms3d?{translate:function(a){return"translate3d("+a[0]+"px, "+a[1]+"px, 0) "},scale:function(a){return"scale3d("+a+", "+a+", 1) "}}:{translate:function(a){return"translate("+a[0]+"px, "+a[1]+"px) "},scale:function(a){return"scale("+a+") "}},p=function(a,c,d){var e=b.data(a,"isoTransform")||{},f={},g,h={},j;f[c]=d,b.extend(e,f);for(g in e)j=e[g],h[g]=o[g](j);var k=h.translate||"",l=h.scale||"",m=k+l;b.data(a,"isoTransform",e),a.style[i]=m};b.cssNumber.scale=!0,b.cssHooks.scale={set:function(a,b){p(a,"scale",b)},get:function(a,c){var d=b.data(a,"isoTransform");return d&&d.scale?d.scale:1}},b.fx.step.scale=function(a){b.cssHooks.scale.set(a.elem,a.now+a.unit)},b.cssNumber.translate=!0,b.cssHooks.translate={set:function(a,b){p(a,"translate",b)},get:function(a,c){var d=b.data(a,"isoTransform");return d&&d.translate?d.translate:[0,0]}}}var q,r;e.csstransitions&&(q={WebkitTransitionProperty:"webkitTransitionEnd",MozTransitionProperty:"transitionend",OTransitionProperty:"oTransitionEnd",transitionProperty:"transitionEnd"}[j],r=h("transitionDuration"));var s=b.event,t;s.special.smartresize={setup:function(){b(this).bind("resize",s.special.smartresize.handler)},teardown:function(){b(this).unbind("resize",s.special.smartresize.handler)},handler:function(a,b){var c=this,d=arguments;a.type="smartresize",t&&clearTimeout(t),t=setTimeout(function(){jQuery.event.handle.apply(c,d)},b==="execAsap"?0:100)}},b.fn.smartresize=function(a){return a?this.bind("smartresize",a):this.trigger("smartresize",["execAsap"])},b.Isotope=function(a,c,d){this.element=b(c),this._create(a),this._init(d)};var u=["width","height"],v=b(a);b.Isotope.settings={resizable:!0,layoutMode:"masonry",containerClass:"isotope",itemClass:"isotope-item",hiddenClass:"isotope-hidden",hiddenStyle:{opacity:0,scale:.001},visibleStyle:{opacity:1,scale:1},containerStyle:{position:"relative",overflow:"hidden"},animationEngine:"best-available",animationOptions:{queue:!1,duration:800},sortBy:"original-order",sortAscending:!0,resizesContainer:!0,transformsEnabled:!b.browser.opera,itemPositionDataEnabled:!1},b.Isotope.prototype={_create:function(a){this.options=b.extend({},b.Isotope.settings,a),this.styleQueue=[],this.elemCount=0;var c=this.element[0].style;this.originalStyle={};var d=u.slice(0);for(var e in this.options.containerStyle)d.push(e);for(var f=0,g=d.length;f<g;f++)e=d[f],this.originalStyle[e]=c[e]||"";this.element.css(this.options.containerStyle),this._updateAnimationEngine(),this._updateUsingTransforms();var h={"original-order":function(a,b){return b.elemCount++,b.elemCount},random:function(){return Math.random()}};this.options.getSortData=b.extend(this.options.getSortData,h),this.reloadItems(),this.offset={left:parseInt(this.element.css("padding-left")||0,10),top:parseInt(this.element.css("padding-top")||0,10)};var i=this;setTimeout(function(){i.element.addClass(i.options.containerClass)},0),this.options.resizable&&v.bind("smartresize.isotope",function(){i.resize()}),this.element.delegate("."+this.options.hiddenClass,"click",function(){return!1})},_getAtoms:function(a){var b=this.options.itemSelector,c=b?a.filter(b).add(a.find(b)):a,d={position:"absolute"};return this.usingTransforms&&(d.left=0,d.top=0),c.css(d).addClass(this.options.itemClass),this.updateSortData(c,!0),c},_init:function(a){this.$filteredAtoms=this._filter(this.$allAtoms),this._sort(),this.reLayout(a)},option:function(a){if(b.isPlainObject(a)){this.options=b.extend(!0,this.options,a);var c;for(var d in a)c="_update"+f(d),this[c]&&this[c]()}},_updateAnimationEngine:function(){var a=this.options.animationEngine.toLowerCase().replace(/[ _\-]/g,""),b;switch(a){case"css":case"none":b=!1;break;case"jquery":b=!0;break;default:b=!e.csstransitions}this.isUsingJQueryAnimation=b,this._updateUsingTransforms()},_updateTransformsEnabled:function(){this._updateUsingTransforms()},_updateUsingTransforms:function(){var a=this.usingTransforms=this.options.transformsEnabled&&e.csstransforms&&e.csstransitions&&!this.isUsingJQueryAnimation;a||(delete this.options.hiddenStyle.scale,delete this.options.visibleStyle.scale),this.getPositionStyles=a?this._translate:this._positionAbs},_filter:function(a){var b=this.options.filter===""?"*":this.options.filter;if(!b)return a;var c=this.options.hiddenClass,d="."+c,e=a.filter(d),f=e;if(b!=="*"){f=e.filter(b);var g=a.not(d).not(b).addClass(c);this.styleQueue.push({$el:g,style:this.options.hiddenStyle})}return this.styleQueue.push({$el:f,style:this.options.visibleStyle}),f.removeClass(c),a.filter(b)},updateSortData:function(a,c){var d=this,e=this.options.getSortData,f,g;a.each(function(){f=b(this),g={};for(var a in e)!c&&a==="original-order"?g[a]=b.data(this,"isotope-sort-data")[a]:g[a]=e[a](f,d);b.data(this,"isotope-sort-data",g)})},_sort:function(){var a=this.options.sortBy,b=this._getSorter,c=this.options.sortAscending?1:-1,d=function(d,e){var f=b(d,a),g=b(e,a);return f===g&&a!=="original-order"&&(f=b(d,"original-order"),g=b(e,"original-order")),(f>g?1:f<g?-1:0)*c};this.$filteredAtoms.sort(d)},_getSorter:function(a,c){return b.data(a,"isotope-sort-data")[c]},_translate:function(a,b){return{translate:[a,b]}},_positionAbs:function(a,b){return{left:a,top:b}},_pushPosition:function(a,b,c){b=Math.round(b+this.offset.left),c=Math.round(c+this.offset.top);var d=this.getPositionStyles(b,c);this.styleQueue.push({$el:a,style:d}),this.options.itemPositionDataEnabled&&a.data("isotope-item-position",{x:b,y:c})},layout:function(a,b){var c=this.options.layoutMode;this["_"+c+"Layout"](a);if(this.options.resizesContainer){var d=this["_"+c+"GetContainerSize"]();this.styleQueue.push({$el:this.element,style:d})}this._processStyleQueue(a,b),this.isLaidOut=!0},_processStyleQueue:function(a,c){var d=this.isLaidOut?this.isUsingJQueryAnimation?"animate":"css":"css",f=this.options.animationOptions,g=this.options.onLayout,h,i,j,k;i=function(a,b){b.$el[d](b.style,f)};if(this._isInserting&&this.isUsingJQueryAnimation)i=function(a,b){h=b.$el.hasClass("no-transition")?"css":d,b.$el[h](b.style,f)};else if(c||g||f.complete){var l=!1,m=[c,g,f.complete],n=this;j=!0,k=function(){if(l)return;var b;for(var c=0,d=m.length;c<d;c++)b=m[c],typeof b=="function"&&b.call(n.element,a,n);l=!0};if(this.isUsingJQueryAnimation&&d==="animate")f.complete=k,j=!1;else if(e.csstransitions){var o=0,p=this.styleQueue[0],s=p&&p.$el,t;while(!s||!s.length){t=this.styleQueue[o++];if(!t)return;s=t.$el}var u=parseFloat(getComputedStyle(s[0])[r]);u>0&&(i=function(a,b){b.$el[d](b.style,f).one(q,k)},j=!1)}}b.each(this.styleQueue,i),j&&k(),this.styleQueue=[]},resize:function(){this["_"+this.options.layoutMode+"ResizeChanged"]()&&this.reLayout()},reLayout:function(a){this["_"+this.options.layoutMode+"Reset"](),this.layout(this.$filteredAtoms,a)},addItems:function(a,b){var c=this._getAtoms(a);this.$allAtoms=this.$allAtoms.add(c),b&&b(c)},insert:function(a,b){this.element.append(a);var c=this;this.addItems(a,function(a){var d=c._filter(a);c._addHideAppended(d),c._sort(),c.reLayout(),c._revealAppended(d,b)})},appended:function(a,b){var c=this;this.addItems(a,function(a){c._addHideAppended(a),c.layout(a),c._revealAppended(a,b)})},_addHideAppended:function(a){this.$filteredAtoms=this.$filteredAtoms.add(a),a.addClass("no-transition"),this._isInserting=!0,this.styleQueue.push({$el:a,style:this.options.hiddenStyle})},_revealAppended:function(a,b){var c=this;setTimeout(function(){a.removeClass("no-transition"),c.styleQueue.push({$el:a,style:c.options.visibleStyle}),c._isInserting=!1,c._processStyleQueue(a,b)},10)},reloadItems:function(){this.$allAtoms=this._getAtoms(this.element.children())},remove:function(a,b){var c=this,d=function(){c.$allAtoms=c.$allAtoms.not(a),a.remove(),b&&b.call(c.element)};a.filter(":not(."+this.options.hiddenClass+")").length?(this.styleQueue.push({$el:a,style:this.options.hiddenStyle}),this.$filteredAtoms=this.$filteredAtoms.not(a),this._sort(),this.reLayout(d)):d()},shuffle:function(a){this.updateSortData(this.$allAtoms),this.options.sortBy="random",this._sort(),this.reLayout(a)},destroy:function(){var a=this.usingTransforms,b=this.options;this.$allAtoms.removeClass(b.hiddenClass+" "+b.itemClass).each(function(){var b=this.style;b.position="",b.top="",b.left="",b.opacity="",a&&(b[i]="")});var c=this.element[0].style;for(var d in this.originalStyle)c[d]=this.originalStyle[d];this.element.unbind(".isotope").undelegate("."+b.hiddenClass,"click").removeClass(b.containerClass).removeData("isotope"),v.unbind(".isotope")},_getSegments:function(a){var b=this.options.layoutMode,c=a?"rowHeight":"columnWidth",d=a?"height":"width",e=a?"rows":"cols",g=this.element[d](),h,i=this.options[b]&&this.options[b][c]||this.$filteredAtoms["outer"+f(d)](!0)||g;h=Math.floor(g/i),h=Math.max(h,1),this[b][e]=h,this[b][c]=i},_checkIfSegmentsChanged:function(a){var b=this.options.layoutMode,c=a?"rows":"cols",d=this[b][c];return this._getSegments(a),this[b][c]!==d},_masonryReset:function(){this.masonry={},this._getSegments();var a=this.masonry.cols;this.masonry.colYs=[];while(a--)this.masonry.colYs.push(0)},_masonryLayout:function(a){var c=this,d=c.masonry;a.each(function(){var a=b(this),e=Math.ceil(a.outerWidth(!0)/d.columnWidth);e=Math.min(e,d.cols);if(e===1)c._masonryPlaceBrick(a,d.colYs);else{var f=d.cols+1-e,g=[],h,i;for(i=0;i<f;i++)h=d.colYs.slice(i,i+e),g[i]=Math.max.apply(Math,h);c._masonryPlaceBrick(a,g)}})},_masonryPlaceBrick:function(a,b){var c=Math.min.apply(Math,b),d=0;for(var e=0,f=b.length;e<f;e++)if(b[e]===c){d=e;break}var g=this.masonry.columnWidth*d,h=c;this._pushPosition(a,g,h);var i=c+a.outerHeight(!0),j=this.masonry.cols+1-f;for(e=0;e<j;e++)this.masonry.colYs[d+e]=i},_masonryGetContainerSize:function(){var a=Math.max.apply(Math,this.masonry.colYs);return{height:a}},_masonryResizeChanged:function(){return this._checkIfSegmentsChanged()},_fitRowsReset:function(){this.fitRows={x:0,y:0,height:0}},_fitRowsLayout:function(a){var c=this,d=this.element.width(),e=this.fitRows;a.each(function(){var a=b(this),f=a.outerWidth(!0),g=a.outerHeight(!0);e.x!==0&&f+e.x>d&&(e.x=0,e.y=e.height),c._pushPosition(a,e.x,e.y),e.height=Math.max(e.y+g,e.height),e.x+=f})},_fitRowsGetContainerSize:function(){return{height:this.fitRows.height}},_fitRowsResizeChanged:function(){return!0},_cellsByRowReset:function(){this.cellsByRow={index:0},this._getSegments(),this._getSegments(!0)},_cellsByRowLayout:function(a){var c=this,d=this.cellsByRow;a.each(function(){var a=b(this),e=d.index%d.cols,f=Math.floor(d.index/d.cols),g=(e+.5)*d.columnWidth-a.outerWidth(!0)/2,h=(f+.5)*d.rowHeight-a.outerHeight(!0)/2;c._pushPosition(a,g,h),d.index++})},_cellsByRowGetContainerSize:function(){return{height:Math.ceil(this.$filteredAtoms.length/this.cellsByRow.cols)*this.cellsByRow.rowHeight+this.offset.top}},_cellsByRowResizeChanged:function(){return this._checkIfSegmentsChanged()},_straightDownReset:function(){this.straightDown={y:0}},_straightDownLayout:function(a){var c=this;a.each(function(a){var d=b(this);c._pushPosition(d,0,c.straightDown.y),c.straightDown.y+=d.outerHeight(!0)})},_straightDownGetContainerSize:function(){return{height:this.straightDown.y}},_straightDownResizeChanged:function(){return!0},_masonryHorizontalReset:function(){this.masonryHorizontal={},this._getSegments(!0);var a=this.masonryHorizontal.rows;this.masonryHorizontal.rowXs=[];while(a--)this.masonryHorizontal.rowXs.push(0)},_masonryHorizontalLayout:function(a){var c=this,d=c.masonryHorizontal;a.each(function(){var a=b(this),e=Math.ceil(a.outerHeight(!0)/d.rowHeight);e=Math.min(e,d.rows);if(e===1)c._masonryHorizontalPlaceBrick(a,d.rowXs);else{var f=d.rows+1-e,g=[],h,i;for(i=0;i<f;i++)h=d.rowXs.slice(i,i+e),g[i]=Math.max.apply(Math,h);c._masonryHorizontalPlaceBrick(a,g)}})},_masonryHorizontalPlaceBrick:function(a,b){var c=Math.min.apply(Math,b),d=0;for(var e=0,f=b.length;e<f;e++)if(b[e]===c){d=e;break}var g=c,h=this.masonryHorizontal.rowHeight*d;this._pushPosition(a,g,h);var i=c+a.outerWidth(!0),j=this.masonryHorizontal.rows+1-f;for(e=0;e<j;e++)this.masonryHorizontal.rowXs[d+e]=i},_masonryHorizontalGetContainerSize:function(){var a=Math.max.apply(Math,this.masonryHorizontal.rowXs);return{width:a}},_masonryHorizontalResizeChanged:function(){return this._checkIfSegmentsChanged(!0)},_fitColumnsReset:function(){this.fitColumns={x:0,y:0,width:0}},_fitColumnsLayout:function(a){var c=this,d=this.element.height(),e=this.fitColumns;a.each(function(){var a=b(this),f=a.outerWidth(!0),g=a.outerHeight(!0);e.y!==0&&g+e.y>d&&(e.x=e.width,e.y=0),c._pushPosition(a,e.x,e.y),e.width=Math.max(e.x+f,e.width),e.y+=g})},_fitColumnsGetContainerSize:function(){return{width:this.fitColumns.width}},_fitColumnsResizeChanged:function(){return!0},_cellsByColumnReset:function(){this.cellsByColumn={index:0},this._getSegments(),this._getSegments(!0)},_cellsByColumnLayout:function(a){var c=this,d=this.cellsByColumn;a.each(function(){var a=b(this),e=Math.floor(d.index/d.rows),f=d.index%d.rows,g=(e+.5)*d.columnWidth-a.outerWidth(!0)/2,h=(f+.5)*d.rowHeight-a.outerHeight(!0)/2;c._pushPosition(a,g,h),d.index++})},_cellsByColumnGetContainerSize:function(){return{width:Math.ceil(this.$filteredAtoms.length/this.cellsByColumn.rows)*this.cellsByColumn.columnWidth}},_cellsByColumnResizeChanged:function(){return this._checkIfSegmentsChanged(!0)},_straightAcrossReset:function(){this.straightAcross={x:0}},_straightAcrossLayout:function(a){var c=this;a.each(function(a){var d=b(this);c._pushPosition(d,c.straightAcross.x,0),c.straightAcross.x+=d.outerWidth(!0)})},_straightAcrossGetContainerSize:function(){return{width:this.straightAcross.x}},_straightAcrossResizeChanged:function(){return!0}},b.fn.imagesLoaded=function(a){function h(){a.call(c,d)}function i(a){var c=a.target;c.src!==f&&b.inArray(c,g)===-1&&(g.push(c),--e<=0&&(setTimeout(h),d.unbind(".imagesLoaded",i)))}var c=this,d=c.find("img").add(c.filter("img")),e=d.length,f="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==",g=[];return e||h(),d.bind("load.imagesLoaded error.imagesLoaded",i).each(function(){var a=this.src;this.src=f,this.src=a}),c};var w=function(b){a.console&&a.console.error(b)};b.fn.isotope=function(a,c){if(typeof a=="string"){var d=Array.prototype.slice.call(arguments,1);this.each(function(){var c=b.data(this,"isotope");if(!c){w("cannot call methods on isotope prior to initialization; attempted to call method '"+a+"'");return}if(!b.isFunction(c[a])||a.charAt(0)==="_"){w("no such method '"+a+"' for isotope instance");return}c[a].apply(c,d)})}else this.each(function(){var d=b.data(this,"isotope");d?(d.option(a),d._init(c)):b.data(this,"isotope",new b.Isotope(a,this,c))});return this}})(window,jQuery);
/*!
 * fancyBox - jQuery Plugin
 * version: 2.0.6 (16/04/2012)
 * @requires jQuery v1.6 or later
 *
 * Examples at http://fancyapps.com/fancybox/
 * License: www.fancyapps.com/fancybox/#license
 *
 * Copyright 2012 Janis Skarnelis - janis@fancyapps.com
 *
 */

(function (window, document, $, undefined) {
    "use strict";

    var W = $(window),
		D = $(document),
		F = $.fancybox = function () {
		    F.open.apply(this, arguments);
		},
		didResize = false,
		resizeTimer = null,
		isTouch = document.createTouch !== undefined,
		isString = function (str) {
		    return $.type(str) === "string";
		},
		isPercentage = function (str) {
		    return isString(str) && str.indexOf('%') > 0;
		},
		getValue = function (value, dim) {
		    if (dim && isPercentage(value)) {
		        value = F.getViewport()[dim] / 100 * parseInt(value, 10);
		    }

		    return Math.round(value) + 'px';
		};

    $.extend(F, {
        // The current version of fancyBox
        version: '2.0.5',

        defaults: {
            padding: 15,
            margin: 20,

            width: 800,
            height: 600,
            minWidth: 100,
            minHeight: 100,
            maxWidth: 9999,
            maxHeight: 9999,

            autoSize: true,
            autoResize: !isTouch,
            autoCenter: !isTouch,
            fitToView: true,
            aspectRatio: false,
            topRatio: 0.5,

            fixed: false,
            scrolling: 'auto', // 'auto', 'yes' or 'no'
            wrapCSS: '',

            arrows: true,
            closeBtn: true,
            closeClick: false,
            nextClick: false,
            mouseWheel: true,
            autoPlay: false,
            playSpeed: 3000,
            preload: 3,

            modal: false,
            loop: true,
            ajax: { dataType: 'html', headers: { 'X-fancyBox': true } },
            keys: {
                next: [13, 32, 34, 39, 40], // enter, space, page down, right arrow, down arrow
                prev: [8, 33, 37, 38], // backspace, page up, left arrow, up arrow
                close: [27] // escape key
            },

            // Override some properties
            index: 0,
            type: null,
            href: null,
            content: null,
            title: null,

            //<div class="fancybox-item fancybox-close" title="Close"></div>

            // HTML templates
            tpl: {
                wrap: '<div class="fancybox-wrap"><div class="fancybox-skin"><div class="fancybox-outer"><div class="fancybox-inner"></div></div></div></div>',
                image: '<img class="fancybox-image" src="{href}" alt="" />',
                iframe: '<iframe class="fancybox-iframe" name="fancybox-frame{rnd}" frameborder="0" hspace="0"' + ($.browser.msie ? ' allowtransparency="true"' : '') + '></iframe>',
                swf: '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%"><param name="wmode" value="transparent" /><param name="allowfullscreen" value="true" /><param name="allowscriptaccess" value="always" /><param name="movie" value="{href}" /><embed src="{href}" type="application/x-shockwave-flash" allowfullscreen="true" allowscriptaccess="always" width="100%" height="100%" wmode="transparent"></embed></object>',
                error: '<p class="fancybox-error">The requested content cannot be loaded.<br/>Please try again later.</p>',
                closeBtn: '<div class="fancybox-content"><ul><li>edit</li><li>location</li><li>tag</li></ul></div>',
                next: '<a title="Next" class="fancybox-nav fancybox-next"><span></span></a>',
                prev: '<a title="Previous" class="fancybox-nav fancybox-prev"><span></span></a>'
            },

            // Properties for each animation type
            // Opening fancyBox
            openEffect: 'fade', // 'elastic', 'fade' or 'none'
            openSpeed: 300,
            openEasing: 'swing',
            openOpacity: true,
            openMethod: 'zoomIn',

            // Closing fancyBox
            closeEffect: 'fade', // 'elastic', 'fade' or 'none'
            closeSpeed: 300,
            closeEasing: 'swing',
            closeOpacity: true,
            closeMethod: 'zoomOut',

            // Changing next gallery item
            nextEffect: 'elastic', // 'elastic', 'fade' or 'none'
            nextSpeed: 300,
            nextEasing: 'swing',
            nextMethod: 'changeIn',

            // Changing previous gallery item
            prevEffect: 'elastic', // 'elastic', 'fade' or 'none'
            prevSpeed: 300,
            prevEasing: 'swing',
            prevMethod: 'changeOut',

            // Enabled helpers
            helpers: {
                overlay: {
                    speedIn: 0,
                    speedOut: 300,
                    opacity: 0.8,
                    css: {
                        cursor: 'pointer'
                    },
                    closeClick: true
                },
                title: {
                    type: 'float' // 'float', 'inside', 'outside' or 'over'
                }
            },

            // Callbacks
            onCancel: $.noop, // If canceling
            beforeLoad: $.noop, // Before loading
            afterLoad: $.noop, // After loading
            beforeShow: $.noop, // Before changing in current item
            afterShow: $.noop, // After opening
            beforeClose: $.noop, // Before closing
            afterClose: $.noop // After closing
        },

        //Current state
        group: {}, // Selected group
        opts: {}, // Group options
        coming: null, // Element being loaded
        current: null, // Currently loaded element
        isOpen: false, // Is currently open
        isOpened: false, // Have been fully opened at least once
        wrap: null,
        skin: null,
        outer: null,
        inner: null,

        player: {
            timer: null,
            isActive: false
        },

        // Loaders
        ajaxLoad: null,
        imgPreload: null,

        // Some collections
        transitions: {},
        helpers: {},

        /*
		 *	Static methods
		 */

        open: function (group, opts) {
            //Kill existing instances
            F.close(true);

            //Normalize group
            if (group && !$.isArray(group)) {
                group = group instanceof $ ? $(group).get() : [group];
            }

            F.isActive = true;

            //Extend the defaults
            F.opts = $.extend(true, {}, F.defaults, opts);

            //All options are merged recursive except keys
            if ($.isPlainObject(opts) && opts.keys !== undefined) {
                F.opts.keys = opts.keys ? $.extend({}, F.defaults.keys, opts.keys) : false;
            }

            F.group = group;

            F._start(F.opts.index || 0);
        },

        cancel: function () {
            if (F.coming && false === F.trigger('onCancel')) {
                return;
            }

            F.coming = null;

            F.hideLoading();

            if (F.ajaxLoad) {
                F.ajaxLoad.abort();
            }

            F.ajaxLoad = null;

            if (F.imgPreload) {
                F.imgPreload.onload = F.imgPreload.onabort = F.imgPreload.onerror = null;
            }
        },

        close: function (a) {
            F.cancel();

            if (!F.current || false === F.trigger('beforeClose')) {
                return;
            }

            F.unbindEvents();

            //If forced or is still opening then remove immediately
            if (!F.isOpen || (a && a[0] === true)) {
                $('.fancybox-wrap').stop().trigger('onReset').remove();

                F._afterZoomOut();

            } else {
                F.isOpen = F.isOpened = false;

                $('.fancybox-item, .fancybox-nav').remove();

                F.wrap.stop(true).removeClass('fancybox-opened');
                F.inner.css('overflow', 'hidden');

                F.transitions[F.current.closeMethod]();
            }
        },

        // Start/stop slideshow
        play: function (a) {
            var clear = function () {
                clearTimeout(F.player.timer);
            },
				set = function () {
				    clear();

				    if (F.current && F.player.isActive) {
				        F.player.timer = setTimeout(F.next, F.current.playSpeed);
				    }
				},
				stop = function () {
				    clear();

				    $('body').unbind('.player');

				    F.player.isActive = false;

				    F.trigger('onPlayEnd');
				},
				start = function () {
				    if (F.current && (F.current.loop || F.current.index < F.group.length - 1)) {
				        F.player.isActive = true;

				        $('body').bind({
				            'afterShow.player onUpdate.player': set,
				            'onCancel.player beforeClose.player': stop,
				            'beforeLoad.player': clear
				        });

				        set();

				        F.trigger('onPlayStart');
				    }
				};

            if (F.player.isActive || (a && a[0] === false)) {
                stop();
            } else {
                start();
            }
        },

        next: function () {
            if (F.current) {
                F.jumpto(F.current.index + 1);
            }
        },

        prev: function () {
            if (F.current) {
                F.jumpto(F.current.index - 1);
            }
        },

        jumpto: function (index) {
            if (!F.current) {
                return;
            }

            index = parseInt(index, 10);

            if (F.group.length > 1 && F.current.loop) {
                if (index >= F.group.length) {
                    index = 0;

                } else if (index < 0) {
                    index = F.group.length - 1;
                }
            }

            if (F.group[index] !== undefined) {
                F.cancel();

                F._start(index);
            }
        },

        reposition: function (e, onlyAbsolute) {
            var pos;

            if (F.isOpen) {
                pos = F._getPosition(onlyAbsolute);

                if (e && e.type === 'scroll') {
                    delete pos.position;

                    F.wrap.stop(true, true).animate(pos, 200);

                } else {
                    F.wrap.css(pos);
                }
            }
        },

        update: function (e) {
            if (!F.isOpen) {
                return;
            }

            // Run this code after a delay for better performance
            if (!didResize) {
                resizeTimer = setTimeout(function () {
                    var current = F.current, anyway = !e || (e && e.type === 'orientationchange');

                    if (didResize) {
                        didResize = false;

                        if (!current) {
                            return;
                        }

                        if ((!e || e.type !== 'scroll') || anyway) {
                            if (current.autoSize && current.type !== 'iframe') {
                                F.inner.height('auto');
                                current.height = F.inner.height();
                            }

                            if (current.autoResize || anyway) {
                                F._setDimension();
                            }

                            if (current.canGrow && current.type !== 'iframe') {
                                F.inner.height('auto');
                            }
                        }

                        if (current.autoCenter || anyway) {
                            F.reposition(e);
                        }

                        F.trigger('onUpdate');
                    }
                }, 200);
            }

            didResize = true;
        },

        toggle: function () {
            if (F.isOpen) {
                F.current.fitToView = !F.current.fitToView;

                F.update();
            }
        },

        hideLoading: function () {
            D.unbind('keypress.fb');

            $('#fancybox-loading').remove();
        },

        showLoading: function () {
            F.hideLoading();

            //If user will press the escape-button, the request will be canceled
            D.bind('keypress.fb', function (e) {
                if (e.keyCode === 27) {
                    e.preventDefault();
                    F.cancel();
                }
            });

            $('<div id="fancybox-loading"><div></div></div>').click(F.cancel).appendTo('body');
        },

        getViewport: function () {
            // See http://bugs.jquery.com/ticket/6724
            return {
                x: W.scrollLeft(),
                y: W.scrollTop(),
                w: isTouch && window.innerWidth ? window.innerWidth : W.width(),
                h: isTouch && window.innerHeight ? window.innerHeight : W.height()
            };
        },

        // Unbind the keyboard / clicking actions
        unbindEvents: function () {
            if (F.wrap) {
                F.wrap.unbind('.fb');
            }

            D.unbind('.fb');
            W.unbind('.fb');
        },

        bindEvents: function () {
            var current = F.current,
				keys = current.keys;

            if (!current) {
                return;
            }

            W.bind('resize.fb orientationchange.fb' + (current.autoCenter && !current.fixed ? ' scroll.fb' : ''), F.update);

            if (keys) {
                D.bind('keydown.fb', function (e) {
                    var code, target = e.target || e.srcElement;

                    // Ignore key combinations and key events within form elements
                    if (!e.ctrlKey && !e.altKey && !e.shiftKey && !e.metaKey && !(target && (target.type || $(target).is('[contenteditable]')))) {
                        code = e.keyCode;

                        if ($.inArray(code, keys.close) > -1) {
                            F.close();
                            e.preventDefault();

                        } else if ($.inArray(code, keys.next) > -1) {
                            F.next();
                            e.preventDefault();

                        } else if ($.inArray(code, keys.prev) > -1) {
                            F.prev();
                            e.preventDefault();
                        }
                    }
                });
            }

            if ($.fn.mousewheel && current.mouseWheel && F.group.length > 1) {
                F.wrap.bind('mousewheel.fb', function (e, delta) {
                    var target = e.target || null;

                    if (delta !== 0 && (!target || target.clientHeight === 0 || (target.scrollHeight === target.clientHeight && target.scrollWidth === target.clientWidth))) {
                        e.preventDefault();

                        F[delta > 0 ? 'prev' : 'next']();
                    }
                });
            }
        },

        trigger: function (event, o) {
            var ret, obj = o || F[$.inArray(event, ['onCancel', 'beforeLoad', 'afterLoad']) > -1 ? 'coming' : 'current'];

            if (!obj) {
                return;
            }

            if ($.isFunction(obj[event])) {
                ret = obj[event].apply(obj, Array.prototype.slice.call(arguments, 1));
            }

            if (ret === false) {
                return false;
            }

            if (obj.helpers) {
                $.each(obj.helpers, function (helper, opts) {
                    if (opts && $.isPlainObject(F.helpers[helper]) && $.isFunction(F.helpers[helper][event])) {
                        F.helpers[helper][event](opts, obj);
                    }
                });
            }

            $.event.trigger(event + '.fb');
        },

        isImage: function (str) {
            return isString(str) && str.match(/\.(jpe?g|gif|png|bmp)((\?|#).*)?$/i);
        },

        isSWF: function (str) {
            return isString(str) && str.match(/\.(swf)((\?|#).*)?$/i);
        },

        _start: function (index) {
            var coming = {},
				element = F.group[index] || null,
				isDom,
				href,
				type,
				rez,
				hrefParts;

            if (element && (element.nodeType || element instanceof $)) {
                isDom = true;

                if ($.metadata) {
                    coming = $(element).metadata();
                }
            }

            coming = $.extend(true, {}, F.opts, { index: index, element: element }, ($.isPlainObject(element) ? element : coming));

            // Re-check overridable options
            $.each(['href', 'title', 'content', 'type'], function (i, v) {
                coming[v] = F.opts[v] || (isDom && $(element).attr(v)) || coming[v] || null;
            });

            // Convert margin property to array - top, right, bottom, left
            if (typeof coming.margin === 'number') {
                coming.margin = [coming.margin, coming.margin, coming.margin, coming.margin];
            }

            // 'modal' propery is just a shortcut
            if (coming.modal) {
                $.extend(true, coming, {
                    closeBtn: false,
                    closeClick: false,
                    nextClick: false,
                    arrows: false,
                    mouseWheel: false,
                    keys: null,
                    helpers: {
                        overlay: {
                            css: {
                                cursor: 'auto'
                            },
                            closeClick: false
                        }
                    }
                });
            }

            //Give a chance for callback or helpers to update coming item (type, title, etc)
            F.coming = coming;

            if (false === F.trigger('beforeLoad')) {
                F.coming = null;
                return;
            }

            type = coming.type;
            href = coming.href || element;

            ///Check if content type is set, if not, try to get
            if (!type) {
                if (isDom) {
                    type = $(element).data('fancybox-type');

                    if (!type) {
                        rez = element.className.match(/fancybox\.(\w+)/);
                        type = rez ? rez[1] : null;
                    }
                }

                if (!type && isString(href)) {
                    if (F.isImage(href)) {
                        type = 'image';

                    } else if (F.isSWF(href)) {
                        type = 'swf';

                    } else if (href.match(/^#/)) {
                        type = 'inline';
                    }
                }

                // ...if not - display element itself
                if (!type) {
                    type = isDom ? 'inline' : 'html';
                }

                coming.type = type;
            }

            // Check before try to load; 'inline' and 'html' types need content, others - href
            if (type === 'inline' || type === 'html') {
                if (!coming.content) {
                    if (type === 'inline') {
                        coming.content = $(isString(href) ? href.replace(/.*(?=#[^\s]+$)/, '') : href); //strip for ie7

                    } else {
                        coming.content = element;
                    }
                }

                if (!coming.content || !coming.content.length) {
                    type = null;
                }

            } else if (!href) {
                type = null;
            }

            /*
			 * Add reference to the group, so it`s possible to access from callbacks, example:
			 * afterLoad : function() {
			 *     this.title = 'Image ' + (this.index + 1) + ' of ' + this.group.length + (this.title ? ' - ' + this.title : '');
			 * }
			 */

            if (type === 'ajax' && isString(href)) {
                hrefParts = href.split(/\s+/, 2);

                href = hrefParts.shift();
                coming.selector = hrefParts.shift();
            }

            coming.href = href;
            coming.group = F.group;
            coming.isDom = isDom;

            switch (type) {
                case 'image':
                    F._loadImage();
                    break;

                case 'ajax':
                    F._loadAjax();
                    break;

                case 'inline':
                case 'iframe':
                case 'swf':
                case 'html':
                    F._afterLoad();
                    break;

                default:
                    F._error('type');
            }
        },

        _error: function (type) {
            F.hideLoading();

            $.extend(F.coming, {
                type: 'html',
                autoSize: true,
                minWidth: 0,
                minHeight: 0,
                padding: 15,
                hasError: type,
                content: F.coming.tpl.error
            });

            F._afterLoad();
        },

        _loadImage: function () {
            // Reset preload image so it is later possible to check "complete" property
            var img = F.imgPreload = new Image();

            img.onload = function () {
                this.onload = this.onerror = null;

                F.coming.width = this.width;
                F.coming.height = this.height;

                F._afterLoad();
            };

            img.onerror = function () {
                this.onload = this.onerror = null;

                F._error('image');
            };

            img.src = F.coming.href;

            if (img.complete === undefined || !img.complete) {
                F.showLoading();
            }
        },

        _loadAjax: function () {
            F.showLoading();

            F.ajaxLoad = $.ajax($.extend({}, F.coming.ajax, {
                url: F.coming.href,
                error: function (jqXHR, textStatus) {
                    if (F.coming && textStatus !== 'abort') {
                        F._error('ajax', jqXHR);

                    } else {
                        F.hideLoading();
                    }
                },
                success: function (data, textStatus) {
                    if (textStatus === 'success') {
                        F.coming.content = data;

                        F._afterLoad();
                    }
                }
            }));
        },

        _preloadImages: function () {
            var group = F.group,
				current = F.current,
				len = group.length,
				item,
				href,
				i,
				cnt = Math.min(current.preload, len - 1);

            if (!current.preload || group.length < 2) {
                return;
            }

            for (i = 1; i <= cnt; i += 1) {
                item = group[(current.index + i) % len];
                href = item.href || $(item).attr('href') || item;

                if (item.type === 'image' || F.isImage(href)) {
                    new Image().src = href;
                }
            }
        },

        _afterLoad: function () {
            F.hideLoading();

            if (!F.coming || false === F.trigger('afterLoad', F.current)) {
                F.coming = false;

                return;
            }

            if (F.isOpened) {
                $('.fancybox-item, .fancybox-nav').remove();

                F.wrap.stop(true).removeClass('fancybox-opened');
                F.inner.css('overflow', 'hidden');

                F.transitions[F.current.prevMethod]();

            } else {
                $('.fancybox-wrap').stop().trigger('onReset').remove();

                F.trigger('afterClose');
            }

            F.unbindEvents();

            F.isOpen = false;
            F.current = F.coming;

            //Build the neccessary markup
            F.wrap = $(F.current.tpl.wrap).addClass('fancybox-' + (isTouch ? 'mobile' : 'desktop') + ' fancybox-type-' + F.current.type + ' fancybox-tmp ' + F.current.wrapCSS).appendTo('body');
            F.skin = $('.fancybox-skin', F.wrap).css('padding', getValue(F.current.padding));
            F.outer = $('.fancybox-outer', F.wrap);
            F.inner = $('.fancybox-inner', F.wrap);

            F._setContent();
        },

        _setContent: function () {
            var current = F.current,
				content = current.content,
				type = current.type,
				minWidth = current.minWidth,
				minHeight = current.minHeight,
				maxWidth = current.maxWidth,
				maxHeight = current.maxHeight,
				loadingBay;

            switch (type) {
                case 'inline':
                case 'ajax':
                case 'html':
                    if (current.selector) {
                        content = $('<div>').html(content).find(current.selector);

                    } else if (content instanceof $) {
                        if (content.parent().hasClass('fancybox-inner')) {
                            content.parents('.fancybox-wrap').unbind('onReset');
                        }

                        content = content.show().detach();

                        $(F.wrap).bind('onReset', function () {
                            content.appendTo('body').hide();
                        });
                    }

                    if (current.autoSize) {
                        loadingBay = $('<div class="fancybox-wrap ' + F.current.wrapCSS + ' fancybox-tmp"></div>')
							.appendTo('body')
							.css({
							    minWidth: getValue(minWidth, 'w'),
							    minHeight: getValue(minHeight, 'h'),
							    maxWidth: getValue(maxWidth, 'w'),
							    maxHeight: getValue(maxHeight, 'h')
							})
							.append(content);

                        current.width = loadingBay.width();
                        current.height = loadingBay.height();

                        // Re-check to fix 1px bug in some browsers
                        loadingBay.width(F.current.width);

                        if (loadingBay.height() > current.height) {
                            loadingBay.width(current.width + 1);

                            current.width = loadingBay.width();
                            current.height = loadingBay.height();
                        }

                        content = loadingBay.contents().detach();

                        loadingBay.remove();
                    }

                    break;

                case 'image':
                    content = current.tpl.image.replace('{href}', current.href);

                    current.aspectRatio = true;
                    break;

                case 'swf':
                    content = current.tpl.swf.replace(/\{width\}/g, current.width).replace(/\{height\}/g, current.height).replace(/\{href\}/g, current.href);
                    break;

                case 'iframe':
                    content = $(current.tpl.iframe.replace('{rnd}', new Date().getTime()))
						.attr('scrolling', current.scrolling)
						.attr('src', current.href);

                    current.scrolling = isTouch ? 'scroll' : 'auto';

                    break;
            }

            if (type === 'image' || type === 'swf') {
                current.autoSize = false;
                current.scrolling = 'visible';
            }

            if (type === 'iframe' && current.autoSize) {
                F.showLoading();

                F._setDimension();

                F.inner.css('overflow', current.scrolling);

                content.bind({
                    onCancel: function () {
                        $(this).unbind();

                        F._afterZoomOut();
                    },
                    load: function () {
                        F.hideLoading();

                        try {
                            if (this.contentWindow.document.location) {
                                F.current.height = $(this).contents().find('body').height();
                            }
                        } catch (e) {
                            F.current.autoSize = false;
                        }

                        F[F.isOpen ? '_afterZoomIn' : '_beforeShow']();
                    }
                }).appendTo(F.inner);

            } else {
                F.inner.append(content);

                F._beforeShow();
            }
        },

        _beforeShow: function () {
            F.coming = null;

            //Give a chance for helpers or callbacks to update elements
            F.trigger('beforeShow');

            //Set initial dimensions and hide
            F._setDimension();
            F.wrap.hide().removeClass('fancybox-tmp');

            F.bindEvents();

            F._preloadImages();

            F.transitions[F.isOpened ? F.current.nextMethod : F.current.openMethod]();
        },

        _setDimension: function () {
            var wrap = F.wrap,
				inner = F.inner,
				current = F.current,
				viewport = F.getViewport(),
				margin = current.margin,
				padding2 = current.padding * 2,
				width = current.width,
				height = current.height,
				maxWidth = current.maxWidth + padding2,
				maxHeight = current.maxHeight + padding2,
				minWidth = current.minWidth + padding2,
				minHeight = current.minHeight + padding2,
				ratio,
				height_;

            viewport.w -= (margin[1] + margin[3]);
            viewport.h -= (margin[0] + margin[2]);

            if (isPercentage(width)) {
                width = (((viewport.w - padding2) * parseFloat(width)) / 100);
            }

            if (isPercentage(height)) {
                height = (((viewport.h - padding2) * parseFloat(height)) / 100);
            }

            ratio = width / height;
            width += padding2;
            height += padding2;

            if (current.fitToView) {
                maxWidth = Math.min(viewport.w, maxWidth);
                maxHeight = Math.min(viewport.h, maxHeight);
            }

            if (current.aspectRatio) {
                if (width > maxWidth) {
                    width = maxWidth;
                    height = ((width - padding2) / ratio) + padding2;
                }

                if (height > maxHeight) {
                    height = maxHeight;
                    width = ((height - padding2) * ratio) + padding2;
                }

                if (width < minWidth) {
                    width = minWidth;
                    height = ((width - padding2) / ratio) + padding2;
                }

                if (height < minHeight) {
                    height = minHeight;
                    width = ((height - padding2) * ratio) + padding2;
                }

            } else {
                width = Math.max(minWidth, Math.min(width, maxWidth));
                height = Math.max(minHeight, Math.min(height, maxHeight));
            }

            width = Math.round(width);
            height = Math.round(height);

            //Reset dimensions
            $(wrap.add(inner)).width('auto').height('auto');

            inner.width(width - padding2).height(height - padding2);
            wrap.width(width);

            height_ = wrap.height(); // Real wrap height

            //Fit wrapper inside
            if (width > maxWidth || height_ > maxHeight) {
                while ((width > maxWidth || height_ > maxHeight) && width > minWidth && height_ > minHeight) {
                    height = height - 10;

                    if (current.aspectRatio) {
                        width = Math.round(((height - padding2) * ratio) + padding2);

                        if (width < minWidth) {
                            width = minWidth;
                            height = ((width - padding2) / ratio) + padding2;
                        }

                    } else {
                        width = width - 10;
                    }

                    inner.width(width - padding2).height(height - padding2);
                    wrap.width(width);

                    height_ = wrap.height();
                }
            }

            current.dim = {
                width: getValue(width),
                height: getValue(height_)
            };

            current.canGrow = current.autoSize && height > minHeight && height < maxHeight;
            current.canShrink = false;
            current.canExpand = false;

            if ((width - padding2) < current.width || (height - padding2) < current.height) {
                current.canExpand = true;

            } else if ((width > viewport.w || height_ > viewport.h) && width > minWidth && height > minHeight) {
                current.canShrink = true;
            }

            F.innerSpace = height_ - padding2 - inner.height();
        },

        _getPosition: function (onlyAbsolute) {
            var current = F.current,
				viewport = F.getViewport(),
				margin = current.margin,
				width = F.wrap.width() + margin[1] + margin[3],
				height = F.wrap.height() + margin[0] + margin[2],
				rez = {
				    position: 'absolute',
				    top: margin[0] + viewport.y,
				    left: margin[3] + viewport.x
				};

            if (current.autoCenter && current.fixed && !onlyAbsolute && height <= viewport.h && width <= viewport.w) {
                rez = {
                    position: 'fixed',
                    top: margin[0],
                    left: margin[3]
                };
            }

            rez.top = getValue(Math.max(rez.top, rez.top + ((viewport.h - height) * current.topRatio)));
            rez.left = getValue(Math.max(rez.left, rez.left + ((viewport.w - width) * 0.5)));

            return rez;
        },

        _afterZoomIn: function () {
            var current = F.current, scrolling = current ? current.scrolling : 'no';

            if (!current) {
                return;
            }

            F.isOpen = F.isOpened = true;

            F.wrap.addClass('fancybox-opened');

            F.inner.css('overflow', scrolling === 'yes' ? 'scroll' : (scrolling === 'no' ? 'hidden' : scrolling));

            F.trigger('afterShow');

            F.update();

            //Assign a click event
            if (current.closeClick || current.nextClick) {
                F.inner.css('cursor', 'pointer').bind('click.fb', function (e) {
                    if (!$(e.target).is('a') && !$(e.target).parent().is('a')) {
                        F[current.closeClick ? 'close' : 'next']();
                    }
                });
            }

            //Create a close button
            if (current.closeBtn) {
                //$(current.tpl.closeBtn).appendTo(F.skin); //.bind('click.fb', F.close);
                $(current.tpl.closeBtn).prepend($('<img id="closefancybox" src="/content/images/close.png" title="click to close" />').bind('click.fb', F.close)).appendTo(F.skin);
            }

            //Create navigation arrows
            if (current.arrows && F.group.length > 1) {
                if (current.loop || current.index > 0) {
                    $(current.tpl.prev).appendTo(F.outer).bind('click.fb', F.prev);
                }

                if (current.loop || current.index < F.group.length - 1) {
                    $(current.tpl.next).appendTo(F.outer).bind('click.fb', F.next);
                }
            }

            if (F.opts.autoPlay && !F.player.isActive) {
                F.opts.autoPlay = false;

                F.play();
            }
        },

        _afterZoomOut: function () {
            var current = F.current;

            F.wrap.trigger('onReset').remove();

            $.extend(F, {
                group: {},
                opts: {},
                current: null,
                isActive: false,
                isOpened: false,
                isOpen: false,
                wrap: null,
                skin: null,
                outer: null,
                inner: null
            });

            F.trigger('afterClose', current);
        }
    });

    /*
	 *	Default transitions
	 */

    F.transitions = {
        getOrigPosition: function () {
            var current = F.current,
				element = current.element,
				padding = current.padding,
				orig = $(current.orig),
				pos = {},
				width = 50,
				height = 50,
				viewport;

            if (!orig.length && current.isDom && $(element).is(':visible')) {
                orig = $(element).find('img:first');

                if (!orig.length) {
                    orig = $(element);
                }
            }

            if (orig.length) {
                pos = orig.offset();

                if (orig.is('img')) {
                    width = orig.outerWidth();
                    height = orig.outerHeight();
                }

            } else {
                viewport = F.getViewport();

                pos.top = viewport.y + (viewport.h - height) * 0.5;
                pos.left = viewport.x + (viewport.w - width) * 0.5;
            }

            pos = {
                top: getValue(pos.top - padding),
                left: getValue(pos.left - padding),
                width: getValue(width + padding * 2),
                height: getValue(height + padding * 2)
            };

            return pos;
        },

        step: function (now, fx) {
            var prop = fx.prop, value, ratio;

            if (prop === 'width' || prop === 'height') {
                value = Math.ceil(now - (F.current.padding * 2));

                if (prop === 'height') {
                    ratio = (now - fx.start) / (fx.end - fx.start);

                    if (fx.start > fx.end) {
                        ratio = 1 - ratio;
                    }

                    value -= F.innerSpace * ratio;
                }

                F.inner[prop](value);
            }
        },

        zoomIn: function () {
            var wrap = F.wrap,
				current = F.current,
				effect = current.openEffect,
				elastic = effect === 'elastic',
				dim = current.dim,
				startPos = $.extend({}, dim, F._getPosition(elastic)),
				endPos = $.extend({ opacity: 1 }, startPos);

            //Remove "position" property that breaks older IE
            delete endPos.position;

            if (elastic) {
                startPos = this.getOrigPosition();

                if (current.openOpacity) {
                    startPos.opacity = 0;
                }

                F.outer.add(F.inner).width('auto').height('auto');

            } else if (effect === 'fade') {
                startPos.opacity = 0;
            }

            wrap.css(startPos)
				.show()
				.animate(endPos, {
				    duration: effect === 'none' ? 0 : current.openSpeed,
				    easing: current.openEasing,
				    step: elastic ? this.step : null,
				    complete: F._afterZoomIn
				});
        },

        zoomOut: function () {
            var wrap = F.wrap,
				current = F.current,
				effect = current.openEffect,
				elastic = effect === 'elastic',
				endPos = { opacity: 0 };

            if (elastic) {
                if (wrap.css('position') === 'fixed') {
                    wrap.css(F._getPosition(true));
                }

                endPos = this.getOrigPosition();

                if (current.closeOpacity) {
                    endPos.opacity = 0;
                }
            }

            wrap.animate(endPos, {
                duration: effect === 'none' ? 0 : current.closeSpeed,
                easing: current.closeEasing,
                step: elastic ? this.step : null,
                complete: F._afterZoomOut
            });
        },

        changeIn: function () {
            var wrap = F.wrap,
				current = F.current,
				effect = current.nextEffect,
				elastic = effect === 'elastic',
				startPos = F._getPosition(elastic),
				endPos = { opacity: 1 };

            startPos.opacity = 0;

            if (elastic) {
                startPos.top = getValue(parseInt(startPos.top, 10) - 200);
                endPos.top = '+=200px';
            }

            wrap.css(startPos)
				.show()
				.animate(endPos, {
				    duration: effect === 'none' ? 0 : current.nextSpeed,
				    easing: current.nextEasing,
				    complete: F._afterZoomIn
				});
        },

        changeOut: function () {
            var wrap = F.wrap,
				current = F.current,
				effect = current.prevEffect,
				endPos = { opacity: 0 },
				cleanUp = function () {
				    $(this).trigger('onReset').remove();
				};

            wrap.removeClass('fancybox-opened');

            if (effect === 'elastic') {
                endPos.top = '+=200px';
            }

            wrap.animate(endPos, {
                duration: effect === 'none' ? 0 : current.prevSpeed,
                easing: current.prevEasing,
                complete: cleanUp
            });
        }
    };

    /*
	 *	Overlay helper
	 */

    F.helpers.overlay = {
        overlay: null,

        update: function () {
            var width, scrollWidth, offsetWidth;

            //Reset width/height so it will not mess
            this.overlay.width('100%').height('100%');

            if ($.browser.msie || isTouch) {
                scrollWidth = Math.max(document.documentElement.scrollWidth, document.body.scrollWidth);
                offsetWidth = Math.max(document.documentElement.offsetWidth, document.body.offsetWidth);

                width = scrollWidth < offsetWidth ? W.width() : scrollWidth;

            } else {
                width = D.width();
            }

            this.overlay.width(width).height(D.height());
        },

        beforeShow: function (opts) {
            if (this.overlay) {
                return;
            }

            opts = $.extend(true, {}, F.defaults.helpers.overlay, opts);

            this.overlay = $('<div id="fancybox-overlay"></div>').css(opts.css).appendTo('body');

            if (opts.closeClick) {
                this.overlay.bind('click.fb', F.close);
            }

            if (F.current.fixed && !isTouch) {
                this.overlay.addClass('overlay-fixed');

            } else {
                this.update();

                this.onUpdate = function () {
                    this.update();
                };
            }

            this.overlay.fadeTo(opts.speedIn, opts.opacity);
        },

        afterClose: function (opts) {
            if (this.overlay) {
                this.overlay.fadeOut(opts.speedOut || 0, function () {
                    $(this).remove();
                });
            }

            this.overlay = null;
        }
    };

    /*
	 *	Title helper
	 */

    F.helpers.title = {
        beforeShow: function (opts) {
            var title, text = F.current.title;

            if (text) {
                title = $('<div class="fancybox-title fancybox-title-' + opts.type + '-wrap">' + text + '</div>').appendTo('body');

                if (opts.type === 'float') {
                    //This helps for some browsers
                    title.width(title.width());

                    title.wrapInner('<span class="child"></span>');

                    //Increase bottom margin so this title will also fit into viewport
                    F.current.margin[2] += Math.abs(parseInt(title.css('margin-bottom'), 10));
                }

                title.appendTo(opts.type === 'over' ? F.inner : (opts.type === 'outside' ? F.wrap : F.skin));
            }
        }
    };

    // jQuery plugin initialization
    $.fn.fancybox = function (options) {
        var that = $(this),
			selector = this.selector || '',
			index,
			run = function (e) {
			    var what = this, idx = index, relType, relVal;

			    if (!(e.ctrlKey || e.altKey || e.shiftKey || e.metaKey) && !$(what).is('.fancybox-wrap')) {
			        e.preventDefault();

			        relType = options.groupAttr || 'data-fancybox-group';
			        relVal = $(what).attr(relType);

			        if (!relVal) {
			            relType = 'rel';
			            relVal = what[relType];
			        }

			        if (relVal && relVal !== '' && relVal !== 'nofollow') {
			            what = selector.length ? $(selector) : that;
			            what = what.filter('[' + relType + '="' + relVal + '"]');
			            idx = what.index(this);
			        }

			        options.index = idx;

			        F.open(what, options);
			    }
			};

        options = options || {};
        index = options.index || 0;

        if (selector) {
            D.undelegate(selector, 'click.fb-start').delegate(selector, 'click.fb-start', run);

        } else {
            that.unbind('click.fb-start').bind('click.fb-start', run);
        }

        return this;
    };

    // Test for fixedPosition needs a body at doc ready
    $(document).ready(function () {
        F.defaults.fixed = $.support.fixedPosition || (!($.browser.msie && $.browser.version <= 6) && !isTouch);
    });

}(window, document, jQuery));
/*
* Slides, A Slideshow Plugin for jQuery
* Intructions: http://slidesjs.com
* By: Nathan Searles, http://nathansearles.com
* Version: 1.1.9
* Updated: September 5th, 2011
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
(function(a){a.fn.slides=function(b){return b=a.extend({},a.fn.slides.option,b),this.each(function(){function w(g,h,i){if(!p&&o){p=!0,b.animationStart(n+1);switch(g){case"next":l=n,k=n+1,k=e===k?0:k,r=f*2,g=-f*2,n=k;break;case"prev":l=n,k=n-1,k=k===-1?e-1:k,r=0,g=0,n=k;break;case"pagination":k=parseInt(i,10),l=a("."+b.paginationClass+" li."+b.currentClass+" a",c).attr("href").match("[^#/]+$"),k>l?(r=f*2,g=-f*2):(r=0,g=0),n=k}h==="fade"?b.crossfade?d.children(":eq("+k+")",c).css({zIndex:10}).fadeIn(b.fadeSpeed,b.fadeEasing,function(){b.autoHeight?d.animate({height:d.children(":eq("+k+")",c).outerHeight()},b.autoHeightSpeed,function(){d.children(":eq("+l+")",c).css({display:"none",zIndex:0}),d.children(":eq("+k+")",c).css({zIndex:0}),b.animationComplete(k+1),p=!1}):(d.children(":eq("+l+")",c).css({display:"none",zIndex:0}),d.children(":eq("+k+")",c).css({zIndex:0}),b.animationComplete(k+1),p=!1)}):d.children(":eq("+l+")",c).fadeOut(b.fadeSpeed,b.fadeEasing,function(){b.autoHeight?d.animate({height:d.children(":eq("+k+")",c).outerHeight()},b.autoHeightSpeed,function(){d.children(":eq("+k+")",c).fadeIn(b.fadeSpeed,b.fadeEasing)}):d.children(":eq("+k+")",c).fadeIn(b.fadeSpeed,b.fadeEasing,function(){a.browser.msie&&a(this).get(0).style.removeAttribute("filter")}),b.animationComplete(k+1),p=!1}):(d.children(":eq("+k+")").css({left:r,display:"block"}),b.autoHeight?d.animate({left:g,height:d.children(":eq("+k+")").outerHeight()},b.slideSpeed,b.slideEasing,function(){d.css({left:-f}),d.children(":eq("+k+")").css({left:f,zIndex:5}),d.children(":eq("+l+")").css({left:f,display:"none",zIndex:0}),b.animationComplete(k+1),p=!1}):d.animate({left:g},b.slideSpeed,b.slideEasing,function(){d.css({left:-f}),d.children(":eq("+k+")").css({left:f,zIndex:5}),d.children(":eq("+l+")").css({left:f,display:"none",zIndex:0}),b.animationComplete(k+1),p=!1})),b.pagination&&(a("."+b.paginationClass+" li."+b.currentClass,c).removeClass(b.currentClass),a("."+b.paginationClass+" li:eq("+k+")",c).addClass(b.currentClass))}}function x(){clearInterval(c.data("interval"))}function y(){b.pause?(clearTimeout(c.data("pause")),clearInterval(c.data("interval")),u=setTimeout(function(){clearTimeout(c.data("pause")),v=setInterval(function(){w("next",i)},b.play),c.data("interval",v)},b.pause),c.data("pause",u)):x()}a("."+b.container,a(this)).children().wrapAll('<div class="slides_control"/>');var c=a(this),d=a(".slides_control",c),e=d.children().size(),f=d.children().outerWidth(),g=d.children().outerHeight(),h=b.start-1,i=b.effect.indexOf(",")<0?b.effect:b.effect.replace(" ","").split(",")[0],j=b.effect.indexOf(",")<0?i:b.effect.replace(" ","").split(",")[1],k=0,l=0,m=0,n=0,o,p,q,r,s,t,u,v;if(e<2)return a("."+b.container,a(this)).fadeIn(b.fadeSpeed,b.fadeEasing,function(){o=!0,b.slidesLoaded()}),a("."+b.next+", ."+b.prev).fadeOut(0),!1;if(e<2)return;h<0&&(h=0),h>e&&(h=e-1),b.start&&(n=h),b.randomize&&d.randomize(),a("."+b.container,c).css({overflow:"hidden",position:"relative"}),d.children().css({position:"absolute",top:0,left:d.children().outerWidth(),zIndex:0,display:"none"}),d.css({position:"relative",width:f*3,height:g,left:-f}),a("."+b.container,c).css({display:"block"}),b.autoHeight&&(d.children().css({height:"auto"}),d.animate({height:d.children(":eq("+h+")").outerHeight()},b.autoHeightSpeed));if(b.preload&&d.find("img:eq("+h+")").length){a("."+b.container,c).css({background:"url("+b.preloadImage+") no-repeat 50% 50%"});var z=d.find("img:eq("+h+")").attr("src")+"?"+(new Date).getTime();a("img",c).parent().attr("class")!="slides_control"?t=d.children(":eq(0)")[0].tagName.toLowerCase():t=d.find("img:eq("+h+")"),d.find("img:eq("+h+")").attr("src",z).load(function(){d.find(t+":eq("+h+")").fadeIn(b.fadeSpeed,b.fadeEasing,function(){a(this).css({zIndex:5}),a("."+b.container,c).css({background:""}),o=!0,b.slidesLoaded()})})}else d.children(":eq("+h+")").fadeIn(b.fadeSpeed,b.fadeEasing,function(){o=!0,b.slidesLoaded()});b.bigTarget&&(d.children().css({cursor:"pointer"}),d.children().click(function(){return w("next",i),!1})),b.hoverPause&&b.play&&(d.bind("mouseover",function(){x()}),d.bind("mouseleave",function(){y()})),b.generateNextPrev&&(a("."+b.container,c).after('<a href="#" class="'+b.prev+'">Prev</a>'),a("."+b.prev,c).after('<a href="#" class="'+b.next+'">Next</a>')),a("."+b.next,c).click(function(a){a.preventDefault(),b.play&&y(),w("next",i)}),a("."+b.prev,c).click(function(a){a.preventDefault(),b.play&&y(),w("prev",i)}),b.generatePagination?(b.prependPagination?c.prepend("<ul class="+b.paginationClass+"></ul>"):c.append("<ul class="+b.paginationClass+"></ul>"),d.children().each(function(){a("."+b.paginationClass,c).append('<li><a href="#'+m+'">'+(m+1)+"</a></li>"),m++})):a("."+b.paginationClass+" li a",c).each(function(){a(this).attr("href","#"+m),m++}),a("."+b.paginationClass+" li:eq("+h+")",c).addClass(b.currentClass),a("."+b.paginationClass+" li a",c).click(function(){return b.play&&y(),q=a(this).attr("href").match("[^#/]+$"),n!=q&&w("pagination",j,q),!1}),a("a.link",c).click(function(){return b.play&&y(),q=a(this).attr("href").match("[^#/]+$")-1,n!=q&&w("pagination",j,q),!1}),b.play&&(v=setInterval(function(){w("next",i)},b.play),c.data("interval",v))})},a.fn.slides.option={preload:!1,preloadImage:"/img/loading.gif",container:"slides_container",generateNextPrev:!1,next:"next",prev:"prev",pagination:!0,generatePagination:!0,prependPagination:!1,paginationClass:"pagination",currentClass:"current",fadeSpeed:350,fadeEasing:"",slideSpeed:350,slideEasing:"",start:1,effect:"slide",crossfade:!1,randomize:!1,play:0,pause:0,hoverPause:!1,autoHeight:!1,autoHeightSpeed:350,bigTarget:!1,animationStart:function(){},animationComplete:function(){},slidesLoaded:function(){}},a.fn.randomize=function(b){function c(){return Math.round(Math.random())-.5}return a(this).each(function(){var d=a(this),e=d.children(),f=e.length;if(f>1){e.hide();var g=[];for(i=0;i<f;i++)g[g.length]=i;g=g.sort(c),a.each(g,function(a,c){var f=e.eq(c),g=f.clone(!0);g.show().appendTo(d),b!==undefined&&b(f,g),f.remove()})}})}})(jQuery);
/**
* hoverIntent r6 // 2011.02.26 // jQuery 1.5.1+
* <http://cherne.net/brian/resources/jquery.hoverIntent.html>
* 
* @param  f  onMouseOver function || An object with configuration options
* @param  g  onMouseOut function  || Nothing (use configuration options object)
* @author    Brian Cherne brian(at)cherne(dot)net
*/
(function($){$.fn.hoverIntent=function(f,g){var cfg={sensitivity:7,interval:100,timeout:0};cfg=$.extend(cfg,g?{over:f,out:g}:f);var cX,cY,pX,pY;var track=function(ev){cX=ev.pageX;cY=ev.pageY};var compare=function(ev,ob){ob.hoverIntent_t=clearTimeout(ob.hoverIntent_t);if((Math.abs(pX-cX)+Math.abs(pY-cY))<cfg.sensitivity){$(ob).unbind("mousemove",track);ob.hoverIntent_s=1;return cfg.over.apply(ob,[ev])}else{pX=cX;pY=cY;ob.hoverIntent_t=setTimeout(function(){compare(ev,ob)},cfg.interval)}};var delay=function(ev,ob){ob.hoverIntent_t=clearTimeout(ob.hoverIntent_t);ob.hoverIntent_s=0;return cfg.out.apply(ob,[ev])};var handleHover=function(e){var ev=jQuery.extend({},e);var ob=this;if(ob.hoverIntent_t){ob.hoverIntent_t=clearTimeout(ob.hoverIntent_t)}if(e.type=="mouseenter"){pX=ev.pageX;pY=ev.pageY;$(ob).bind("mousemove",track);if(ob.hoverIntent_s!=1){ob.hoverIntent_t=setTimeout(function(){compare(ev,ob)},cfg.interval)}}else{$(ob).unbind("mousemove",track);if(ob.hoverIntent_s==1){ob.hoverIntent_t=setTimeout(function(){delay(ev,ob)},cfg.timeout)}}};return this.bind('mouseenter',handleHover).bind('mouseleave',handleHover)}})(jQuery);
/*! 
* FitVids 1.0
*
* Copyright 2011, Chris Coyier - http://css-tricks.com + Dave Rupert - http://daverupert.com
* Credit to Thierry Koblentz - http://www.alistapart.com/articles/creating-intrinsic-ratios-for-video/
* Released under the WTFPL license - http://sam.zoy.org/wtfpl/
*
* Date: Thu Sept 01 18:00:00 2011 -0500
*/
(function($){$.fn.fitVids=function(options){var settings={customSelector:null}
var div=document.createElement('div'),ref=document.getElementsByTagName('base')[0]||document.getElementsByTagName('script')[0];div.className='fit-vids-style';div.innerHTML='&shy;<style>         \
      .fluid-width-video-wrapper {        \
         width: 100%;                     \
         position: relative;              \
         padding: 0;                      \
      }                                   \
                                          \
      .fluid-width-video-wrapper iframe,  \
      .fluid-width-video-wrapper object,  \
      .fluid-width-video-wrapper embed {  \
         position: absolute;              \
         top: 0;                          \
         left: 0;                         \
         width: 100%;                     \
         height: 100%;                    \
      }                                   \
    </style>';ref.parentNode.insertBefore(div,ref);if(options){$.extend(settings,options);}
return this.each(function(){var selectors=["iframe[src^='http://player.vimeo.com']","iframe[src^='http://www.youtube.com']","iframe[src^='http://www.kickstarter.com']","object","embed"];if(settings.customSelector){selectors.push(settings.customSelector);}
var $allVideos=$(this).find(selectors.join(','));$allVideos.each(function(){var $this=$(this);if(this.tagName.toLowerCase()=='embed'&&$this.parent('object').length||$this.parent('.fluid-width-video-wrapper').length){return;}
var height=this.tagName.toLowerCase()=='object'?$this.attr('height'):$this.height(),aspectRatio=height/$this.width();if(!$this.attr('id')){var videoID='fitvid'+Math.floor(Math.random()*999999);$this.attr('id',videoID);}
$this.wrap('<div class="fluid-width-video-wrapper"></div>').parent('.fluid-width-video-wrapper').css('padding-top',(aspectRatio*100)+"%");$this.removeAttr('height').removeAttr('width');});});}})(jQuery);
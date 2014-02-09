$(document).ready(function () {
    initialize();
});

function initialize() {
    var marks = $(".mark");
    var markers = new Array();
    var homeLatlng = new google.maps.LatLng(
        Number($(".homezip").attr("data-homelat")),
        Number($(".homezip").attr("data-homelng")));
    var mapOptions = {
        center: homeLatlng,
        zoom: 6,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var mapCanvas = document.getElementById('map-canvas');
    if (mapCanvas != null) {
        map = new google.maps.Map(mapCanvas, mapOptions);
        var homeMarker = new google.maps.Marker({
            position: homeLatlng,
            map: map,
            draggable: false,
            animation: google.maps.Animation.DROP,
            title: $(".homezip").attr("data-zip")
        });
        homeMarker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');
        homeMarker.setMap(map);
        $.each($(".mark"), function (index, value) {
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(
                    Number($(value).attr("data-latitude")),
                    Number($(value).attr("data-longitude")
                    )),
                map: map,
                draggable: false,
                animation: google.maps.Animation.DROP,
                title: $(value).attr("data-eventname")
            });
            marker.setMap(map);
            var website;
            if ($(value).attr("data-website") === "") {
                website = "";
            } else {
                website = "<a href='" +
                    $(value).attr("data-website") + "' target='_blank'>Website<br/>";

            }
            var infowindow = new google.maps.InfoWindow({
                content: "<div class='infoDiv'><h4>" + $(value).attr("data-eventname") + "</h4>"
                    + "<h5>" + $(value).attr("data-date") + "</h5>" + $(value).attr("data-venue") + "<br/>"
                    + $(value).attr("data-address") 
                    + "<br/>" + website + 
                    "<br/><a href='https://maps.google.com/maps?f=d&saddr=" + $(".homezip").attr("data-zip")
                    + "&daddr=" + $(value).attr("data-address") + "' target='_blank'>Driving Directions</a><br/> " +
                    "<span class='infoWindowDistance'>From zipcode " + $(".homezip").attr("data-zip") + ": " +
                    $(value).attr("data-hours") + ", " + $(value).attr("data-distance") +
                    "</span></div>"
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
            });
        });
    };
}
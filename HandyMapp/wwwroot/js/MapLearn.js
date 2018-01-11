var map;
var markers = [];

var startLat;
var startLng;

var endLat;
var endLng;

function initMap() {
    map = new window.google.maps.Map(document.getElementById('map'),
        {
            center: { lat: 52.058295, lng: 4.4950389 },
            zoom: 13,
            mapTypeId: 'terrain',
            styles: [
                {
                    "featureType": "landscape.natural",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#cddebe"
                        }
                    ]
                },
                {
                    "featureType": "landscape.natural.terrain",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#a9adaf"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#e1c78e"
                        }
                    ]
                },
                {
                    "featureType": "poi.medical",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#f7bbff"
                        }
                    ]
                },
                {
                    "featureType": "poi.park",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#b7dc8d"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#81878b"
                        },
                        {
                            "weight": 0.5
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#f4f28c"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#ebe72c"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#f59d78"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#f06b33"
                        }
                    ]
                },
                {
                    "featureType": "road.highway.controlled_access",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#f06b33"
                        }
                    ]
                },
                {
                    "featureType": "road.highway.controlled_access",
                    "elementType": "geometry.stroke",
                    "stylers": [
                        {
                            "color": "#ca470f"
                        }
                    ]
                },
                {
                    "featureType": "transit.line",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#b8bcbe"
                        }
                    ]
                },
                {
                    "featureType": "water",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "color": "#7aa9ef"
                        }
                    ]
                }
            ]
        });

    map.addListener('zoom_changed', function () {
        if (map.getZoom() > 15) {
            map.setMapTypeId('roadmap');
        } else {
            map.setMapTypeId('terrain');
        }

    });

    google.maps.event.addListener(map, 'click', function (event) {
        if (markers.length >= 2) {
            clearMarkers();
            $("#start").val("");
            $("#end").val("");
        }
        placeMarker(event.latLng);
    });

    function placeMarker(location) {
        markers.push(new window.google.maps.Marker({
            position: location,
            map: map
        }));
        $("#start").val(markers[0].getPosition());
        startLat = markers[0].getPosition().lat();
        startLng = markers[0].getPosition().lng();
        if (markers[1]){
            $("#end").val(markers[1].getPosition());
            endLat = markers[1].getPosition().lat();
            endLng = markers[1].getPosition().lng();
        }
    }

    var Vectors = @Html.Raw(Json.Serialize(Model));

    console.log(Vectors);
}

function clearMarkers() {
    markers.forEach(function (marker) {
        marker.setMap(null);
    });
    markers.length = 0;
}

$("#button").click(function () {

    console.log($("#start").val());

    if (markers.length === 2) {
        $.ajax({
            type: 'post',
            url: '/Navigation/LearnAlgorithm',
            data: { startLat: startLat, startLng: startLng, endLat: endLat, endLng: endLng },
            success: function (result) {

            },
            error: window.errorFunc
        }).done(function () {

        });
    }
});

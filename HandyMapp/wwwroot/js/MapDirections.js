var map;
var markers = [];

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


    // Instantiate a directions service.
    directionsService = new google.maps.DirectionsService;
    directionsDisplay = new google.maps.DirectionsRenderer({map: map });

    map.addListener('zoom_changed', function () {
        if (map.getZoom() > 15) {
            map.setMapTypeId('roadmap');
        } else {
            map.setMapTypeId('terrain');
        }
    });
}

function clearMarkers() {
    markers.forEach(function (marker) {
        marker.setMap(null);
    });
    markers.length = 0;
}


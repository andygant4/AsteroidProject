var coords;

var countries = ["Liberia", "Spain", "United Arab Emirates", "Somalia"];

var locationIndex = 0;

//$('form').submit(function (event) {
//    event.preventDefault();
//});

function submitAnswer() {
    if ($('#txt-country').val() === countries[locationIndex])
        alert("Correct!");
    else
        alert("Memes!");
    locationIndex = mod(++locationIndex, (countries.length - 1));
    updateMap(locationIndex);
    console.log($('#txt-country').val());
    $('#txt-country').text("");
};

function initMap() {
    GetGPSData();
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: parseFloat(coords[locationIndex].Latitude), lng: parseFloat(coords[locationIndex].Longitude) },
        zoom: 18,
        mapTypeId: 'satellite'
    });
    map.setTilt(45);
};

function updateMap(locIndex) {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: parseFloat(coords[locIndex].Latitude), lng: parseFloat(coords[locIndex].Longitude) },
        zoom: 18,
        mapTypeId: 'satellite'
    });
    map.setTilt(45);
};

function GetGPSData() {
    $.ajaxSetup({ async: false });
    $.ajax({
        type: "POST",
        url: "mapGuesser.aspx/GetGPSData",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            coords = JSON.parse(response.d);
            console.log(coords[0])
        },
    });
};

$('#txt-country').keypress(function (e) {
    console.log("keypress");
    if (e.which === 13)
        submitAnswer();
});

function mod(n, m) {
    return ((n % m) + m) % m;
}

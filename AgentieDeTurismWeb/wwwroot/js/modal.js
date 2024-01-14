$('.btn-primary').on('click', function () {
    var list = ["From:","Departure time:","Arrival time:","To:"];

    // Get the button object that triggered the event
    var button = this;
    const obj = JSON.parse('[{"id":"15116-11149-2401010555-2401010745--30596","origin":{"id":null,"name":"BucharestOtopeni","displayCode":"OTP","city":null,"isHighlighted":false,"flightPlaceId":"OTP","type":"Airport"},"destination":{"id":null,"name":"Dortmund","displayCode":"DTM","city":null,"isHighlighted":false,"flightPlaceId":"DTM","type":"Airport"},"departure":"2024-01-01T05:55:00","arrival":"2024-01-01T07:45:00","durationInMinutes":170,"flightNumber":"3091"}]');
    var itineraries = button.getAttribute('data-itineraries');
    var it = itineraries = JSON.parse(itineraries);
    for (var object in it) {
        var segment = it[object];
        var origin = segment.origin;
        var destination = segment.destination;
        var arrival = segment.arrival;
        var departure = segment.departure;

        list.push(origin.name, departure, arrival, destination.name);
    }

    addListToColumns(list);
});


function addListToColumns(list) {
    var column1 = document.getElementById('column1');
    var column2 = document.getElementById('column2');
    var column3 = document.getElementById('column3');
    var column4 = document.getElementById('column4');

    // Clear previous content
    column1.innerHTML = '';
    column2.innerHTML = '';
    column3.innerHTML = '';
    column4.innerHTML = '';

    // Calculate the number of items per column
    var itemsPerRow = 4;

    // Loop through the list and add items to columns
    for (var i = 0; i < list.length; i++) {
        if (i % itemsPerRow == 0) {
            column1.innerHTML += '<p>' + list[i] + '</p>';
        } else if (i % itemsPerRow == 1) {
            column2.innerHTML += '<p>' + list[i] + '</p>';
        } else if (i % itemsPerRow == 2) {
            column3.innerHTML += '<p>' + list[i] + '</p>';
        } else {
            column4.innerHTML += '<p>' + list[i] + '</p>';
        }
    }
}
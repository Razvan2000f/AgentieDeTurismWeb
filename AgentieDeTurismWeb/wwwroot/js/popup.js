function ShowActivity() {
    var p = document.getElementById("popup-content");
    var model = p.getAttribute('data-activities');
    var mParsed = JSON.parse(model);
    var activities = mParsed.activities;

    var randomInt = getRandomInt(0, activities.length);
    p.innerHTML = activities[randomInt].activity;
    var a = 10;
}
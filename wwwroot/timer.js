
function startTimer(duration) {
    var timer = duration * 60, minutes, seconds;
    var x = setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        document.getElementById("countdown").innerHTML = minutes + ":" + seconds;

        if (--timer < 0) {
            clearInterval(x);
            document.getElementById("countdown").innerHTML = "Time's up!";
        }
    }, 1000);
}

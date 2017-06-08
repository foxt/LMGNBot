$(document).ready(function () {
    $(document).mousemove(function (e) {
        parallax(e, document.getElementById('body'), 0.25);
      parallax(e, document.getElementById('background-image'), -0.25);
    });
});

function showhelp() {
  document.getElementById("help").className += " help-shown";
}

function parallax(e, target, amplitude) {
    var layer_coeff = 10 / amplitude;
    var x = ($(window).width() - target.offsetWidth) / 2 - (e.pageX - ($(window).width() / 2)) / layer_coeff;
    var y = ($(window).height() - target.offsetHeight) / 2 - (e.pageY - ($(window).height() / 2)) / layer_coeff;
    $(target).offset({ top: y ,left : x });
};
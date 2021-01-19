function display() {
    document.getElementById('qr').style.display = "block";
}

function disappear() {
    document.getElementById('qr').style.display = "none";
}

var scrollTop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;

//显示图标
window.onscroll = function () {
    var scrollTop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
    var headheight = 0;
    if (scrollTop > headheight) {

        document.getElementById('return_top').style.display = "block";
    } else {
        document.getElementById('return_top').style.display = "none";
    }
}

//回到首部
var wrap = document.getElementsByClassName('wrap')[0];
wrap.onclick = function () {
    timer = setInterval(function () {
        var scrollTop = document.documentElement.scrollTop || document.body.scrollTop;
        var ispeed = Math.floor(-scrollTop / 6);
        console.log(ispeed)
        if (scrollTop == 0) {
            clearInterval(timer);
        }
        document.documentElement.scrollTop = document.body.scrollTop = scrollTop + ispeed;
    }, 30)
};

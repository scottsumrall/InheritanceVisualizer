function setInitialPos(str) {
    console.log(str);
    if (str != null) {
        var target = document.getElementsByClassName(str);


        var button = document.getElementById("button");
        let targetPos = getOffset(button);

        let leftPos = targetPos.left + 700;
        let topPos = targetPos.top + 300;

        for (var i = 0; i < target.length; i++) {
            //target.style.transform = `translate(${leftPos}px, ${topPos}px)`;
            target[i].style.left = (leftPos + "px");
            target[i].style.top = (topPos + "px");

            console.log(target[i].style.left);
            console.log(target[i].style.top);

            target[i].classList.remove(str)
        }
    }
}

function centerChart() {
    var chart = document.getElementById("scrollable");

    var maxScrollLeft = chart.scrollWidth - chart.clientWidth;
    var maxScrollTop = chart.scrollHeight - chart.clientHeight;

    chart.scrollTop = maxScrollLeft/2;
    chart.scrollLeft = maxScrollTop/2;
}
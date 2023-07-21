function setInitialPos(str) {
    console.log("hit");
    if (str != null) {
        var target = document.getElementById(str);
        console.log("ID NAME: " + str);
        var button = document.getElementById("button");
        let targetPos = getOffset(button);

        let leftPos = targetPos.left + 700;
        let topPos = targetPos.top + 300;

        //target.style.transform = `translate(${leftPos}px, ${topPos}px)`;
        target.style.left = (leftPos + "px");
        target.style.top = (topPos + "px");

        console.log(target.style.left);
        console.log(target.style.top);
    }
}

function centerChart() {
    var chart = document.getElementById("scrollable");

    var maxScrollLeft = chart.scrollWidth - chart.clientWidth;
    var maxScrollTop = chart.scrollHeight - chart.clientHeight;

    chart.scrollTop = maxScrollLeft/2;
    chart.scrollLeft = maxScrollTop/2;
}
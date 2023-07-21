var trackingPoint = "testerID";
var originPoint;

var targetLine;

var active = false;

function selectLinePoint(elementId) {

    active = !active;
    originPoint = document.getElementById(elementId);
    initializeSvg();
    targetLine = document.getElementById("leader_line");
}

const onMouseMove = (e) => {
    if (active) {


        let curDiv = document.getElementById(trackingPoint);


                             //may need to use offsetX offsetY instead for container
        curDiv.style.left = e.pageX + 'px';
        curDiv.style.top = e.pageY + 'px';
        
        console.log(e.pageX)

        targetLine.setAttribute('x1', '0');
        targetLine.setAttribute('y1', '0');

        /*targetLine.animate({ x2: pos2Left, y2: pos2Top });*/

    }
}
document.addEventListener('mousemove', onMouseMove);

function initializeSvg() {

    let curDiv = document.getElementById(originPoint);

    var pos1Left = String(originPoint.offsetLeft);
    var pos1Top = String(originPoint.offsetTop);


    svg = document.getElementById("targetSvg");
    var newLine = document.createElementNS('http://www.w3.org/2000/svg', 'line');
    newLine.setAttribute('id', 'leader_line');
    newLine.setAttribute('x1', '500');
    newLine.setAttribute('y1', '500');
    newLine.setAttribute('x2', pos1Left);
    newLine.setAttribute('y2', pos1Top);
    newLine.setAttribute("stroke", "black");
    svg.appendChild(newLine);
}
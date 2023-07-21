const divs = {}; // Object to hold div IDs as keys to lines
const cords = {}; // Object to hold lines as keys to indices
const height = 100; // height of divs
const width = 200; // width of divs

document.getElementsByClassName('draggable').height = '100';
document.getElementsByClassName('draggable').width = '100';

let patchCordActive = false;
let currentSelectionX;
let currentSelectionY;
let divCounter = 0;
let patchCordCounter = 0;
let selectedDiv;
let root = document.documentElement;

function testDragAndDrop(className) {
    const position = { x: 0, y: 0 }


    interact(className)
        .resizable({
            // resize from all edges and corners
            edges: { left: true, right: true, bottom: true, top: true },

            listeners: {
                move(event) {
                    var target = event.target
                    var x = (parseFloat(target.getAttribute('data-x')) || 0)
                    var y = (parseFloat(target.getAttribute('data-y')) || 0)

                    // update the element's style
                    target.style.width = event.rect.width + 'px'
                    target.style.height = event.rect.height + 'px'

                    // translate when resizing from top or left edges
                    x += event.deltaRect.left
                    y += event.deltaRect.top

                    target.style.transform = 'translate(' + x + 'px,' + y + 'px)'

                    target.setAttribute('data-x', x)
                    target.setAttribute('data-y', y)

                    /*target.textContent = Math.round(event.rect.width) + '\u00D7' + Math.round(event.rect.height)*/
                }
            },
            modifiers: [
                // keep the edges inside the parent
                interact.modifiers.restrictEdges({
                    outer: 'parent'
                }),

                interact.modifiers.aspectRatio({
                    // make sure the width is always double the height
                    ratio: 2,
                    // also restrict the size by nesting another modifier
                    modifiers: [
                        interact.modifiers.restrictSize({ max: 'parent' }),
                    ],
                }),
                // minimum size
                interact.modifiers.restrictSize({
                    min: { width: 400, height: 200 }
                })
            ],

            inertia: true
        })
        .draggable({
            inertia: false,
            autoScroll: true,
            onmove: dragMoveListener
        }
        )
};


function dragMoveListener(event) {
    var target = event.target;
    target.style.position = 'absolute';

    x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
        y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;



    target.style.webkitTransform =
        target.style.transform =
        'translate(' + x + 'px, ' + y + 'px)';
    target.setAttribute('data-x', x);
    target.setAttribute('data-y', y);

    handleScrollBounds(target);

    target.style.transform = `translate(${x}px, ${y}px)`;

}

function handleScrollBounds(target)
{


    const container = target.parentNode;
    const containerRect = container.getBoundingClientRect();
    const containerWidth = container.offsetWidth;
    const containerHeight = container.offsetHeight;
    const threshold = 100; // Adjust the threshold as needed
    const increment = 50;
    //// Check if the dragged element is near the container edges
    const isNearTop = event.clientY < containerRect.top + threshold;
    const isNearBottom = event.clientY > containerRect.bottom - threshold;
    const isNearLeft = event.clientX < containerRect.left + threshold;
    const isNearRight = event.clientX > containerRect.right - threshold;

    var topVal = parseInt(target.style.top, 10);
    var leftVal = parseInt(target.style.left, 10);

    // Expand the container if necessary
    if (isNearTop) {
        container.scrollTop -= increment;
        target.style.top = (topVal - increment) + "px";
    } else if (isNearBottom) {
        container.scrollTop += increment;
        target.style.top = (topVal + increment) + "px";
    }

    if (isNearLeft) {
        container.scrollLeft -= increment;
        target.style.left = (leftVal - increment) + "px";
    } else if (isNearRight) {
        container.scrollLeft += increment;
        target.style.left = (leftVal + increment) + "px";
    }
}

function setInitialPos(str)
{
    console.log("hit");
    if (str != null) {
        var target = document.getElementById(str);
        console.log("ID NAME: " + str);
        var button = document.getElementById("button");
        let targetPos = getOffset(button);

        let leftPos = targetPos.left + 700;
        let topPos = targetPos.top + 300;

        target.style.left = (leftPos + "px");
        target.style.top = (topPos + "px");

        console.log(target.style.left);
        console.log(target.style.top);
    }
}

function getOffset(el) {
    const rect = el.getBoundingClientRect();
    parentEl = document.getElementById("scrollable");
    return {
        top: rect.top + parentEl.scrollTop,
        left: rect.left + parentEl.scrollLeft

    };
}

function createDiv() {

    // Set the height and width of the div with CSS variables
    root.style.setProperty('--height', height + "px");
    root.style.setProperty('--width', width + "px");

    let div = document.createElement('div');

    // Move the new div down 70px from the origin
    div.style.transform = "translate(0px, 70px)";
    div.setAttribute('data-y', 70);
    div.setAttribute('onclick', 'this.focus()');

    //Append the new div onto the "main" node
    document.getElementById('main').appendChild(div);
    div.style.backgroundColor = randomColor({ luminosity: 'light' });

    // Add the Interact.js class name to the div.
    div.className = 'draggable';

    // Set a unique ID for each div
    div.id = "div" + divCounter;
    divs[div.id] = [];
    divCounter += 1;

    div.innerHTML = "<div id='flex'><div id='inner' contenteditable='true' onclick='this.focus()' placeholder='Enter text here...'></div></div>";
}
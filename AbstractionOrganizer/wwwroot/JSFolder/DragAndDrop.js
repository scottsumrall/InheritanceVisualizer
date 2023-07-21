function dragAndDrop(className) {
    const position = { x: 100, y: 0 }

    interact(className)
        .draggable({

            inertia: true,
            autoScroll: true,
        listeners: {
            start(event) {
                console.log(event.type, event.target)
            },
            move(event) {
                position.x += event.dx
                position.y += event.dy

                event.target.style.transform =
                    `translate(${position.x}px, ${position.y}px)`
            },
        }, modifiers: [
            interact.modifiers.restrictRect({
                restriction: 'parent',
                endOnly: true
            })
        ],
        autoScroll: true
    })
};
function HandleInput(id, visible) {
    const btn = document.querySelector("button[data-itemId='" + id + "']")

    if (visible == true) {
        btn.style.display = "inline-block"
    }
    else {
        btn.style.display = "none"

    }
}
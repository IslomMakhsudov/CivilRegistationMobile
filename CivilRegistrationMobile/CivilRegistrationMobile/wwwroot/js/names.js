let list = document.querySelector("#namesList");
let nameInput = document.querySelector("#name");



async function showList(text) {
    let buttons = document.querySelectorAll("#btn");
    buttons.forEach(btn => btn.remove());
    
    const response = await fetch("/Application/GetNames?name=" + text.toUpperCase(), {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const names = await response.json();

        let buttons = document.querySelectorAll("#btn");

        if (buttons.length < 5) {
            names.forEach(function(name){
                let button = document.createElement("button");
                button.textContent = name.name;
                button.id = "btn";
                button.type = "button";
                button.classList.add("list-group-item");
                button.classList.add("list-group-item-action");
                button.addEventListener("mouseover", () => {
                    console.log(button.textContent);
                    nameInput.value = button.textContent;
                    hideList();
                });
                list.appendChild(button);
            });
        }

        list.style.display = "";
    }


}

function clear() {
    let buttons = document.querySelectorAll("#btn");
    buttons.forEach(btn => btn.remove());
}

function hideList() {
    list.style.display = "none";
}

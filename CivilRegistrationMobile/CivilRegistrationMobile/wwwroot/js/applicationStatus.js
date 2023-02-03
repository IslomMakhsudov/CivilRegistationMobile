window.addEventListener("load", checkStatus, false);

async function checkStatus() {
    let upStatus = document.querySelector("#upStatus");
    let midStatus = document.querySelector("#midStatus");
    let botStatus = document.querySelector("#botStatus");
    let correctBtn = document.querySelector("#correctButton");
    let mainBtn = document.querySelector("#mainButton");

    const response = await fetch("/General/GetApplicationStatus");
    if (response.ok === true) {
        const statusID = await response.text();
        if (statusID == "1") {
            upStatus.style = "";
            midStatus.style = "display:none";
            botStatus.style = "display:none";
        }
        else if (statusID == "2" || statusID == "6" || statusID == "5") {
            upStatus.style = "";
            midStatus.style = "";
            botStatus.style = "display:none";
            if (statusID == "6") {
                correctBtn.style = "";
                mainBtn.classList.remove("btn-success");
                mainBtn.classList.add("btn-outline-success");
                
            }
        } else {
            upStatus.style = "";
            midStatus.style = "";
            botStatus.style = "";
        }
    }
}
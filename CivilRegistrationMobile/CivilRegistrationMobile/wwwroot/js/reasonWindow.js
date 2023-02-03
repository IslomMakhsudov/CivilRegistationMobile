async function showReasonWindow(applicationId) {
    if (applicationId !== null) {
        let reasonWindow = document.querySelector("#reasonWindow");
        if (reasonWindow !== null) {
            reasonWindow.classList.remove("hide");
        }
        const response = await fetch("/General/GetReasonLabel?applicationId=" + applicationId);
        if (response.ok === true) {
            const reasonText = await response.text();
            let textLabel = document.querySelector("#reasonText");
            textLabel.innerText = reasonText;
        }
    }
}

function hideReasonWindow() {
    let reasonWindow = document.querySelector("#reasonWindow");
    if (reasonWindow !== null) {
        reasonWindow.classList.add("hide");
    }
}
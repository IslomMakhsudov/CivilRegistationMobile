window.addEventListener("load", getApplicationStatus, false);

let applicant = document.querySelector("#applicantDetails");
let child = document.querySelector("#childDetails");
let father = document.querySelector("#fatherDetails");
let mother = document.querySelector("#motherDetails");
let input = document.querySelector("#buttonInput");
let link = document.querySelector("#buttonLink");
let checkbox = document.querySelector("#checkbox");

async function getApplicationStatus() {
    const response = await fetch("/General/GetNewbornRegistrationStatus", {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if (response.ok === true) {
        const num = await response.json();

        switch (num.code) {
            case 0:
                // Newborn start
                child.style.pointerEvents = "none";
                father.style.pointerEvents = "none";
                mother.style.pointerEvents = "none";
                break;
            case 1:
                // Applicant done
                child.style.pointerEvents = "";
                father.style.pointerEvents = "none";
                mother.style.pointerEvents = "none";
                break;
            case 2:
                // Child done
                father.style.pointerEvents = "";
                mother.style.pointerEvents = "none";
                break;
            case 3:
                // Father done
                mother.style.pointerEvents = "";
                break;
            case 4:
                // Mother done
                break;
            default:
                child.style.pointerEvents = "none";
                father.style.pointerEvents = "none";
                mother.style.pointerEvents = "none";
        }

        if (num.code == 4 && checkbox.checked == true) {
            input.disabled = false;
            link.style.pointerEvents = "";
        } else {
            input.disabled = true;
            link.style.pointerEvents = "none";
        }
    }
}
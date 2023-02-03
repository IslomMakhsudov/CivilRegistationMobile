window.addEventListener("load", checkFields, false);

let applicant = document.querySelector("#applicantDetails");

let applicantImage = document.querySelector("#applicantImage");
let childImage = document.querySelector("#childImage");


async function checkFields() {
    const response = await fetch("/General/GetNewbornRegistrationStatus", {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    let input = document.querySelector("#buttonInput");
    let child = document.querySelector("#childDetails");
    let link = document.querySelector("#buttonLink");
    let applicantImage = document.querySelector("#applicantImage");
    let childImage = document.querySelector("#childImage");
    let applicantIcon = document.querySelector("#applicantIcon");
    let childIcon = document.querySelector("#childIcon");

    changeImagesColor();

    if (response.ok === true) {
        const num = await response.json();

        switch (num.code) {
            case 0:
                // Newborn start
                disableElement(child);
                break;
            case 1:
                // Applicant done
                enableElement(child);
                break;
            case 2:
                break;
            default:
                disableElement(child);
        }

        let input = document.querySelector("#buttonInput");
        let checkbox = document.querySelector("#checkbox");
        if (num.code == 2 && checkbox.checked == true) {

            const responseView = await fetch("/General/GetViewOnly");
            if (responseView.ok === true) {
                const viewOnly = await responseView.text();
                if (viewOnly == "true") {
                    input.disabled = true;
                    disableElement(link);
                }
            }
            else
            {
                input.disabled = false;
                enableElement(link);
            }

        }
        else
        {
            input.disabled = true;
            disableElement(link);
        }
    }
    else {
        const response = await fetch("/General/GetCorrectedApplication", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });

        if (response.ok === true) {
            
            const applications = await response.json();
            const checkbox = document.querySelector("#checkbox");
            if (applications.applicant && applications.deceased && checkbox.checked === true) {
                input.disabled = false;
                enableElement(link);
            } else {
                input.disabled = true;
                disableElement(link);

                if (!applications.applicant) {
                    applicantImage.style = "display: none;";
                    applicantIcon.classList.remove("none");
                }
                if (!applications.deceased) {
                    childImage.style = "display:none";
                    childIcon.classList.remove("none");
                }
            }

        }
    }

    const exceptionStatus = await fetch("/General/GetNotInOneYearValue");
    if (exceptionStatus.ok === true) {
        showReasonWindow();
    }

}

function disableElement(element) {
    if (element !== null) {
        element.style.pointerEvents = "none";
    }
}
function enableElement(element) {
    if (element !== null) {
        element.style.pointerEvents = "";
    }
}

async function changeImagesColor() {
    const response = await fetch("/General/GetImagesColor", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const colors = await response.json();

        changeImage(applicantImage, colors.oneImage);
        changeImage(childImage, colors.twoImage);
    }
}

function changeImage(image, pictureName) {
    let index = image.src.indexOf("/images/");
    let newSource = image.src.slice(0, index);
    image.src = newSource + "/images/" + pictureName;
}
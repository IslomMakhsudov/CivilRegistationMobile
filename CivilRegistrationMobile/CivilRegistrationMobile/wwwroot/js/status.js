window.addEventListener("load", checkFields, false);

let applicant = document.querySelector("#applicantDetails");
let child = document.querySelector("#childDetails");
let father = document.querySelector("#fatherDetails");
let mother = document.querySelector("#motherDetails");
let input = document.querySelector("#buttonInput");
let link = document.querySelector("#buttonLink");

let applicantImage = document.querySelector("#applicantImage");
let childImage = document.querySelector("#childImage");
let fatherImage = document.querySelector("#fatherImage");
let motherImage = document.querySelector("#motherImage");

let applicantIcon = document.querySelector("#applicantIcon");
let childIcon = document.querySelector("#childIcon");
let fatherIcon = document.querySelector("#fatherIcon");
let motherIcon = document.querySelector("#motherIcon");

async function checkFields() {
    
    const response = await window.fetch("/General/GetNewbornRegistrationStatus", {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    changeImagesColor();

    if (response.ok === true) {
        const num = await response.json();

        switch (num.code) {
            case 0:
                // Newborn start
                disableElement(child);
                disableElement(father);
                disableElement(mother);
                break;
            case 1:
                // Applicant done
                enableElement(child);
                disableElement(father);
                disableElement(mother);
                break;
            case 2:
                // Child done
                enableElement(father);
                disableElement(mother);
                break;
            case 3:
                // Father done
                enableElement(mother);
                break;
            case 4:
                // Mother done
                break;
            default:
                disableElement(child);
                disableElement(father);
                disableElement(mother);
        }
        const checkbox = document.querySelector("#checkbox");
        if (num.code === 4 && checkbox.checked === true) {

            const responseView = await fetch("/General/GetViewOnly");
            if (responseView.ok === true) {
                const viewOnly = await responseView.text();
                if (viewOnly == "true") {
                    input.disabled = true;
                    disableElement(link);
                }
            } else {
                input.disabled = false;
                enableElement(link);
            }
        } else {
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
            if (applications.applicant && applications.child && applications.father && applications.mother && checkbox.checked === true) {
                input.disabled = false;
                enableElement(link);
            } else {
                input.disabled = true;
                disableElement(link);

                if (!applications.applicant) {
                    applicantImage.style = "display: none;";
                    applicantIcon.classList.remove("none");
                }
                if (!applications.child) {
                    childImage.style = "display:none";
                    childIcon.classList.remove("none");
                }
                if (!applications.father) {
                    fatherImage.style = "display:none";
                    fatherIcon.classList.remove("none");
                }
                if (!applications.mother) {
                    motherImage.style = "display:none";
                    motherIcon.classList.remove("none");
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
        if (fatherImage !== null) {
            changeImage(fatherImage, colors.threeImage);
        }
        if (motherImage !== null) {
            changeImage(motherImage, colors.fourImage);
        }
    }
}

function changeImage(image, pictureName) {
    let index = image.src.indexOf("/images/");
    let newSource = image.src.slice(0, index);
    image.src = newSource + "/images/" + pictureName;
}
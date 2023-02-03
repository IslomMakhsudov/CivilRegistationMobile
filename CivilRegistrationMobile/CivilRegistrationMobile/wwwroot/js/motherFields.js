window.addEventListener("load", checkFields, false);

async function checkFields() {
    const response = await fetch("/Application/GetMotherFields", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const fields = await response.json();

        for (let i = 0; i < fields.length; i++) {
            console.log(fields[i].name);

            switch (fields[i].name) {
                case "MothersCityDistrict":
                    let cities = document.querySelector("#cities");
                    cities.classList.add("border-red");
                    break;
                case "MothersSurname":
                    let lastName = document.querySelector("#lastName");
                    lastName.classList.add("border-red");
                    break;
                case "MothersName":
                    let name = document.querySelector("#name");
                    name.classList.add("border-red");
                    break;
                case "MothersCurrentCountry":
                    let countries = document.querySelector("#countries");
                    countries.classList.add("border-red");
                    break;
                case "MothersRegion":
                    let regions = document.querySelector("#regions");
                    regions.classList.add("border-red");
                    break;
                case "MothersVillage":
                    let villages = document.querySelector("#villages");
                    villages.classList.add("border-red");
                    break;
                case "MothersCurrentAddress":
                    let currentAddress = document.querySelector("#currentAddress");
                    currentAddress.classList.add("border-red");
                    break;
                case "MothersPatronymic":
                    let patronymic = document.querySelector("#patronymic");
                    patronymic.classList.add("border-red");
                    break;
                case "MothersPassportNumber":
                    let passportNumber = document.querySelector("#passportNumber");
                    passportNumber.classList.add("border-red");
                    break;
                case "MothersPassportGivingOrgan":
                    let issuingAuth = document.querySelector("#issuingAuth");
                    issuingAuth.classList.add("border-red");
                    break;
                case "MothersDocumentAddressLink1":
                    let picture1 = document.querySelector("#documentInput1");
                    picture1.classList.add("border-red");
                    break;
                case "MothersDocumentAddressLink2":
                    let picture2 = document.querySelector("#documentInput2");
                    picture2.classList.add("border-red");
                    break;
                case "MothersDocumentAddressLink3":
                    let picture3 = document.querySelector("#documentInput3");
                    picture3.classList.add("border-red");
                    break;
                case "MothersBirthday":
                    let birthday = document.querySelector("#birthday");
                    birthday.classList.add("border-red");
                    break;
                case "MothersCitizenship":
                    let citizenship = document.querySelector("#citizenship");
                    citizenship.classList.add("border-red");
                    break;
                case "MothersNationality":
                    let nationality = document.querySelector("#nationality");
                    nationality.classList.add("border-red");
                    break;
                case "MothersCurrentAddressLivingStartTime":
                    let liveFrom = document.querySelector("#liveFrom");
                    liveFrom.classList.add("border-red");
                    break;
                case "MothersPlaceOfWork":
                    let workPlace = document.querySelector("#workPlace");
                    workPlace.classList.add("border-red");
                    break;
                case "MothersEducationLevel":
                    let education = document.querySelector("#education");
                    education.classList.add("border-red");
                    break;
                default:
            }
        }
    }
    else {


    }
}

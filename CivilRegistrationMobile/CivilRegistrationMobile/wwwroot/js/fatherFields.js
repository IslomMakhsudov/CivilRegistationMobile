window.addEventListener("load", checkFields, false);

async function checkFields() {
    const response = await fetch("/Application/GetFatherFields", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const fields = await response.json();

        for (let i = 0; i < fields.length; i++) {
            console.log(fields[i].name);

            switch (fields[i].name) {
                case "FathersCityDistrict":
                    let cities = document.querySelector("#cities");
                    cities.classList.add("border-red");
                    break;
                case "FathersSurname":
                    let lastName = document.querySelector("#lastName");
                    lastName.classList.add("border-red");
                    break;
                case "FathersName":
                    let name = document.querySelector("#name");
                    name.classList.add("border-red");
                    break;
                case "FathersCurrentCountry":
                    let countries = document.querySelector("#countries");
                    countries.classList.add("border-red");
                    break;
                case "FathersRegion":
                    let regions = document.querySelector("#regions");
                    regions.classList.add("border-red");
                    break;
                case "FathersVillage":
                    let villages = document.querySelector("#villages");
                    villages.classList.add("border-red");
                    break;
                case "FathersCurrentAddress":
                    let currentAddress = document.querySelector("#currentAddress");
                    currentAddress.classList.add("border-red");
                    break;
                case "FathersPatronymic":
                    let patronymic = document.querySelector("#patronymic");
                    patronymic.classList.add("border-red");
                    break;
                case "PassportNumber":
                    let passportNumber = document.querySelector("#passportNumber");
                    passportNumber.classList.add("border-red");
                    break;
                case "PassportGivingOrgan":
                    let issuingAuth = document.querySelector("#issuingAuth");
                    issuingAuth.classList.add("border-red");
                    break;
                case "FathersAddressLink1":
                    let picture1 = document.querySelector("#documentInput1");
                    picture1.classList.add("border-red");
                    break;
                case "FathersAddressLink2":
                    let picture2 = document.querySelector("#documentInput2");
                    picture2.classList.add("border-red");
                    break;
                case "FathersBirthday":
                    let birthday = document.querySelector("#birthday");
                    birthday.classList.add("border-red");
                    break;
                case "FathersCitizenship":
                    let citizenship = document.querySelector("#citizenship");
                    citizenship.classList.add("border-red");
                    break;
                case "FathersNationality":
                    let nationality = document.querySelector("#nationality");
                    nationality.classList.add("border-red");
                    break;
                case "FathersCurrentAddressLivingStartTime":
                    let liveFrom = document.querySelector("#liveFrom");
                    liveFrom.classList.add("border-red");
                    break;
                case "FathersPlaceOfWork":
                    let workPlace = document.querySelector("#workPlace");
                    workPlace.classList.add("border-red");
                    break;
                case "FathersEducationLevel":
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

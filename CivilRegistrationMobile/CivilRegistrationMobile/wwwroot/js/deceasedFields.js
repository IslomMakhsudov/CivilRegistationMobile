window.addEventListener("load", checkFields, false);

async function checkFields() {
    const response = await fetch("/Application/GetDeceasedFields", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const fields = await response.json();

        for (let i = 0; i < fields.length; i++) {
            console.log(fields[i].name);

            switch (fields[i].name) {
                case "DeceasedSurname":
                    let lastName = document.querySelector("#surname");
                    lastName.classList.add("border-red");
                    break;
                case "DeceasedName":
                    let name = document.querySelector("#name");
                    name.classList.add("border-red");
                    break;
                case "DeceasedPatronymic":
                    let patronymic = document.querySelector("#patronymic");
                    patronymic.classList.add("border-red");
                    break;
                case "DeceasedCountry":
                    let currentCountry = document.querySelector(".currentCountry");
                    currentCountry.classList.add("border-red");
                    break;
                case "DeceasedRegion":
                    let currentRegion = document.querySelector(".currentRegion");
                    currentRegion.classList.add("border-red");
                    break;
                case "DeceasedCityDistrict":
                    let currentCity = document.querySelector(".currentCity");
                    currentCity.classList.add("border-red");
                    break;
                case "DeceasedVillage":
                    let currentVillage = document.querySelector(".currentVillage");
                    currentVillage.classList.add("border-red");
                    break;
                case "DeceasedAddress":
                    let currentAddress = document.querySelector(".currentAddress");
                    currentAddress.classList.add("border-red");
                    break;
                case "DeceasedDeathCountry":
                    let deathCountry = document.querySelector(".deathCountry");
                    deathCountry.classList.add("border-red");
                    break;
                case "DeceasedDeathRegion":
                    let deathRegion = document.querySelector(".deathRegion");
                    deathRegion.classList.add("border-red");
                    break;
                case "DeceasedDeathCityDistrict":
                    let deathCity = document.querySelector(".deathCity");
                    deathCity.classList.add("border-red");
                    break;
                case "DeceasedDeathVillage":
                    let deathVillage = document.querySelector(".deathVillage");
                    deathVillage.classList.add("border-red");
                    break;
                case "DeceasedDeathAddress":
                    let deathAddress = document.querySelector(".deathAddress");
                    deathAddress.classList.add("border-red");
                    break;
                case "DeceasedBirthCountry":
                    let birthCountry = document.querySelector(".birthCountry");
                    birthCountry.classList.add("border-red");
                    break;
                case "DeceasedBirthRegion":
                    let birthRegion = document.querySelector(".birthRegion");
                    birthRegion.classList.add("border-red");
                    break;
                case "DeceasedBirthCityDistrict":
                    let birthCity = document.querySelector(".birthCity");
                    birthCity.classList.add("border-red");
                    break;
                case "DeceasedBirthVillage":
                    let birthVillage = document.querySelector(".birthVillage");
                    birthVillage.classList.add("border-red");
                    break;
                case "DeceasedBirthAddress":
                    let birthAddress = document.querySelector(".birthAddress");
                    birthAddress.classList.add("border-red");
                    break;
                case "DeceasedSex":
                    let sex = document.querySelector("#sex");
                    sex.classList.add("border-red");
                    break;
                case "DeceasedBirthday":
                    let birthday = document.querySelector("#birthday");
                    birthday.classList.add("border-red");
                    break;
                case "DocumentDocumentsAddressLink1":
                    let picture1 = document.querySelector("#documentInput1");
                    picture1.classList.add("border-red");
                    break;
                case "DeceasedMaritalStatus":
                    let maritalStatus = document.querySelector("#maritalStatus");
                    maritalStatus.classList.add("border-red");
                    break;
                case "DeceasedCityzenship":
                    let citizenship = document.querySelector("#citizenship");
                    citizenship.classList.add("border-red");
                    break;
                case "DeceasedNationality":
                    let nationality = document.querySelector("#nationality");
                    nationality.classList.add("border-red");
                    break;
                case "DeceasedEducationLevel":
                    let education = document.querySelector("#education");
                    education.classList.add("border-red");
                    break;
                case "DeceasedPlaceOfWork":
                    let workPlace = document.querySelector("#workPlace");
                    workPlace.classList.add("border-red");
                    break;
            }
        }
    }
}

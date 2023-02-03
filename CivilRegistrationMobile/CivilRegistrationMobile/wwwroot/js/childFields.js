window.addEventListener("load", checkFields, false);

async function checkFields() {
    const response = await fetch("/Application/GetChildFields", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const fields = await response.json();

        for (let i = 0; i < fields.length; i++) {
            switch (fields[i].name) {
                case "ChildsCityDistrict":
                    let cities = document.querySelector("#cities");
                    cities.classList.add("border-red");
                    break;
                case "ChildsSurname":
                    let lastName = document.querySelector("#lastName");
                    lastName.classList.add("border-red");
                    break;
                case "ChildsName":
                    let name = document.querySelector(".selectize-input");
                    name.classList.add("border-red");
                    break;
                case "ChildsBirthday":
                    let birthday = document.querySelector("#birthday");
                    birthday.classList.add("border-red");
                    break;
                case "ChildsCountry":
                    let countries = document.querySelector("#countries");
                    countries.classList.add("border-red");
                    break;
                case "ChildsRegion":
                    let regions = document.querySelector("#regions");
                    regions.classList.add("border-red");
                    break;
                case "ChildsVillage":
                    let villages = document.querySelector("#villages");
                    villages.classList.add("border-red");
                    break;
                case "ChildsPatronymic":
                    let patronymic = document.querySelector("#patronymic");
                    patronymic.classList.add("border-red");
                    break;
                case "ChildsAddress":
                    let picture1 = document.querySelector("#documentInput1");
                    picture1.classList.add("border-red");
                    break;
                case "ChildsSex":
                    let sex = document.querySelector("#sex");
                    sex.classList.add("border-red");
                    break;
                case "Weight (gramm)":
                    let weight = document.querySelector("#weight");
                    weight.classList.add("border-red");
                    break;
                case "Height(cm)":
                    let height = document.querySelector("#height");
                    height.classList.add("border-red");
                    break;
                case "Number of newborns":
                    let newbornCount = document.querySelector("#newbornCount");
                    newbornCount.classList.add("border-red");
                    break;
                case "Which child in the family":
                    let childCount = document.querySelector("#childCount");
                    childCount.classList.add("border-red");
                    break;
                case "Duration of pregnancy (weeks)":
                    let pregnancyDuration = document.querySelector("#pregnancyDuration");
                    pregnancyDuration.classList.add("border-red");
                    break;
                default:
            }
        }
    }
    else {


    }
}

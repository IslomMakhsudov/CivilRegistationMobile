let checkbox = document.querySelector("#applicantCheckbox");
checkbox.addEventListener("change", setApplicantData, false);

async function setApplicantData() {
    let countriesList = document.querySelector("#countries");
    let regionsList = document.querySelector("#regions");
    let citiesList = document.querySelector("#cities");
    let villagesList = document.querySelector("#villages");
    let lastName = document.querySelector("#lastName");
    let applicantName = document.querySelector("#name");
    let patronymic = document.querySelector("#patronymic");
    let address = document.querySelector("#currentAddress");
    let passportNumber = document.querySelector("#passportNumber");
    let issuingAuth = document.querySelector("#issuingAuth");
    
    if (checkbox.checked == true) {
        const response = await fetch("/Application/GetApplicant", {
            method: "GET",
            headers: { "Accept": "Application/json" }
        });
        if (response.ok === true) {
            const applicantData = await response.json();

            
            if (countriesList !== null) {
                fillList(countriesList, applicantData.countryList);
            }
            if (regionsList !== null) {
                fillList(regionsList, applicantData.regionList);
            }
            if (citiesList !== null) {
                cityBool = true;
                fillList(citiesList, applicantData.cityList);

                if (villagesList !== null) {
                    if (applicantData.villageList.length != 0) {
                        fillList(villagesList, applicantData.villageList)
                    } else {
                        cityChange(citiesList);
                    }
                }
            }

            issuingAuth.value = applicantData.issuingAuth;
            lastName.value = applicantData.lastName;
            applicantName.value = applicantData.name;
            patronymic.value = applicantData.patronymic;
            address.value = applicantData.currentAddress;
            passportNumber.value = applicantData.passportNumber;
        }
    } else {
        issuingAuth.value = "";
        lastName.value = "";
        applicantName.value = "";
        patronymic.value = "";
        address.value = "";
        passportNumber.value = "";
    }
}

function fillList(list, data) {
    list.length = 1;
    list.options[0].selected = false;
    for (index in data) {
        list.options[list.options.length] = new Option(data[index].text, data[index].value, data[index].selected, data[index].selected);
    }
}
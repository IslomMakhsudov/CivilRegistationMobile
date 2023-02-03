let countrySelect = document.querySelectorAll("#countries");
let regionList = document.querySelectorAll("#regions");
let cityList = document.querySelectorAll("#cities");
let villageList = document.querySelectorAll("#villages");
let registryOfficesList = document.querySelector("#registryOffices");
let educationList = document.querySelector("#education");
let jobTypeList = document.querySelector("#jobType"); 
let residenceAddress = document.querySelector("#registerTo");

let countryValue = countrySelect[0].options[countrySelect.selectedIndex];


window.addEventListener("load", checkApplicationStatus, false);

async function checkApplicationStatus() {
    const currentFormName = await fetch("/Application/GetCurrentFormName");
        if (currentFormName.ok === true) {
            var formName = await currentFormName.text();
        }

    for (var i = 0; i < countrySelect.length; i++) {
        if (countrySelect[i] !== null) {
            countrySelect[i].remove(0);
        }
    }
    
    if (regionList !== null) {
        for (var i = 0; i < regionList.length; i++) {
            regionList[i].remove(0);
        }
    }
    if (cityList !== null) {
        for (var i = 0; i < cityList.length; i++) {
            cityList[i].remove(0);
        }
    }
    if (villageList !== null) {
        for (var i = 0; i < villageList.length; i++) {
            villageList[i].remove(0);
        }
    }
    if (registryOfficesList !== null) {
        registryOfficesList.remove(0);
    }
    if (residenceAddress !== null) {
        residenceAddress.remove(0);
    }
    
    let existCode;
    let statusCode;

    const applicantExists = await fetch("/Application/GetApplicantDataExist");
    if (applicantExists.ok === true) {
        existCode = await applicantExists.text();
        if (formName === "applicant") {
            if (existCode == "1") {
                for (var i = 0; i < cityList.length; i++) {
                    cityChange(cityList[i]);
                }
            }
        }
    }

    const response = await fetch("/Application/GetApplicationStatus");
    if (response.ok === true) {
        statusCode = await response.text();

        if (statusCode == "0" && existCode > 1) {
            for (var i = 0; i < countrySelect.length; i++) {
                countryChange(countrySelect[i]);
            }
        }

    }
    else {
       // countryChange(countryValue);
    }

    const applicationsCreated = await fetch("/Application/GetApplicationsCreated", {
        method: "GET",
        headers: { "Accept": "applicaton/json" }
    });

    const correctionStatus = await fetch("/General/GetCorrectingStatus", {
        method: "GET"
    });

    if (correctionStatus.ok === true) {
        let canvasBtn = document.querySelector("#canvasBtn");
        canvasBtn.style.display = "flex";
    }

    if (applicationsCreated.ok === true) {
        const applications = await applicationsCreated.json();

        if (formName === "child" || formName === "deceased") {

            const applicationsRejected = await fetch("/Application/GetApplicationRejected", {
                method: "GET"
            });


            if (statusCode === "1" && (applications.child === false && applications.deceased === false) && correctionStatus.ok === false && applicationsRejected.ok === false) {
                for (var i = 0; i < countrySelect.length; i++) {
                    countryChange(countrySelect[i]);
                }

                let maritalStatus = document.querySelector("#maritalStatus");
                if (maritalStatus !== null) {
                    addOption(maritalStatus, 1558, true);
                }

                if (educationList !== null) {
                    if (applications.child === false) {
                        if (correctionStatus.ok === false) {
                            addOption(educationList, 1554, true);
                        }
                    }
                }
            }
            else {
                const cityExists = await fetch("/General/GetCityId", {
                    method: "GET"
                });

                if (cityExists.ok === false) {
                    for (var i = 0; i < countrySelect.length; i++) {
                        countryChange(countrySelect[i]);
                    }
                }

                const regionExists = await fetch("/General/GetRegionId", {
                    method: "GET"
                });

                if (regionExists.ok === false) {
                    for (var i = 0; i < countrySelect.length; i++) {
                        countryChange(countrySelect[i]);
                    }
                }
            }
        }
        else if (formName === "father") {
            if (statusCode === "2" && applications.father === false && correctionStatus.ok === false) {
                for (var i = 0; i < countrySelect.length; i++) {
                    countryChange(countrySelect[i]);
                }
            }

            if (educationList !== null) {
                if (applications.father === false) {
                    if (correctionStatus.ok === false) {
                        addOption(educationList, 1554, true);
                    }
                }
            }
        }
        else if (formName === "mother") {
            if (statusCode === "3" && applications.mother === false && correctionStatus.ok === false) {
                for (var i = 0; i < countrySelect.length; i++) {
                    countryChange(countrySelect[i]);
                }
            }

            if (jobTypeList !== null) {
                if (applications.mother === false) {
                    if (correctionStatus.ok === false) {
                        addOption(jobTypeList, 1559, true);
                    }
                } else {
                    addOption(jobTypeList, 1559, false);
                }
            }

            if (educationList !== null) {
                if (applications.mother === false) {
                    if (correctionStatus.ok === false) {
                        addOption(educationList, 1554, true);
                    }
                } else {
                    addOption(educationList, 1554, false);
                }
            }
        }
        else if (formName === "applicant") {
            if (applications.applicant === false && correctionStatus.ok === false) {
                const regionExist = await fetch("/General/GetRegionId");
                if (regionExist.ok === false) {
                    for (var i = 0; i < countrySelect.length; i++) {
                        countryChange(countrySelect[i]);
                    }
                }
            }
        }
    }

    let input = document.querySelector("#buttonInput");
    let link = document.querySelector("#buttonLink");
    const responseView = await fetch("/General/GetViewOnly");
    if (responseView.ok === true) {
        const viewOnly = await responseView.text();
        if (viewOnly == "true") {
            input.disabled = true;
            //disableElement(link);
        }
    }

}

async function countryChange(selectList) {
    const response = await fetch("/Application/CountryChange/?id=" + selectList.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    let parent = selectList.closest(".accordion-body");
    let regionList = parent.querySelector("#regions");

    if (response.ok === true) {
        const regions = await response.json();
        
        regionList.length = 1;

        for (index in regions) {
            regionList.options[regionList.options.length] = new Option(regions[index].text, regions[index].value);
        }

        addOption(regionList, 1530, true);

    } else {
        regionList.length = 1;
        regionList.options[0].selected = "selected";

        cityList.length = 1;
        cityList.options[0].selected = "selected";

        villageList.length = 1;
        villageList.options[0].selected = "selected";

        if (registryOfficesList !== null) {
            registryOfficesList.length = 1;
            registryOfficesList.options[0].selected = "selected";
        }
    }
}

async function regionChange(selectList) {
    const response = await fetch("/Application/RegionChange/?id=" + selectList.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    let parent = selectList.closest(".accordion-body");
    let cityList = parent.querySelector("#cities");
    let villageList = parent.querySelector("#villages");

    if (response.ok === true) {
        const cities = await response.json();

        cityList.length = 1;
        cityList.options[0].selected = "selected";

        
        villageList.length = 1;
        villageList.options[0].selected = "selected";

        for (index in cities) {
            cityList.options[cityList.options.length] = new Option(cities[index].text, cities[index].value);
        }

        addOption(cityList, 1531, true);
    }
}

async function cityChange(selectList) {
    const response = await fetch("/Application/CityChange/?id=" + selectList.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    let parent = selectList.closest(".accordion-body");

    let registryOfficesList = parent.querySelector("#registryOffices");
    let villageList = parent.querySelector("#villages");

    if (response.ok === true) {

        const villageAndOffice = await response.json();
        
        villageList.length = 1;
        if (registryOfficesList !== null) {
            registryOfficesList.length = 1;

            for (index in villageAndOffice[0]) {
                registryOfficesList.options[registryOfficesList.options.length] = new Option(villageAndOffice[0][index].text, villageAndOffice[0][index].value);
            }

            addOption(registryOfficesList, 1437, true);

            if (villageAndOffice[1] !== null) {
                for (index in villageAndOffice[1]) {
                    villageList.options[villageList.options.length] = new Option(villageAndOffice[1][index].text, villageAndOffice[1][index].value);
                }
            }

            addOption(villageList, 1532, true);

        } else {
            if (villageAndOffice[1] !== null) {
                for (index in villageAndOffice[1]) {
                    villageList.options[villageList.options.length] = new Option(villageAndOffice[1][index].text, villageAndOffice[1][index].value);
                }
                addOption(villageList, 1532, true);
            }
        }

    }
}

async function villageChange(selectList) {
    const response = await fetch("/Application/VillageChange/?id=" + selectList.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    let parent = selectList.closest(".accordion-body");
    let registryOfficesList = parent.querySelector("#registryOffices");

    if (response.ok === true) {
        if (registryOfficesList !== null) {
            const registryOffices = await response.json();

            registryOfficesList.length = 1;
        
            for (index in registryOffices) {
                registryOfficesList.options[registryOfficesList.options.length] = new Option(registryOffices[index].text, registryOffices[index].value);
            }
            registryOfficesList[0] = new Option("Выберите орган загса");
            registryOfficesList[0].selected = "selected";
            registryOfficesList[0].disabled = "disabled";
        }
    }
}

async function addOption(list, code, selected) {

    const response = await fetch("/General/GetLabels?id=" + code)
    if (response.ok === true) {
        const result = await response.text();
        list.options[0] = new Option(result, "");
    }
    if (selected === true) {
        list.options[0].selected = "selected";
    }
    list.options[0].disabled = "disabled";
}

async function deceasedCityChange(selectList, code) {
    const response = await fetch("/Application/CityChange/?id=" + selectList.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    console.log(selectList);

    let parent = selectList.closest(".accordion-body");
    //let registryOfficesList = document.querySelector("#registryOffices");
    let villageList = parent.querySelector("#villages");

    if (response.ok === true) {
        const villageAndOffice = await response.json();

        villageList.length = 1;
        if (registryOfficesList !== null) {

            let formCode = "0";
            const decesedResponse = await fetch("/Application/GetApplicationFromCode");
            if (decesedResponse.ok === true) {
                formCode = await decesedResponse.text();
            }
            if (formCode !== "0") {
                if (formCode == "2") {
                        const codeResponse = await fetch("/Application/GetApplicantRegisterCode");
                        if (codeResponse.ok === true) {
                            let registerCode = await codeResponse.text();
                            if (registerCode == code) {
                                registryOfficesList.length = 1;

                                for (index in villageAndOffice[0]) {
                                    registryOfficesList.options[registryOfficesList.options.length] = new Option(villageAndOffice[0][index].text, villageAndOffice[0][index].value);
                                }

                                addOption(registryOfficesList, "Выберите орган загса");

                                if (villageAndOffice[1] !== null) {
                                    for (index in villageAndOffice[1]) {
                                        villageList.options[villageList.options.length] = new Option(villageAndOffice[1][index].text, villageAndOffice[1][index].value);
                                    }
                                }

                                addOption(villageList, "Выберите посёлок");
                            } else {
                                if (villageAndOffice[1] !== null) {
                                    for (index in villageAndOffice[1]) {
                                        villageList.options[villageList.options.length] = new Option(villageAndOffice[1][index].text, villageAndOffice[1][index].value);
                                    }
                                    addOption(villageList, "Выберите посёлок");
                                }
                            }
                        }
                    
                }
            }

            

        } else {
            if (villageAndOffice[1] !== null) {
                for (index in villageAndOffice[1]) {
                    villageList.options[villageList.options.length] = new Option(villageAndOffice[1][index].text, villageAndOffice[1][index].value);
                }
                addOption(villageList, "Выберите посёлок");
            }
        }

    }
}

async function deceasedVillageChange(selectList, code) {
    const response = await fetch("/Application/VillageChange/?id=" + selectList.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    console.log(selectList);

    const codeResponse = await fetch("/Application/GetApplicantRegisterCode");
    if (codeResponse.ok === true) {
        let registerCode = await codeResponse.text();
        if (registerCode == code) {
            
            let registryOfficesList = document.querySelector("#registryOffices");

            if (response.ok === true) {
                const registryOffices = await response.json();

                registryOfficesList.length = 1;

                for (index in registryOffices) {
                    registryOfficesList.options[registryOfficesList.options.length] = new Option(registryOffices[index].text, registryOffices[index].value);
                }
                registryOfficesList[0] = new Option("Выберите орган загса");
                registryOfficesList[0].selected = "selected";
                registryOfficesList[0].disabled = "disabled";
            }
        }
    }
}
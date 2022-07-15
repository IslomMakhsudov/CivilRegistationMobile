let countrySelect = document.querySelector("#countries");
let regionList = document.querySelector("#regions");
let citiesList = document.querySelector("#cities");
let villageList = document.querySelector("#villages");
let registryOfficesList = document.querySelector("#registryOffices");

let countryValue = countrySelect.options[countrySelect.selectedIndex];

window.addEventListener("load", countryChange(countryValue), false);

async function countryChange(e) {
    const response = await fetch("/Application/CountryChange/?id=" + e.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const regions = await response.json();
        
        regionList.length = 1;

        for (index in regions) {
            regionList.options[regionList.options.length] = new Option(regions[index].text, regions[index].value);
        }

        addOption(regionList, "Выберите регион");

    } else {
        regionList.length = 1;
        regionList.options[0].selected = "selected";

        citiesList.length = 1;
        citiesList.options[0].selected = "selected";

        villageList.length = 1;
        villageList.options[0].selected = "selected";

        registryOfficesList.length = 1;
        registryOfficesList.options[0].selected = "selected";
    }
}

async function regionChange(e) {
    const response = await fetch("/Application/RegionChange/?id=" + e.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const cities = await response.json();

        citiesList.length = 1;

        for (index in cities) {
            citiesList.options[citiesList.options.length] = new Option(cities[index].text, cities[index].value);
        }

        addOption(citiesList, "Выберите город");
    }
}

async function cityChange(e) {
    const response = await fetch("/Application/CityChange/?id=" + e.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const villageAndOffice = await response.json();
        
        villageList.length = 1;
        if (registryOfficesList !== null) {
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


                addOption(villageList, "Выберите посёлок")
                
            }
        }

    }
}

async function villageChange(e) {
    const response = await fetch("/Application/VillageChange/?id=" + e.value, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

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

function addOption(list, string) {
    list.options[0] = new Option(string, "");
    list.options[0].selected = "selected";
    list.options[0].disabled = "disabled";
}
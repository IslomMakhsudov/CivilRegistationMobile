window.addEventListener("load", checkFields, false);

async function checkFields() {
    const response = await fetch("/Application/GetApplicantFields", {
        method: "GET",
        headers: {"Accept": "application/json"}
    });
    if (response.ok === true) {
        const fields = await response.json();

        for (let i = 0; i < fields.length; i++) {
            switch (fields[i].name) {
                case "ApplicantsCityDistrict":
                    {
                        let cities = document.querySelector("#cities");
                        cities.classList.add("border-red");
                    }
                    break;
                case "ApplicantsSurname":
                    {
                        let lastName = document.querySelector("#lastName");
                        lastName.classList.add("border-red");
                    }
                    break;
                case "ApplicantsITNNumber":
                    {
                        let tin = document.querySelector("#tin");
                        tin.classList.add("border-red");
                    }
                    break;
                case "ApplicantsName":
                    {
                        let name = document.querySelector("#name");
                        name.classList.add("border-red");
                    }
                    break;
                case "ApplicantsTelephoneNumber":
                    {
                        let phoneNumber = document.querySelector("#phoneNumber");
                        phoneNumber.classList.add("border-red");
                    }
                    break;
                case "ApplicantsCountry":
                    {
                        let countries = document.querySelector("#countries");
                        countries.classList.add("border-red");
                    }
                    break;
                case "ApplicantsRegion":
                    {
                        let regions = document.querySelector("#regions");
                        regions.classList.add("border-red");
                    }
                    break;
                case "ApplicantsVillage":
                    {
                        let villages = document.querySelector("#villages");
                        villages.classList.add("border-red");
                    }
                    break;
                case "ApplicantsAddress":
                    {
                        let currentAddress = document.querySelector("#currentAddress");
                        currentAddress.classList.add("border-red");
                    }
                    break;
                case "ApplicantsPatronymic":
                    {
                        let patronymic = document.querySelector("#patronymic");
                        patronymic.classList.add("border-red");
                    }
                    break;
                case "ApplicantsPassportNumber":
                    {
                        let passportNumber = document.querySelector("#passportNumber");
                        passportNumber.classList.add("border-red");
                    }
                    break;
                case "ApplicantsPassportGivingOrgan":
                    {
                        let issuingAuth = document.querySelector("#issuingAuth");
                        issuingAuth.classList.add("border-red");
                    }
                    break;
                case "ApplicantsDocumentsAddressLink1":
                    {
                        let picture1 = document.querySelector("#documentInput1");
                        picture1.classList.add("border-red");
                    }
                    break;
                case "ApplicantsDocumentsAddressLink2":
                    {
                        let picture2 = document.querySelector("#documentInput2");
                        picture2.classList.add("border-red");
                    }
                    break;
            }
        }
    }


    const applicantResponse = await fetch("/Application/GetApplicantFromAmonat", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (applicantResponse.ok === true) {
        const applicantFromAmonat = await applicantResponse.json();

        if (applicantFromAmonat.currentCountry) {
            $('#countries option:not(:selected)').attr('disabled', 'disabled');
        }

        if (applicantFromAmonat.currentRegion) {
            $('#regions option:not(:selected)').attr('disabled', 'disabled');
        }

        if (applicantFromAmonat.currentCity) {
            $('#cities option:not(:selected)').attr('disabled', 'disabled');
        }

        if (applicantFromAmonat.currentVillage) {
            $('#villages option:not(:selected)').attr('disabled', 'disabled');
        }


        if (applicantFromAmonat.lastName) {
            document.querySelector("#lastName").readOnly = true;
        }

        if (applicantFromAmonat.tin) {
            document.querySelector("#tin").readOnly = true;
        }

        if (applicantFromAmonat.name) {
            document.querySelector("#name").readOnly = true;
        }

        if (applicantFromAmonat.phoneNumber) {
            document.querySelector("#phoneNumber").readOnly = true;
        }

        if (applicantFromAmonat.currentAddress) {
            document.querySelector("#currentAddress").readOnly = true;
        }

        if (applicantFromAmonat.patronymic) {
            document.querySelector("#patronymic").readOnly = true;
        }

        if (applicantFromAmonat.passportNumber) {
            document.querySelector("#passportNumber").readOnly = true;
        }

        if (applicantFromAmonat.issuingAuth) {
            document.querySelector("#issuingAuth").readOnly = true;
        }
    }

    const applicantDataResponse = await fetch("/Application/GetApplicantData", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (applicantDataResponse.ok === true) {
        const applicantFromAmonat = await applicantDataResponse.json();

        if (applicantFromAmonat.currentCountry) {
            $('#countries option:not(:selected)').attr('disabled', 'disabled');
        }

        if (applicantFromAmonat.currentRegion) {
            $('#regions option:not(:selected)').attr('disabled', 'disabled');
        }

        if (applicantFromAmonat.currentCity) {
            $('#cities option:not(:selected)').attr('disabled', 'disabled');
        }

        if (applicantFromAmonat.currentVillage) {
            $('#villages option:not(:selected)').attr('disabled', 'disabled');
        }


        if (applicantFromAmonat.lastName) {
            document.querySelector("#lastName").readOnly = true;
        }

        if (applicantFromAmonat.tin) {
            document.querySelector("#tin").readOnly = true;
        }

        if (applicantFromAmonat.name) {
            document.querySelector("#name").readOnly = true;
        }

        if (applicantFromAmonat.phoneNumber) {
            document.querySelector("#phoneNumber").readOnly = true;
        }

        if (applicantFromAmonat.currentAddress) {
            document.querySelector("#currentAddress").readOnly = true;
        }

        if (applicantFromAmonat.patronymic) {
            document.querySelector("#patronymic").readOnly = true;
        }

        if (applicantFromAmonat.passportNumber) {
            document.querySelector("#passportNumber").readOnly = true;
        }

        if (applicantFromAmonat.issuingAuth) {
            document.querySelector("#issuingAuth").readOnly = true;
        }
    }
}

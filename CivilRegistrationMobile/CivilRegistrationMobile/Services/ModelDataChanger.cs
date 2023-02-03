namespace CivilRegistrationMobile.Services;

public class ModelDataChanger
{
    private readonly IUnitOfWork _unit;

    public ModelDataChanger(IUnitOfWork unitOfWork)
    {
        _unit = unitOfWork;
    }
    public async Task<Applicant?> GetApplicant(int applicationId, int lang)
    {
        var applicantOld = await _unit.Applications.GetApplicantsDataMobile(applicationId, lang);
        if (applicantOld == null) return null;

        var application = await _unit.Applications.GetByID(applicationId);
        var applicationType = application.ApplicationTypeID;


        int specificId = applicationType == 1 ? 16 : 17;

        var applicationsDetail = await _unit.ApplicationsDetails
            .GetByPredicate(ad => ad.ApplicationID == applicationId && ad.SpecificApplicationDataID == specificId);

        string registerTo = "";
        if(applicationsDetail != null)
        {
            registerTo = applicationsDetail.Detail;
        }

        Applicant applicant = new()
        {
            CurrentCountry = applicantOld.ApplicantsCountryID,
            CurrentRegion = applicantOld.ApplicantsRegionID,
            CurrentCity = applicantOld.ApplicantsCityDistrictID,
            CurrentVillage = applicantOld.ApplicantsVillageID,
            CurrentAddress = applicantOld.ApplicantsAddress,
            LastName = applicantOld.ApplicantsSurname,
            Name = applicantOld.ApplicantsName,
            Patronymic = applicantOld.ApplicantsPatronymic,
            TIN = applicantOld.ApplicantsITNNumber,
            PassportNumber = applicantOld.ApplicantsPassportNumber,
            IssuingAuth = applicantOld.ApplicantsPassportGivingOrgan,
            PhoneNumber = applicantOld.ApplicantsTelephoneNumber,
            DocumentLink_1 = applicantOld.ApplicantsDocumentsAddressLink1,
            DocumentLink_2 = applicantOld.ApplicantsDocumentsAddressLink2,
            ApplicationType = applicationType,
            RegisterTo = Convert.ToInt32(registerTo)
        };
        return applicant;
    }
    public async Task<Child?> GetChild(int applicationId, int lang)
    {
        var sessionChild = await _unit.Applications.GetChildsDataMobile(applicationId, lang);
        if (sessionChild == null) return null;
        var newbornCount = 0;
        var childCount = 0;
        var weight = 0;
        var height = 0;
        var pregnancyDuration = 0;

        foreach (var item in sessionChild.SpecificChildsData)
            switch (item.SpecificApplicationDataID)
            {
                case 1:
                    weight = Convert.ToInt32(item.Value);
                    break;
                case 2:
                    height = Convert.ToInt32(item.Value);
                    break;
                case 3:
                    newbornCount = Convert.ToInt32(item.Value);
                    break;
                case 4:
                    childCount = Convert.ToInt32(item.Value);
                    break;
                case 5:
                    pregnancyDuration = Convert.ToInt32(item.Value);
                    break;
            }

        Child child = new()
        {
            CurrentCountry = sessionChild.ChildsCountryID,
            CurrentRegion = sessionChild.ChildsRegionID,
            CurrentCity = sessionChild.ChildsCityDistrictID,
            CurrentVillage = sessionChild.ChildsVillageID,
            LastName = sessionChild.ChildsSurname,
            Name = sessionChild.ChildsName,
            Patronymic = sessionChild.ChildsPatronymic,
            Sex = sessionChild.ChildsSex,
            DateOfBirth = sessionChild.ChildsBirthday.Date,
            TimeOfBirth = DateTime.Parse(sessionChild.ChildsBirthday.ToShortTimeString()),
            Birthplace = sessionChild.ChildsAddress,
            NewbornCount = newbornCount,
            ChildCount = childCount,
            Weight = weight,
            Height = height,
            PregnancyDuration = pregnancyDuration,
            DocumentLink_1 = sessionChild.ChildsDocumentsAddressLink1
            // Address name
        };


        return child;
    }

    public async Task<Father?> GetFather(int applicationId, int lang)
    {
        var sessionFather = await _unit.Applications.GetFathersDataMobile(applicationId);
        if (sessionFather == null) return null;

        Father father = new()
        {
            // Registry Office
            CurrentCountry = sessionFather.CurrentCountryID,
            CurrentRegion = sessionFather.CurrentRegionID,
            CurrentCity = sessionFather.CurrentCityDistrictID, 
            CurrentVillage = sessionFather.CurrentVillageID,
            CurrentAddress = sessionFather.CurrentAddress,
            LastName = sessionFather.Surname,
            Name = sessionFather.Name,
            Patronymic = sessionFather.Patronymic,
            DateOfBirth = sessionFather.Birthday.Date,
            IssuingAuth = sessionFather.PassportGivingOrgan,
            Citizenship = sessionFather.CityzenshipID,
            Nationality = sessionFather.NationalityID,
            PassportNumber = sessionFather.PassportNumber,
            LiveFrom = sessionFather.CurrentAddressLivingStartTime,
            WorkPlace = sessionFather.PlaceOfWork,
            Education = sessionFather.EducationLevelID,
            DocumentLink_1 = sessionFather.AddressLink1,
            DocumentLink_2 = sessionFather.AddressLink2
        };

        return father;
    }

    public async Task<Mother?> GetMother(int applicationId)
    {
        var sessionMother = await _unit.Applications.GetMothersDataMobile(applicationId);
        if (sessionMother == null) return null;

        Mother mother = new()
        {
            // Registry office
            CurrentCountry = sessionMother.CurrentCountryID,
            CurrentRegion = sessionMother.CurrentRegionID,
            CurrentCity = sessionMother.CurrentCityDistrictID,
            CurrentVillage = sessionMother.CurrentVillageID,
            CurrentAddress = sessionMother.CurrentAddress,
            LastName = sessionMother.Surname,
            Name = sessionMother.Name,
            Patronymic = sessionMother.Patronymic,
            DateOfBirth = sessionMother.Birthday,
            IssuingAuth = sessionMother.PassportGivingOrgan,
            Citizenship = sessionMother.CityzenshipID,
            Nationality = sessionMother.NationalityID,
            PassportNumber = sessionMother.PassportNumber,
            LiveFrom = sessionMother.CurrentAddressLivingStartTime,
            WorkPlace = sessionMother.PlaceOfWork,
            JobType = sessionMother.TypeOfActivitiesInWorkID,
            Education = sessionMother.EducationLevelID,
            DocumentLink_1 = sessionMother.DocumentAddressLink1,
            DocumentLink_2 = sessionMother.DocumentAddressLink2,
            DocumentLink_3 = sessionMother.DocumentAddressLink3
        };
        return mother;
    }

    public async Task<Deceased?> GetDeceased(int applicationId, int lang)
    {
        var sessionDeceased = await _unit.Applications.GetDeceasedDataMobile(applicationId, lang);
        if (sessionDeceased == null) return null;
        var registryOfficeId = _unit.Applications.GetByID(applicationId).Result.DepartmentID;
        var birthPlace = "";
        var deathPlace = "";
        var dateOfDeath = DateTime.MinValue;
        var deathAddressId = 0;
        var birthAddressId = 0;

        foreach (var item in sessionDeceased.SpecificDeceasedData)
            switch (item.SpecificApplicationDataID)
            {
                case 6:
                    dateOfDeath = DateTime.Parse(item.Value);
                    break;
                case 7:
                    birthAddressId = Convert.ToInt32(item.Value);
                    break;
                case 8:
                    birthPlace = item.Value;
                    break;
                case 9:
                    deathAddressId = Convert.ToInt32(item.Value);
                    break;
                case 10:
                    deathPlace = item.Value;
                    break;
            }

        var deathAddress = _unit.Addresses.GetByID(deathAddressId).Result;
        var birthAddress = _unit.Addresses.GetByID(birthAddressId).Result;
        Deceased deceased = new()
        {
            CurrentCountry = sessionDeceased.DeceasedCountryID,
            CurrentRegion = sessionDeceased.DeceasedRegionID,
            CurrentCity = sessionDeceased.DeceasedCityDistrictID,
            CurrentVillage = sessionDeceased.DeceasedVillageID,
            LastName = sessionDeceased.DeceasedSurname,
            Name = sessionDeceased.DeceasedName,
            Patronymic = sessionDeceased.DeceasedPatronymic,
            Sex = sessionDeceased.DeceasedSex,
            DateOfBirth = sessionDeceased.DeceasedBirthday,
            BirthAddress = birthPlace,
            DeathAddress = deathPlace,
            // Last live place
            DateOfDeath = dateOfDeath,
            DocumentLink_1 = sessionDeceased.DeceasedDocumentAddressLink,
            RegistryOffice = registryOfficeId,
            CurrentAddress = sessionDeceased.DeceasedAddress,
            WorkPlace = sessionDeceased.DeceasedPlaceOfWork,
            MaritalStatus = sessionDeceased.DeceasedMaritalStatusID,
            Education = sessionDeceased.DeceasedEducationLevelID,
            Citizenship = sessionDeceased.DeceasedCityzenshipID,
            Nationality = sessionDeceased.DeceasedNationalityID,
        };

        if (deathAddress != null)
        {
            deceased.DeathCountry = deathAddress.CountryID;
            deceased.DeathRegion = deathAddress.RegionID;
            deceased.DeathCity = deathAddress.CityDistrictID;
            deceased.DeathVillage = deathAddress.VillageID;
        }

        if (birthAddress == null) return deceased;
        deceased.BirthCountry = birthAddress.CountryID;
        deceased.BirthRegion = birthAddress.RegionID;
        deceased.BirthCity = birthAddress.CityDistrictID;
        deceased.BirthVillage = birthAddress.VillageID;

        return deceased;
    }

}
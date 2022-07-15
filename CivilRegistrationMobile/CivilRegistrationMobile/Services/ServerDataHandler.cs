namespace CivilRegistrationMobile.Services
{
    public class ServerDataHandler
    {
        readonly IUnitOfWork unit;
        readonly IWebHostEnvironment webHostEnvironment;
        public ServerDataHandler(IUnitOfWork unit, IWebHostEnvironment environment)
        {
            webHostEnvironment = environment;
            this.unit = unit;
        }
        // Get names of country, city, registry office and region from database
        public List<SelectListItem> GetCountryNames()
        {
            List<SelectListItem> countries = new();
            Task<IEnumerable<Countries>> countryTask = unit.BaseTypes.GetAllCountries();
            foreach (var obj in countryTask.Result)
            {
                if(obj.ShortName == "Тоҷикистон")
                {
                    countries.Add(new SelectListItem { Value = obj.CountryID.ToString(), Text = obj.ShortName, Selected = true});
                }
                else
                {
                    countries.Add(new SelectListItem { Value = obj.CountryID.ToString(), Text = obj.ShortName });
                }
            }
            return countries;
        }
        public List<SelectListItem> GetCitizenship()
        {
            List<SelectListItem> citizenship = new();
            Task<IEnumerable<Cityzenship>> citizenTask = unit.BaseTypes.GetAllCitizenship();
            foreach (var obj in citizenTask.Result)
            {
                if(obj.Name == "Ҷумҳурии Тоҷикистон")
                {
                    citizenship.Add(new SelectListItem { Value = obj.CityzenshipID.ToString(), Text = obj.Name, Selected = true});

                }
                else
                {
                    citizenship.Add(new SelectListItem { Value = obj.CityzenshipID.ToString(), Text = obj.Name});
                }
            }
            return citizenship;
        }
        public List<SelectListItem> GetNationality()
        {
            List<SelectListItem> nationality = new();
            Task<IEnumerable<Nationalities>> nationalityTask = unit.BaseTypes.GetAllNationalities();
            foreach (var obj in nationalityTask.Result)
            {
                if(obj.Name == "тоҷик")
                {
                    nationality.Add(new SelectListItem { Value = obj.NationalityID.ToString(), Text = obj.Name, Selected = true });
                }
                else
                {
                    nationality.Add(new SelectListItem { Value = obj.NationalityID.ToString(), Text= obj.Name });
                }
            }
            return nationality;
        }
        public List<SelectListItem> GetRegionsByCountryID(int countryID)
        {
            List<SelectListItem> regions = new();
            Task<IEnumerable<Regions>> regionsTask = unit.BaseTypes.GetRegionsOfCountry(countryID);
            foreach (var obj in regionsTask.Result)
            {
                regions.Add(new SelectListItem { Value = obj.RegionID.ToString(), Text = obj.Name});
            }
            return regions;
        }
        public List<SelectListItem> GetCitiesByRegionID(int regionID)
        {
            List<SelectListItem> cities = new();
            Task<IEnumerable<CitiesDistricts>> citiesTask = unit.BaseTypes.GetCitiesDistrictsOfRegion(regionID);
            foreach (var obj in citiesTask.Result)
            {
                cities.Add(new SelectListItem { Value = obj.CityDistrictID.ToString(), Text = obj.Name});
            }
            return cities;
        }
        public List<SelectListItem> GetVillagesByCityID(int cityID)
        {
            List<SelectListItem> villages = new();
            Task<IEnumerable<Villages>> villagesTask = unit.BaseTypes.GetVillagesOfCitiesDistricts(cityID);
            foreach (var obj in villagesTask.Result)
            {
                villages.Add(new SelectListItem { Value = obj.VillageID.ToString(), Text = obj.Name});
            }
            return villages;
        }
        public List<SelectListItem> GetOfficesByVillageOrCityID(int? villageID, int cityID)
        {
            List<SelectListItem> registryOffices = new();
            Task<IEnumerable<Addresses>> registryOfficesTask = unit.BaseTypes.GetAddressesOfVillagesOrCitiesDistricts(villageID, cityID);
            foreach (var obj in registryOfficesTask.Result)
            {
                registryOffices.Add(new SelectListItem { Value = obj.AddressID.ToString(), Text = obj.AddressName});
            }
            return registryOffices;
        }

        int addressID;
        int participantDataID;
        int customerID;
        public void SaveParticipantData(Applicant applicant)
        {
            ApplicationsParticipantsData participantsData = new()
            {
                Surname = applicant.LastName,
                Name = applicant.Name,
                Patronymic = applicant.Patronymic,
                PassportNumber = applicant.PassportNumber,
                PassportItnNumber = applicant.TIN,
                PassportGivingOrgan = applicant.IssuingAuth,
                TelephoneNumber = applicant.PhoneNumber,
                ApplicationTypeID = 1,
                ApplicationStatusID = 1,
                ApplicationMemberTypeID = 1
            };

            customerID = SaveCustomerData(applicant);
            participantsData.AddressID = addressID;

            participantsData.CustomerID = customerID;
            participantsData.ApplicationID = SaveApplicantData();

            GlobalData.ApplicationID = participantsData.ApplicationID;
            unit.ApplicationsParticipantsData.InsertData(participantsData);
            unit.Complete();
            participantDataID = participantsData.ApplicationParticipantsDataID;


            if(applicant.DocumentPicture_1 != null && applicant.DocumentPicture_2 != null)
            {
                SaveApplicationDocuments(applicant.DocumentPicture_1, 4);
                SaveApplicationDocuments(applicant.DocumentPicture_2, 5); 
            }
        }

        public void SaveParticipantData(Child child)
        {
            ApplicationsParticipantsData participantsData = new()
            {
                Surname = child.LastName,
                Name = child.Name,
                Patronymic = child.Patronymic,
                Birthday = child.DateOfBirth.ToDateTime(child.TimeOfBirth),
                Sex = child.Sex,
                CustomerID = SaveCustomerData(child),
                ApplicationTypeID = 1,
                ApplicationStatusID = 1,
                ApplicationMemberTypeID = 2,
                ApplicationID = GlobalData.ApplicationID,
                AddressID = addressID
            };

            SaveApplicationDetails(child.Weight, 1);
            SaveApplicationDetails(child.Height, 2);
            SaveApplicationDetails(child.NewbornCount, 3);
            SaveApplicationDetails(child.ChildCount, 4);
            SaveApplicationDetails(child.PregnancyDuration, 5);


            unit.ApplicationsParticipantsData.InsertData(participantsData);
            unit.Complete();
            participantDataID = participantsData.ApplicationParticipantsDataID;

            if(child.DocumentPicture_1 != null && child.DocumentPicture_2 != null)
            {
                SaveApplicationDocuments(child.DocumentPicture_1, 4);
                SaveApplicationDocuments(child.DocumentPicture_2, 5);
            }

        }

        public void SaveParticipantData(Father father)
        {
            ApplicationsParticipantsData participantsData = new()
            {
                Surname = father.LastName,
                Name = father.Name,
                Patronymic = father.Patronymic,
                Birthday = father.DateOfBirth.ToDateTime(TimeOnly.Parse("12:00 PM")),
                Sex = true,
                CustomerID = SaveCustomerData(father),
                ApplicationID = GlobalData.ApplicationID,
                ApplicationMemberTypeID = 3,
                ApplicationStatusID = 1,
                ApplicationTypeID = 1,
                PlaceOfWork = father.WorkPlace,
                ProfessionInWork = father.JobTitle,
                CurrentAddressLivingStartTime = father.LiveFrom.ToDateTime(TimeOnly.Parse("12:00 PM")),
                CurrentCitizenship = father.Citizenship
            };

            unit.ApplicationsParticipantsData.InsertData(participantsData);
            unit.Complete();
            participantDataID = participantsData.ApplicationParticipantsDataID;

            if(father.MarriageDocumentPicture_1 != null) SaveApplicationDocuments(father.MarriageDocumentPicture_1, 2);
            if(father.MarriageDocumentPicture_2 != null) SaveApplicationDocuments(father.MarriageDocumentPicture_2, 2);
            if(father.PersonDocumentPicture_1 != null) SaveApplicationDocuments(father.PersonDocumentPicture_1, 4);
            if(father.PersonDocumentPicture_2 != null) SaveApplicationDocuments(father.PersonDocumentPicture_2, 5);
        }
        
        public void SaveParticipantData(Mother mother)
        {
            ApplicationsParticipantsData participantsData = new()
            {
                Surname = mother.LastName,
                Name = mother.Name,
                Patronymic = mother.Patronymic,
                Birthday = mother.DateOfBirth.ToDateTime(TimeOnly.Parse("12:00 PM")),
                Sex = true,
                CustomerID = SaveCustomerData(mother),
                ApplicationID = GlobalData.ApplicationID,
                ApplicationMemberTypeID = 3,
                ApplicationStatusID = 1,
                ApplicationTypeID = 1,
                PlaceOfWork = mother.WorkPlace,
                ProfessionInWork = mother.JobTitle,
                CurrentAddressLivingStartTime = mother.LiveFrom.ToDateTime(TimeOnly.Parse("12:00 PM")),
                CurrentCitizenship = mother.Citizenship
            };

            unit.ApplicationsParticipantsData.InsertData(participantsData);
            unit.Complete();
            participantDataID = participantsData.ApplicationParticipantsDataID;

            if(mother.MarriageDocumentPicture_1 != null) SaveApplicationDocuments(mother.MarriageDocumentPicture_1, 2);
            if(mother.MarriageDocumentPicture_2 != null) SaveApplicationDocuments(mother.MarriageDocumentPicture_2, 2);
            if(mother.PersonDocumentPicture_1 != null) SaveApplicationDocuments(mother.PersonDocumentPicture_1, 4);
            if(mother.PersonDocumentPicture_2 != null) SaveApplicationDocuments(mother.PersonDocumentPicture_2, 5);
        }

       /* public void SaveParticipantData(Deceased deceased)
        {
            ApplicationsParticipantsData participantsData = new()
            {
                Surname = deceased.LastName,
                Name = deceased.Name,
                Patronymic = deceased.Patronymic,
                Birthday = deceased.DateOfBirth.ToDateTime(TimeOnly.Parse("12:00 PM")),
                Sex = deceased.Sex,
                CustomerID = SaveCustomerData(deceased),
                ApplicationID = GlobalData.ApplicationID,
                ApplicationMemberTypeID = 5,
                ApplicationStatusID = 1,
                ApplicationTypeID = 2
            };


        }*/

        private void SaveApplicationDetails(object detail, int specificID)
        {
            ApplicationsDetails childDetails = new()
            {
                ApplicationID = GlobalData.ApplicationID,
                Detail = detail.ToString(),
                MistakeStatus = 3,
                ApplicationTypeID = 1,
                SpecificApplicationDataID = specificID,
                ApplicationMemberTypeID = 2,
                LabelID = unit.SpecificApplicationData.GetLabelID(specificID).Result
            };

            unit.ApplicationsDetails.InsertData(childDetails);
        }

        private void SaveDeceasedDetails(object detail, int specificID)
        {
            ApplicationsDetails deceasedDetails = new()
            {
                ApplicationID = GlobalData.ApplicationID,
                Detail = detail.ToString(),
                MistakeStatus = 3,
                ApplicationTypeID = 2,
                SpecificApplicationDataID = specificID,
                ApplicationMemberTypeID = 5,
                LabelID = unit.SpecificApplicationData.GetLabelID(specificID).Result
            };

            unit.ApplicationsDetails.InsertData(deceasedDetails);
        }

        // Save applicant data to the database
        private int SaveApplicantData()
        {
            Applications applications = new()
            {
                CreatedTime = DateTime.Now,
                AcceptedTime = DateTime.Now,
                CompletedTime = DateTime.Now,
                RejectedTime = DateTime.Now,
                ExternalID = 1,
                ApplicationTypeID = 1,
                ApplicationSourceID = 1,
                ApplicationPaymentID = null,
                ApplicationStatusID = 1,
                PaymentSystemID = null
            };

            unit.Applications.InsertData(applications);
            // context.SaveChanges() is called here
            unit.Complete();

            return applications.ApplicationID;
        }
        private int SaveCustomerData(Applicant applicant)
        {
            Customers customer = new()
            {
                Surname = applicant.LastName,
                Name = applicant.Name,
                Patronymic = applicant.Patronymic,
                PassportNumber = applicant.PassportNumber,
                PassportItnNumber = applicant.TIN,
                PassportGivingOrgan = applicant.IssuingAuth,
                AddressID = SaveAddress(applicant),
                VillageID = applicant.CurrentVillage,
                CityDistrictID = applicant.CurrentCity,
                RegionID = applicant.CurrentRegion,
                CountryID = applicant.CurrentCountry
            };

            unit.Customers.InsertData(customer);
            unit.Complete();

            return customer.CustomerID;
        }

        private int SaveCustomerData(Child child)
        {
            Customers customer = new()
            {
                Surname = child.LastName,
                Name = child.Name,
                Patronymic = child.Patronymic,
                Birthday = child.DateOfBirth.ToDateTime(TimeOnly.Parse(child.TimeOfBirth.ToString())),
                Sex = child.Sex
            };

            unit.Customers.InsertData(customer);
            unit.Complete();

            return customer.CustomerID;
        }

        private int SaveCustomerData(Father father)
        {
            Customers customer = new()
            {
                Surname = father.LastName,
                Name = father.Name,
                Patronymic = father.Patronymic,
                Birthday = father.DateOfBirth.ToDateTime(TimeOnly.Parse("12:00 PM")),
                Sex = true,
                PassportNumber = father.PassportNumber,
                PlaceOfWork = father.WorkPlace,
                ProfessionInWork = father.JobTitle,
                CurrentAddressLivingStartTime = father.LiveFrom.ToDateTime(TimeOnly.Parse("12:00 PM")),
                CityzenshipID = father.Citizenship,
                NationalityID = father.Nationality,
                AddressID = SaveAddress(father),
                CountryID = father.CurrentCountry,
                RegionID = father.CurrentRegion,
                CityDistrictID = father.CurrentCity,
                VillageID = father.CurrentVillage
            };

            unit.Customers.InsertData(customer);
            unit.Complete();

            return customer.CustomerID;
        }
        private int SaveCustomerData(Mother mother)
        {
            Customers customer = new()
            {
                Surname = mother.LastName,
                Name = mother.Name,
                Patronymic = mother.Patronymic,
                Birthday = mother.DateOfBirth.ToDateTime(TimeOnly.Parse("12:00 PM")),
                Sex = true,
                PassportNumber = mother.PassportNumber,
                PlaceOfWork = mother.WorkPlace,
                ProfessionInWork = mother.JobTitle,
                CurrentAddressLivingStartTime = mother.LiveFrom.ToDateTime(TimeOnly.Parse("12:00 PM")),
                CityzenshipID = mother.Citizenship,
                NationalityID = mother.Nationality,
                AddressID = SaveAddress(mother),
                CountryID = mother.CurrentCountry,
                RegionID = mother.CurrentRegion,
                CityDistrictID = mother.CurrentCity,
                VillageID = mother.CurrentVillage
            };

            unit.Customers.InsertData(customer);
            unit.Complete();

            return customer.CustomerID;
        }

        private int SaveAddress(Applicant applicant)
        {
            Addresses address = new()
            {
                AddressName = applicant.CurrentAddress,
                CityDistrictID = applicant.CurrentCity,
                RegionID = applicant.CurrentRegion,
                CountryID = applicant.CurrentCountry,
                StatusID = 1,
                VillageID = applicant.CurrentVillage
            };

            unit.Addresses.InsertData(address);
            unit.Complete();

            addressID = address.AddressID;
            return addressID;
        }

        private int SaveAddress(Father father)
        {
            Addresses addresses = new()
            {
                AddressName = father.CurrentAddress,
                CityDistrictID = father.CurrentCity,
                RegionID = father.CurrentRegion,
                CountryID = father.CurrentCountry,
                StatusID = 1,
                VillageID = father.CurrentVillage
            };

            unit.Addresses.InsertData(addresses);
            unit.Complete();
            return addresses.AddressID;
        }

        private int SaveAddress(Mother mother)
        {
            Addresses address = new()
            {
                AddressName = mother.CurrentAddress,
                CityDistrictID = mother.CurrentCity,
                RegionID = mother.CurrentRegion,
                CountryID = mother.CurrentCountry,
                StatusID = 1,
                VillageID = mother.CurrentVillage
            };

            unit.Addresses.InsertData(address);
            unit.Complete();
            return address.AddressID;
        }

        private void SaveApplicationDocuments(IFormFile file, int documentType)
        {
            ApplicationDocuments applicationDocuments = new()
            {
                AddressLink = SaveDocument(file).Result,
                RecievedTime = DateTime.Now,
                DocumentTypeID = documentType,
                ApplicationID = GlobalData.ApplicationID,
                ApplicationTypeID = 1,
                ApplicationsParticipantsDataID = participantDataID
            };
            unit.ApplicationDocuments.InsertData(applicationDocuments);
            unit.Complete();
        }

/*        private void SaveChildDocuments(IFormFile file, int documentType)
        {
            ApplicationDocuments childDocuments = new();
            childDocuments.AddressLink = SaveDocument(file).Result;
            childDocuments.RecievedTime = DateTime.Now;
            childDocuments.DocumentTypeID = documentType;
            childDocuments.ApplicationID = GlobalData.ApplicationID;
            childDocuments.ApplicationTypeID = 1;
            childDocuments.ApplicationsParticipantsDataID = participantDataID;
            unit.ApplicationDocuments.InsertData(childDocuments);
            unit.Complete();
        }

        private void SaveParentDocuments(IFormFile file, int documentType)
        {
            ApplicationDocuments parentDocument = new();
            parentDocument.AddressLink = SaveDocument(file).Result;
            parentDocument.RecievedTime = DateTime.Now;
            parentDocument.DocumentTypeID = documentType;
            parentDocument.ApplicationID = GlobalData.ApplicationID;
            parentDocument.ApplicationTypeID = 1;
            parentDocument.ApplicationsParticipantsDataID = participantDataID;
            unit.ApplicationDocuments.InsertData(parentDocument);
            unit.Complete();
        }
*/
        public async Task<string> SaveDocument(IFormFile file)
        {

            if(file != null)
            {
                FileInfo fileInfo = new(file.FileName);
               
                string documentName = Guid.NewGuid().ToString() + fileInfo.Extension;
                Directory.CreateDirectory(webHostEnvironment.WebRootPath + "/media/applicant_Documents/");
                string path = webHostEnvironment.WebRootPath + "/media/applicant_Documents/" + documentName;

                try
                {
                    using var fileSteam = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(fileSteam);
                }
                catch
                {
                    return "";
                }
                return path;
            }
            return "";
        }

        public List<Payment> GetPaymentList()
        {
            List<Payment> paymentList = new();
            Task<IEnumerable<PaymentTypesMobileResponse>> payments = unit.Applications.GetPaymentTypes(GlobalData.ApplicationID, 1);

            foreach (var obj in payments.Result)
            {
                paymentList.Add(new Payment { PaymentType = obj.RegistryService, PaymentPrice = obj.ServiceSum.ToString() });
            }
            return paymentList;
        }

    }
}

using System;

namespace ZagsDbServerProject.Responces
{
    public class BirthApplicationsToCROISResponse
    {
        // TODO add fields if necessary
        public string lastname { get; set; } // Фамилия(Ребёнок)
        public string firstname { get; set; } // Имя(Ребёнок)
        public string middlename { get; set; } // Отчество(Ребёнок)
        public DateTime birthdate { get; set; } // Дата и время рождения(Ребёнок)
        public string gender { get; set; } // Пол(Ребёнок)
        public string countryaddress { get; set; } // Страна рождения(Ребёнок)
        public string provinceaddress { get; set; } // Область рождения(Ребёнок)
        public string districtaddress { get; set; } // Город/район рождения(Ребёнок)
        public string municipalityaddress { get; set; } // Деревня/посёлок городского типа(Ребёнок)
        public string streetaddress { get; set; } // Адрес(Ребёнок)
        public int numberofnewborns { get; set; } // Количество новорождённых
        public int childinfamily   { get; set; } // Который ребёнок в семье
        public double weightatbirth { get; set; } // Вес при рождении(грамм)
        public double heightatbirth { get; set; } // Рост при рождении(см)
        public double pregnancyperiod { get; set; } // Длительность беременности(недели)
        public string fatherslastname { get; set; } // Фамилия(Отец)
        public string fathersfirstname { get; set; } // Имя(Отец)
        public string fathersmiddlename { get; set; } // Отчество(Отец)
        public DateTime? fathersbirthdate { get; set; } // День рождения(Отец)
        public string fatherscountryaddress { get; set; } // Страна проживания(Отец)
        public string fathersprovinceaddress { get; set; } // Область проживания(Отец)
        public string fathersdistrictaddress { get; set; } // Город/район проживания(Отец)
        public string fathersmunicipalityaddress { get; set; } // Деревня/посёлок городского типа(Отец)
        public string fathersstreetaddress { get; set; } // Адрес(Отец)
        public string fatherscitizenship { get; set; } // Гражданство(Отец)
        public string fathersnationality { get; set; } // Национальность(Отец)
        public string fatherslivessince { get; set; } // Проживаю с(Отец)
        public string fathersworkplace { get; set; } // Место работы(Отец)
        public string fatherseducation { get; set; } // Уровень образования(Отец)
        public string motherslastname { get; set; } // Фамилия(Мать)
        public string mothersfirstname { get; set; } // Имя(Мать)
        public string mothersmiddlename { get; set; } // Отчество(Мать)
        public DateTime? mothersbirthdate { get; set; } // День рождения(Мать)
        public string motherscountryaddress { get; set; } // Страна проживания(Мать)
        public string mothersprovinceaddress { get; set; } // Область проживания(Мать)
        public string mothersdistrictaddress { get; set; } // Город/район проживания(Мать)
        public string mothersmunicipalityaddress { get; set; } // Деревня/посёлок городского типа(Мать)
        public string mothersstreetaddress { get; set; } // Адрес(Мать)
        public string motherscitizenship { get; set; } // Гражданство(Мать)
        public string mothersnationality { get; set; } // Национальность(Мать)
        public string motherslivessince { get; set; } // Проживаю с(Мать)
        public string mothersworkplace { get; set; } // Место работы(Мать)
        public string mothersworkplacecategory { get; set; } // Должность на работе(Мать)
        public string motherseducation { get; set; } // Уровень образования(Мать)
        public DateTime? registrationdateariza { get; set; } // Дата подачи заявления
        public int croworkerid { get; set; } // Логин пользователя ЗАГС
        public string applicantDetails { get; set; } // Заявитель

    }
}

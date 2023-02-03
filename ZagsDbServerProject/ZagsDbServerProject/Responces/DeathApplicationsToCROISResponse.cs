using System;

namespace ZagsDbServerProject.Responces
{
    public class DeathApplicationsToCROISResponse
    {
        // TODO put type of fields correctly
        public string lastname { get; set; } // Фамилия(Усопший)
        public string firstname { get; set; } // Имя(Усопший)
        public string middlename { get; set; } // Отчество(Усопший)
        public int birthdate { get; set; } // Дата и время рождения(Усопший)
        public string gender { get; set; } // Пол(Усопший)
        public string countryaddress { get; set; } // Страна рождения(Усопший)
        public string provinceaddress { get; set; } // Область рождения(Усопший)
        public string districtaddress { get; set; } // Город/район рождения(Усопший)
        public string municipalityaddress { get; set; } // Деревня/посёлок городского типа(Усопший)
        public string streetaddress { get; set; } // Адрес(Усопший)
        public string citizenship { get; set; } // Гражданство(Усопший)
        public string nationality { get; set; } // Национальность(Усопший)
        public string workplace { get; set; } // Место работы(Усопший)
        public string workplacecategory { get; set; } // Должность на работе(Усопший)
        public string education { get; set; } // Уровень образования(Усопший)
        public string permanentcountryaddress { get; set; } // Страна последнего проживания(Усопший)
        public string permanentprovinceaddress { get; set; } // Область последнего проживания(Усопший)
        public string permanentdistrictaddress { get; set; } // Город/район последнего  проживания(Усопший)
        public string permanentmunicipalityaddress { get; set; } // Деревня/посёлок городского типа(Усопший)
        public string permanentstreetaddress { get; set; } // Адрес(Усопший)
        public string deathcountryaddress { get; set; } // Страна смерти(Усопший)
        public string deathprovinceaddress { get; set; } // Область смерти(Усопший)
        public string deathdistrictaddress { get; set; } // Город/район смерти(Усопший)
        public string deathmunicipalityaddress { get; set; } // Деревня/посёлок городского типа(Усопший)
        public string deathstreetaddress { get; set; } // Адрес(Усопший)
        public int croworkerid { get; set; } // Логин пользователя ЗАГС
        public DateTime registrationdateariza { get; set; } // Дата подачи заявления
        public string applicantDetailsName { get; set; } // Заявитель
        public string applicantDetails { get; set; } // Адресс заявителя
        public string familystatus { get; set; } // Семейное положение
        public DateTime deathdate { get; set; } // Дата смерти
        public decimal gosposhlina { get; set; } // Госпошлина
        public decimal platnieuslugi { get; set; } // Платные услуги
        public decimal oplatazablank { get; set; } // Оплата за бланк
        public bool birthyear { get; set; } // Известен только год?
        public int birthyearonly { get; set; } // Год смерти (если известен только год)
        public int childinfamily { get; set; } // Который ребёнок в семье?
    }
}

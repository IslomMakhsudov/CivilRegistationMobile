using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class DataTablesMap : IEntityTypeConfiguration<DataTables>
    {
        public void Configure(EntityTypeBuilder<DataTables> builder)
        {
            builder.HasData(
                new DataTables
                {
                    DataTableID = 1,
                    TableName = "Addresses",
                    Description = "Список всех использованных адресов"
                },
                new DataTables
                {
                    DataTableID = 2,
                    TableName = "ApplicationDocuments",
                    Description = "Документы заявки"
                },
                new DataTables
                {
                    DataTableID = 3,
                    TableName = "ApplicationMembersNeededData",
                    Description = "Необходимые данные участника заявки"
                },
                new DataTables
                {
                    DataTableID = 4,
                    TableName = "ApplicationMembersTypes",
                    Description = "Список участников заявки"
                },
                new DataTables
                {
                    DataTableID = 5,
                    TableName = "Applications",
                    Description = "Список заявок"
                },
                new DataTables
                {
                    DataTableID = 6,
                    TableName = "ApplicationsDetails",
                    Description = "Детали заявки"
                },
                new DataTables
                {
                    DataTableID = 7,
                    TableName = "ApplicationsParticipantsData",
                    Description = "Данные участников заявки"
                },
                new DataTables
                {
                    DataTableID = 8,
                    TableName = "ApplicationsPayments",
                    Description = "Оплата по заявке"
                },
                new DataTables // нужно оставить либо это либо ApplicationDetails 
                {
                    DataTableID = 9,
                    TableName = "ApplicationSpecificData",
                    Description = "Доп-данные заявки"
                },
                new DataTables
                {
                    DataTableID = 10,
                    TableName = "ApplicationStatuses",
                    Description = "Справочник: Статусы заявкок"
                },
                new DataTables
                {
                    DataTableID = 11,
                    TableName = "ApplicationTypeMembers",
                    Description = "Виды участников по типам заявок"
                },
                new DataTables
                {
                    DataTableID = 12,
                    TableName = "ApplicationTypePayments",
                    Description = "Виды оплат по типам заявок"
                },
                new DataTables
                {
                    DataTableID = 13,
                    TableName = "ApplicationTypes",
                    Description = "Справочник: Виды заявок"
                },
                new DataTables
                {
                    DataTableID = 14,
                    TableName = "ApplicationTypesSpecificData",
                    Description = "Виды доп-данных по типам заявок"
                },
                new DataTables
                {
                    DataTableID = 15,
                    TableName = "CitiesDistricts",
                    Description = "Справочник: Города/Районы"
                },
                new DataTables
                {
                    DataTableID = 16,
                    TableName = "Citizenship",
                    Description = "Справочник: Гражданство"
                }, ///// здесь
                new DataTables
                {
                    DataTableID = 17,
                    TableName = "Countries",
                    Description = "Спаравочник: Страны"
                },
                new DataTables
                {
                    DataTableID = 18,
                    TableName = "Customers",
                    Description = "Список клиентов"
                },
                new DataTables
                {
                    DataTableID = 19,
                    TableName = "CustomersFeedbacks",
                    Description = "Отзывы клиентов"
                },
                new DataTables
                {
                    DataTableID = 20,
                    TableName = "DataTables",
                    Description = "Таблицы базы данных"
                },
                new DataTables
                {
                    DataTableID = 21,
                    TableName = "ApplicationDocumentTypes",
                    Description = "Справочник: Виды документов для заявок"
                },
                new DataTables
                {
                    DataTableID = 22,
                    TableName = "EducationLevels",
                    Description = "Справочник: Уровень образования"
                },
                new DataTables
                {
                    DataTableID = 23,
                    TableName = "FAQ",
                    Description = "Список часто задаваемых вопросов и ответы на них"
                },
                new DataTables
                {
                    DataTableID = 24,
                    TableName = "FieldTypes",
                    Description = "Справочник: Типы полей"
                },
                new DataTables
                {
                    DataTableID = 25,
                    TableName = "Labels",
                    Description = "Справочник: Названия полей и форм (на таджикском, русском и английском языках)"
                },
                new DataTables
                {
                    DataTableID = 26,
                    TableName = "Languages",
                    Description = "Справочник: Языки пользовательского интерфейса"
                },
                new DataTables
                {
                    DataTableID = 27,
                    TableName = "Nationalities",
                    Description = "Справочник: Национальность"
                },
                new DataTables
                {
                    DataTableID = 28,
                    TableName = "OperationTypes",
                    Description = "Справочник: Виды доступных операций"
                },
                new DataTables
                {
                    DataTableID = 29,
                    TableName = "OtherStateOrgans",
                    Description = "Справочник: Другие гос-органы и отделения"
                },
                new DataTables
                {
                    DataTableID = 30,
                    TableName = "PaymentJournalEntry",
                    Description = "Журнал оплаты заявок"
                },
                new DataTables
                {
                    DataTableID = 31,
                    TableName = "PaymentSystems",
                    Description = "Справочник: Платёжные системы"
                },
                new DataTables
                {
                    DataTableID = 32,
                    TableName = "PaymentTypes",
                    Description = "Справочник: Виды оплат"
                },
                new DataTables
                {
                    DataTableID = 33,
                    TableName = "Regions",
                    Description = "Справочник: Области"
                },
                new DataTables
                {
                    DataTableID = 34,
                    TableName = "RegistryOfficeDepartments",
                    Description = "Справочник: Отделения ЗАГС"
                },
                new DataTables
                {
                    DataTableID = 35,
                    TableName = "Roles",
                    Description = "Справочник: Роли"
                },
                new DataTables
                {
                    DataTableID = 36,
                    TableName = "RolesOperations",
                    Description = "Справочник: Виды операций по ролям"
                },
                new DataTables
                {
                    DataTableID = 37,
                    TableName = "SpecificApplicationData",
                    Description = "Справочник: Доп-данные для заявки"
                },
                new DataTables
                {
                    DataTableID = 38,
                    TableName = "Statuses",
                    Description = "Справочник: Статусы справочных данных"
                },
                new DataTables
                {
                    DataTableID = 39,
                    TableName = "UserLogs",
                    Description = "Журнал действий работников ЗАГС"
                },
                new DataTables
                {
                    DataTableID = 40,
                    TableName = "Users",
                    Description = "Список работников ЗАГС"
                },
                new DataTables
                {
                    DataTableID = 41,
                    TableName = "UserSessions",
                    Description = "Журнал сессий работников ЗАГС"
                },
                new DataTables
                {
                    DataTableID = 42,
                    TableName = "UserStatuses",
                    Description = "Статусы работников ЗАГС"
                },
                new DataTables
                {
                    DataTableID = 43,
                    TableName = "UsersWorkplaces",
                    Description = "Справочник: Места работы работников ЗАГС"
                },
                new DataTables
                {
                    DataTableID = 44,
                    TableName = "Villages",
                    Description = "Справочник: Джамоаты/Колхозы/Посёлки"
                }
                /*,
                new DataTables
                {
                    AffectedTableID = 2,
                    TableName = "ApplicationDocuments",
                    Description = "dbo." + "ApplicationDocuments"
                }*/
            );

        }
    }
}

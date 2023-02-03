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
                    Description = "Список всех использованных адресов (в метке только названия для адресов ЗАГС)",
                    IsRepresentedInWeb = true,
                    LabelID = 1457
                },
                new DataTables
                {
                    DataTableID = 2,
                    TableName = "AffectedDataTables",
                    Description = "Таблицы задействованные в процессе",
                    IsRepresentedInWeb = false,
                    LabelID = 1458
                },
                new DataTables
                {
                    DataTableID = 3,
                    TableName = "ApplicationChangedStatus",
                    Description = "История изменения статусов заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1459
                },
                new DataTables
                {
                    DataTableID = 4,
                    TableName = "ApplicationDocuments",
                    Description = "Документы заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1460
                },
                new DataTables
                {
                    DataTableID = 5,
                    TableName = "ApplicationDocumentTypes",
                    Description = "Справочник: Виды документов для заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1461
                },
                new DataTables
                {
                    DataTableID = 6,
                    TableName = "ApplicationMembersNeededData",
                    Description = "Справочник: Необходимые данные участника заявки",
                    IsRepresentedInWeb = false,
                    LabelID = 1462
                },
                new DataTables
                {
                    DataTableID = 7,
                    TableName = "ApplicationMemberTypes",
                    Description = "Список участников заявки",
                    IsRepresentedInWeb = true,
                    LabelID = 1463
                },
                new DataTables
                {
                    DataTableID = 8,
                    TableName = "ApplicationMistakes",
                    Description = "Список ошибок заявки",
                    IsRepresentedInWeb = false,
                    LabelID = 1464
                },
                new DataTables
                {
                    DataTableID = 9,
                    TableName = "Applications",
                    Description = "Список заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1465
                },
                new DataTables
                {
                    DataTableID = 10,
                    TableName = "ApplicationsDetails",
                    Description = "Детали заявки",
                    IsRepresentedInWeb = false,
                    LabelID = 1466
                },
                new DataTables
                {
                    DataTableID = 11,
                    TableName = "ApplicationSources",
                    Description = "Справочник источников заполнения заявки",
                    IsRepresentedInWeb = true,
                    LabelID = 1467
                },
                new DataTables
                {
                    DataTableID = 12,
                    TableName = "ApplicationsParticipantsData",
                    Description = "Данные участников заявки",
                    IsRepresentedInWeb = false,
                    LabelID = 1468
                },
                new DataTables
                {
                    DataTableID = 13,
                    TableName = "ApplicationsPayments",
                    Description = "Журнал оплат по заявкам",
                    IsRepresentedInWeb = false,
                    LabelID = 1469
                },
                new DataTables
                {
                    DataTableID = 14,
                    TableName = "ApplicationsPaymentsDetails",
                    Description = "Детали оплат заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1470
                },
                new DataTables
                {
                    DataTableID = 15,
                    TableName = "ApplicationStatusElements",
                    Description = "Элементы статусов заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1471
                },
                new DataTables
                {
                    DataTableID = 16,
                    TableName = "ApplicationStatuses",
                    Description = "Cправочник: Статусы заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1472
                },
                new DataTables
                {
                    DataTableID = 17,
                    TableName = "ApplicationsToCROISStatuses",
                    Description = "Cправочник: Статусы заявок в КРОИС",
                    IsRepresentedInWeb = false,
                    LabelID = 1473
                },
                new DataTables
                {
                    DataTableID = 18,
                    TableName = "ApplicationTypeMembers",
                    Description = "Виды участников по типам заявок",
                    IsRepresentedInWeb = true,
                    LabelID = 1474
                },
                new DataTables
                {
                    DataTableID = 19,
                    TableName = "ApplicationTypePayments",
                    Description = "Виды оплат по типам заявок",
                    IsRepresentedInWeb = true,
                    LabelID = 1475
                },
                new DataTables
                {
                    DataTableID = 20,
                    TableName = "ApplicationTypes",
                    Description = "Справочник: Виды заявок",
                    IsRepresentedInWeb = true,
                    LabelID = 1476
                },
                new DataTables
                {
                    DataTableID = 21,
                    TableName = "ApplicationTypesSpecificData",
                    Description = "Виды доп-данных по типам заявок",
                    IsRepresentedInWeb = true,
                    LabelID = 1477
                },
                new DataTables
                {
                    DataTableID = 22,
                    TableName = "CitiesDistricts",
                    Description = "Справочник: Города/Районы",
                    IsRepresentedInWeb = true,
                    LabelID = 1478
                },
                new DataTables
                {
                    DataTableID = 23,
                    TableName = "Cityzenship",
                    Description = "Справочник: Гражданство",
                    IsRepresentedInWeb = true,
                    LabelID = 1479
                },
                new DataTables
                {
                    DataTableID = 24,
                    TableName = "Countries",
                    Description = "Спаравочник: Страны",
                    IsRepresentedInWeb = true,
                    LabelID = 1480
                },
                new DataTables
                {
                    DataTableID = 25,
                    TableName = "Customers",
                    Description = "Список клиентов",
                    IsRepresentedInWeb = false,
                    LabelID = 1481
                },
                new DataTables
                {
                    DataTableID = 26,
                    TableName = "CustomersFeedbacks",
                    Description = "Отзывы клиентов",
                    IsRepresentedInWeb = false,
                    LabelID = 1482
                },
                new DataTables
                {
                    DataTableID = 27,
                    TableName = "CustomersLogs",
                    Description = "Лог клиентов",
                    IsRepresentedInWeb = false,
                    LabelID = 1483
                },
                new DataTables
                {
                    DataTableID = 28,
                    TableName = "CustomersRequests",
                    Description = "Запросы клиентов",
                    IsRepresentedInWeb = false,
                    LabelID = 1484
                },
                new DataTables
                {
                    DataTableID = 29,
                    TableName = "DataTables",
                    Description = "Справочник: Таблицы базы данных",
                    IsRepresentedInWeb = false,
                    LabelID = 1485
                },
                new DataTables
                {
                    DataTableID = 30,
                    TableName = "EducationLevels",
                    Description = "Справочник: Уровень образования",
                    IsRepresentedInWeb = true,
                    LabelID = 1486
                },
                new DataTables
                {
                    DataTableID = 31,
                    TableName = "FAQ",
                    Description = "Список часто задаваемых вопросов и ответы на них",
                    IsRepresentedInWeb = true,
                    LabelID = 1487
                },
                new DataTables
                {
                    DataTableID = 32,
                    TableName = "FieldTypes",
                    Description = "Справочник: Типы полей",
                    IsRepresentedInWeb = false,
                    LabelID = 1488
                },
                new DataTables
                {
                    DataTableID = 33,
                    TableName = "InterfaceColors",
                    Description = "Справочник: цвета в интерфейсе",
                    IsRepresentedInWeb = false,
                    LabelID = 1489
                },
                new DataTables
                {
                    DataTableID = 34,
                    TableName = "Labels",
                    Description = "Справочник: Названия полей и форм (на таджикском, русском и английском языках)",
                    IsRepresentedInWeb = false,
                    LabelID = 1490
                },
                new DataTables
                {
                    DataTableID = 35,
                    TableName = "Languages",
                    Description = "Справочник: Языки пользовательского интерфейса",
                    IsRepresentedInWeb = true,
                    LabelID = 1491
                },
                new DataTables
                {
                    DataTableID = 36,
                    TableName = "Logs",
                    Description = "Общий лог системы",
                    IsRepresentedInWeb = false,
                    LabelID = 1492
                },
                new DataTables
                {
                    DataTableID = 37,
                    TableName = "MaritalStatuses",
                    Description = "Справочник: Семейное положение",
                    IsRepresentedInWeb = true,
                    LabelID = 1493
                },
                new DataTables
                {
                    DataTableID = 38,
                    TableName = "Nationalities",
                    Description = "Справочник: Национальность",
                    IsRepresentedInWeb = true,
                    LabelID = 1494
                },
                new DataTables
                {
                    DataTableID = 39,
                    TableName = "OperationsTypes",
                    Description = "Справочник: Виды доступных операций",
                    IsRepresentedInWeb = true,
                    LabelID = 1495
                },
                new DataTables
                {
                    DataTableID = 40,
                    TableName = "OrganizationUnitNew1ForResearch",
                    Description = "Справочник: Отделения ЗАГС и их адреса из КРОИС",
                    IsRepresentedInWeb = false,
                    LabelID = 1496
                },
                new DataTables
                {
                    DataTableID = 41,
                    TableName = "OtherStateOrgans",
                    Description = "Справочник: Другие гос-органы и отделения",
                    IsRepresentedInWeb = true,
                    LabelID = 1497
                },
                new DataTables
                {
                    DataTableID = 42,
                    TableName = "PaymentsAccounts",
                    Description = "Справочник: Виды необходимых платежей по типам заявок",
                    IsRepresentedInWeb = false,
                    LabelID = 1498
                },
                new DataTables
                {
                    DataTableID = 43,
                    TableName = "PaymentSystems",
                    Description = "Справочник: Платёжные системы",
                    IsRepresentedInWeb = true,
                    LabelID = 1499
                },
                new DataTables
                {
                    DataTableID = 44,
                    TableName = "PaymentTypes",
                    Description = "Справочник: Виды платежей",
                    IsRepresentedInWeb = true,
                    LabelID = 1500
                },
                new DataTables
                {
                    DataTableID = 45,
                    TableName = "PaymentTypesGroups",
                    Description = "Справочник: Группы видов платежей",
                    IsRepresentedInWeb = false,
                    LabelID = 1501
                },
                new DataTables
                {
                    DataTableID = 46,
                    TableName = "ProjectSettings",
                    Description = "Справочник: Настройки проекта (расчётный показатель)",
                    IsRepresentedInWeb = true,
                    LabelID = 1502
                },
                new DataTables
                {
                    DataTableID = 47,
                    TableName = "Regions",
                    Description = "Справочник: Области",
                    IsRepresentedInWeb = true,
                    LabelID = 1503
                },
                new DataTables
                {
                    DataTableID = 48,
                    TableName = "RegistryOfficeDepartments",
                    Description = "Справочник: Отделения ЗАГС",
                    IsRepresentedInWeb = true,
                    LabelID = 1504
                },
                new DataTables
                {
                    DataTableID = 49,
                    TableName = "RejectionCauses",
                    Description = "Справочник: Причина отказа",
                    IsRepresentedInWeb = true,
                    LabelID = 1505
                },
                new DataTables
                {
                    DataTableID = 50,
                    TableName = "Roles",
                    Description = "Справочник: Роли",
                    IsRepresentedInWeb = false,
                    LabelID = 1506
                },
                new DataTables
                {
                    DataTableID = 51,
                    TableName = "RolesOperations",
                    Description = "Справочник: Виды операций по ролям",
                    IsRepresentedInWeb = false,
                    LabelID = 1507
                },
                new DataTables
                {
                    DataTableID = 52,
                    TableName = "SpecificApplicationData",
                    Description = "Справочник: Доп-данные для заявки",
                    IsRepresentedInWeb = true,
                    LabelID = 1508
                },
                new DataTables
                {
                    DataTableID = 53,
                    TableName = "Statuses",
                    Description = "Справочник: Статусы справочных данных",
                    IsRepresentedInWeb = false,
                    LabelID = 1509
                },
                new DataTables
                {
                    DataTableID = 54,
                    TableName = "Supports",
                    Description = "Справочник: Тех. Поддержка",
                    IsRepresentedInWeb = false,
                    LabelID = 1510
                },
                new DataTables
                {
                    DataTableID = 55,
                    TableName = "SupportTypes",
                    Description = "Справочник: Платформы Тех. Поддержки",
                    IsRepresentedInWeb = false,
                    LabelID = 1511
                },
                new DataTables
                {
                    DataTableID = 56,
                    TableName = "TypesOfActivitiesInWork",
                    Description = "Справочник: Виды деятельности",
                    IsRepresentedInWeb = true,
                    LabelID = 1512
                },
                new DataTables
                {
                    DataTableID = 57,
                    TableName = "Users",
                    Description = "Список работников ЗАГС",
                    IsRepresentedInWeb = false,
                    LabelID = 1513
                },
                new DataTables
                {
                    DataTableID = 58,
                    TableName = "UserSessions",
                    Description = "Журнал сессий работников ЗАГС",
                    IsRepresentedInWeb = false,
                    LabelID = 1514
                },
                new DataTables
                {
                    DataTableID = 59,
                    TableName = "UserStatuses",
                    Description = "Справочник: Статусы работников ЗАГС",
                    IsRepresentedInWeb = true,
                    LabelID = 1515
                },
                new DataTables
                {
                    DataTableID = 60,
                    TableName = "UsersWorkplaces",
                    Description = "Места работы работников ЗАГС",
                    IsRepresentedInWeb = false,
                    LabelID = 1516
                },
                new DataTables
                {
                    DataTableID = 61,
                    TableName = "Villages",
                    Description = "Справочник: Джамоаты/Колхозы/Посёлки",
                    IsRepresentedInWeb = true,
                    LabelID = 1517
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

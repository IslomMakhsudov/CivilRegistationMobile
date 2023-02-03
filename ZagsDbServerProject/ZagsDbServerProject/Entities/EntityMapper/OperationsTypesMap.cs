using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZagsDbServerProject.Entities.EntityMapper
{
    public class OperationsTypesMap : IEntityTypeConfiguration<OperationsTypes>
    {
        public void Configure(EntityTypeBuilder<OperationsTypes> builder)
        {
            builder.HasData(
                new OperationsTypes
                {
                    OperationTypeID = 1,
                    OperationTypeName = "Просмотр списка заявок",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 2,
                    OperationTypeName = "Просмотр деталей заявок",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 3,
                    OperationTypeName = "Принятие заявки",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 4,
                    OperationTypeName = "Отклонение заявки",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 5,
                    OperationTypeName = "Отправка заявки на корректировку",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 6,
                    OperationTypeName = "Просмотр деталей черновиков (И в окне заявок и в окне отчёта)",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 7,
                    OperationTypeName = "Проверка заявок по всем отделам (просмотр и обработка)",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 8,
                    OperationTypeName = "Добавление пользователя",
                    OperationGroupName = "Контроль пользователей",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 9,
                    OperationTypeName = "Удаление пользователя",
                    OperationGroupName = "Контроль пользователей",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 10,
                    OperationTypeName = "Изменение пользователя",
                    OperationGroupName = "Контроль пользователей",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 11,
                    OperationTypeName = "Управление словарями",
                    OperationGroupName = "Контроль справочных данных",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 12,
                    OperationTypeName = "Просмотр справочников",
                    OperationGroupName = "Контроль справочных данных",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 13,
                    OperationTypeName = "Изменение справочников",
                    OperationGroupName = "Контроль справочных данных",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 14,
                    OperationTypeName = "Формирование отчёта по заявкам",
                    OperationGroupName = "Отчётность",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 15,
                    OperationTypeName = "Формирование отчёта по оплаченным заявкам",
                    OperationGroupName = "Отчётность",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 16,
                    OperationTypeName = "Вход в админку",
                    OperationGroupName = "Контроль пользователей",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 17,
                    OperationTypeName = "Изменение данных заявки",
                    OperationGroupName = "Контроль заявок",
                    StatusID = 1
                },
                new OperationsTypes
                {
                    OperationTypeID = 18,
                    OperationTypeName = "Просмотр списка пользователей",
                    OperationGroupName = "Контроль пользователей",
                    StatusID = 1
                }
            );
        }
    }
}

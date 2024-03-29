﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Repositories;
using ZagsDbServerProject.Interfaces;

namespace ZagsDbServerProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Addresses = new AddressesRepository(_context);
            ApplicationDocuments = new ApplicationDocumentsRepository(_context);
            ApplicationDocumentTypes = new ApplicationDocumentTypesRepository(_context);
            ApplicationMembersNeededData = new ApplicationMembersNeededDataRepository(_context);
            ApplicationMemberTypes = new ApplicationMemberTypesRepository(_context);
            ApplicationMistakes = new ApplicationMistakesRepository(_context);
            ApplicationsDetails = new ApplicationsDetailsRepository(_context);
            ApplicationsParticipantsData = new ApplicationsParticipantsDataRepository(_context);
            Applications = new ApplicationsRepository(_context);
            ApplicationsCorrectionComments = new ApplicationsCorrectionCommentsRepository(_context);
            ApplicationTypes = new ApplicationTypesRepository(_context);
            BaseTypes = new BaseRepository(_context);
            Customers = new CustomersRepository(_context);
            CustomersLogs = new CustomersLogsRepository(_context);
            Departments = new DepartmentsRepository(_context);
            FAQ = new FAQRepository(_context);
            Labels = new LabelsRepository(_context);
            Logs = new LogsRepository(_context);
            Roles = new RolesRepository(_context);
            PaymentsAccounts = new PaymentsAccountsRepository(_context);
            SpecificApplicationData = new SpecificApplicationDataRepository(_context);
            TajikNames = new TajikNamesRepository(_context);
            Users = new UsersRepository(_context);
            UserSessions = new UserSessionsRepository(_context);
            RolesOperations = new RolesOperationsRepository(_context);
        }

        public IAddressesRepository Addresses { get; private set; }
        public IApplicationDocumentsRepository ApplicationDocuments { get; private set; }
        public IApplicationDocumentTypesRepository ApplicationDocumentTypes { get; private set; }
        public IApplicationMembersNeededDataRepository ApplicationMembersNeededData { get; private set; }
        public IApplicationMemberTypesRepository ApplicationMemberTypes { get; private set; }
        public IApplicationMistakesRepository ApplicationMistakes { get; private set; }
        public IApplicationsDetailsRepository ApplicationsDetails { get; private set; }
        public IApplicationsParticipantsDataRepository ApplicationsParticipantsData { get; private set; }
        public IApplicationsRepository Applications { get; private set; }
        public IApplicationsCorrectionCommentsRepository ApplicationsCorrectionComments { get; private set; }
        public IApplicationTypesRepository ApplicationTypes { get; private set; }
        public IBaseRepository BaseTypes { get; private set; }
        public ICustomersRepository Customers { get; private set; }
        public ICustomersLogsRepository CustomersLogs { get; private set; }
        public IDepartmentsRepository Departments { get; private set; }
        public IFAQRepository FAQ { get; private set; }
        public ILabelsRepository Labels { get; private set; }
        public ILogsRepository Logs { get; private set; }
        public IRolesRepository Roles { get; private set; }
        public IPaymentsAccountsRepository PaymentsAccounts { get; private set; }
        public ISpecificApplicationDataRepository SpecificApplicationData { get; private set; }
        public ITajikNamesRepository TajikNames { get; private set; }
        public IUsersRepository Users { get; private set; }
        public IUserSessionsRepository UserSessions { get; private set; }
        public IRolesOperationsRepository RolesOperations { get; private set; }
        public int Insert(object obj)
        {
            _context.Attach(obj);
            _context.Set<object>().Add(obj);
            return _context.SaveChanges();
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public int Update(object obj)
        {
            _context.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

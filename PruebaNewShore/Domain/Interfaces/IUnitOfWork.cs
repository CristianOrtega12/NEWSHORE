using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Journey> JourneyRepository { get; }
        IRepository<Fligth> FligthRepository { get; }
        IRepository<Transport> TransportRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<User> UserRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
        string GetDbConnection();
    }
}
